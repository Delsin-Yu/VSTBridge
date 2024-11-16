using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Jacobi.Vst.Core;
using Jacobi.Vst.Plugin.Framework;

namespace VSTBridge.Client;

public class ConnectionManager(MidiBridge bridge)
{
    private Connection? _activeConnection;

    public async Task ConnectAsync()
    {
        _activeConnection?.Dispose();
        var pipe = new NamedPipeServerStream("vst-bridge");
        await pipe.WaitForConnectionAsync();
        _activeConnection = new(pipe, OnDisconnected);
        bridge.Connection = _activeConnection;
    }

    private void OnDisconnected()
    {
        _activeConnection?.Dispose();
        _activeConnection = null;
    }

    private class Connection(NamedPipeServerStream serverStream, Action disconnected) : IConnection, IDisposable
    {
        private readonly BinaryWriter _streamWriter = new(serverStream);

        public void Send(VstEventCollection eventCollection)
        {
            try
            {
                Serialize(eventCollection, _streamWriter);
            }
            catch
            {
                disconnected.Invoke();
            }
        }

        public void Poll(DoubleBuffer<float> leftChannel, DoubleBuffer<float> rightChannel)
        {
            try
            {
                Deserialize(leftChannel, rightChannel, serverStream);
            }
            catch
            {
                disconnected.Invoke();
            }
        }

        private static void Serialize(VstEventCollection eventCollection, BinaryWriter writer)
        {
            foreach (var vstEvent in eventCollection)
            {
                if (vstEvent is not VstMidiEvent vstMidiEvent) continue;
                writer.Write(vstMidiEvent.DeltaFrames);
                writer.Write(vstMidiEvent.NoteLength);
                writer.Write(vstMidiEvent.Data[0]);
                writer.Write(vstMidiEvent.Data[1]);
                writer.Write(vstMidiEvent.Data[2]);
                writer.Write(vstMidiEvent.Detune);
                writer.Write(vstMidiEvent.NoteOffVelocity);
            }
        }

        private readonly int _floatBytes = Unsafe.SizeOf<float>();
        private readonly List<byte> _bodyParseBuffer = [];

        private void Deserialize(DoubleBuffer<float> leftChannel, DoubleBuffer<float> rightChannel, NamedPipeServerStream stream)
        {
            Span<byte> bytes = stackalloc byte[_floatBytes];
            stream.ReadExactly(bytes);
            var leftSamples = BitConverter.ToInt32(bytes);
            stream.ReadExactly(bytes);
            var rightSamples = BitConverter.ToInt32(bytes);

            var leftSampleBytes = leftSamples * _floatBytes;
            var rightSampleBytes = rightSamples * _floatBytes;

            var sampleBytesCount = Math.Max(leftSampleBytes, rightSampleBytes);

            if (_bodyParseBuffer.Capacity < sampleBytesCount) _bodyParseBuffer.Capacity = sampleBytesCount;

            var largeBuffer = CollectionsMarshal.AsSpan(_bodyParseBuffer);
            
            var leftBuffer = largeBuffer[..leftSampleBytes];
            stream.ReadExactly(leftBuffer);
            leftChannel.Write(Cast<byte, float>(leftBuffer));

            var rightBuffer = largeBuffer[..rightSampleBytes];
            stream.ReadExactly(rightBuffer);
            rightChannel.Write(Cast<byte, float>(rightBuffer));
        }

        public static unsafe Span<TDst> Cast<TSrc, TDst>(Span<TSrc> source)
            where TSrc : unmanaged where TDst : unmanaged
        {
            var srcTypeByteSize = Unsafe.SizeOf<TSrc>();
            var dstTypeByteSize = Unsafe.SizeOf<TDst>();

            var dstSize = source.Length * srcTypeByteSize / dstTypeByteSize;

            ref var sourcePtr = ref source[0];

            ref var dstPtr = ref Unsafe.As<TSrc, TDst>(ref sourcePtr);

            return new(Unsafe.AsPointer(ref dstPtr), dstSize);
        }
        
        public void Dispose() => serverStream.Dispose();
    }
}