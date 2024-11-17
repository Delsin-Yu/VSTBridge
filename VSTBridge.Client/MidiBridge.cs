using Jacobi.Vst.Plugin.Framework;

namespace VSTBridge.Client;

public interface IConnection
{
    void Send(VstEventCollection eventCollection);
    void Poll(DoubleBuffer<float> leftChannel, DoubleBuffer<float> rightChannel);
}

public class MidiBridge
{
    public float SampleRate { get; set; } = Plugin.DefaultSampleRate;
    public int BlockSize { get; set; }

    public IConnection? Connection { get; set; }

    public void Send(VstEventCollection midiEventCollection) => Connection?.Send(midiEventCollection);

    public void Poll(DoubleBuffer<float> leftChannel, DoubleBuffer<float> rightChannel) => Connection?.Poll(leftChannel, rightChannel);
}