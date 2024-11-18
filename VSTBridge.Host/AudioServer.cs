using System.Runtime.InteropServices;
using Jacobi.Vst.Core;
using Jacobi.Vst.Host.Interop;

namespace VSTBridge.Host;

public class AudioServer : IDisposable
{
    private readonly Dictionary<VstPluginContext, VstPluginReader> _dictionary = [];

    private readonly List<VstPluginReader> _readers = [];

#if !NET9_0
    private readonly object _lock = new();
#else
    private readonly Lock _lock = new();
#endif

    private bool _isDisposed;

    public AudioServer()
    {
        new Thread(Update).Start();
    }

    public void Add(VstPluginContext context)
    {
        var vstPluginReader = new VstPluginReader(context);
        _dictionary.Add(context, vstPluginReader);
        lock (_lock)
            _readers.Add(vstPluginReader);
    }

    public void Remove(VstPluginContext context)
    {
        if (!_dictionary.Remove(context, out var reader)) return;
        lock (_lock)
            _readers.Remove(reader);
    }

    private void Update()
    {
        while (!_isDisposed)
            lock (_lock)
                foreach (var reader in _readers)
                  reader.Read();
    }

    private class VstPluginReader : IDisposable
    {
        private readonly VstAudioBuffer[] _inputs;
        private readonly VstAudioBuffer[] _outputs;
        private readonly IVstPluginCommands24 _commands;
        private readonly Stack<nint> _allocatedHandlers = [];

        public VstPluginReader(VstPluginContext context)
        {
            var info = context.PluginInfo;

            _commands = context.PluginCommandStub.Commands;

            _inputs = new VstAudioBuffer[info.AudioInputCount];
            _outputs = new VstAudioBuffer[info.AudioOutputCount];

            foreach (ref var vstAudioBuffer in _inputs.AsSpan()) vstAudioBuffer = CreateBuffer(2048);
            foreach (ref var vstAudioBuffer in _outputs.AsSpan()) vstAudioBuffer = CreateBuffer(2048);
        }

        public void Read()
        {
            _commands.ProcessReplacing(_inputs, _outputs);
        }

        public unsafe void Dispose()
        {
            while (_allocatedHandlers.TryPop(out var ptr))
                NativeMemory.Free((void*)ptr);
        }

        private unsafe VstAudioBuffer CreateBuffer(int length)
        {
            var pointer = NativeMemory.AllocZeroed((UIntPtr)length, sizeof(float));
            _allocatedHandlers.Push((nint)pointer);
            return new((float*)pointer, length, true);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _isDisposed = true;

        lock (_lock)
        {
            foreach (var reader in _readers)
                reader.Dispose();
            _readers.Clear();
        }
    }
}