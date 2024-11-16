using Jacobi.Vst.Plugin.Framework;

namespace VSTBridge.Client;

public class MidiProcessor(MidiBridge bridge) : IVstMidiProcessor
{
    void IVstMidiProcessor.Process(VstEventCollection events) => 
        bridge.Send(events);

    public int ChannelCount => 16;
}