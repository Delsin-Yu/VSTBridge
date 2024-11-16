using Jacobi.Vst.Core;
using Jacobi.Vst.Plugin.Framework;

namespace VSTBridge.Client;

public class AudioProcessor(MidiBridge bridge) : IVstPluginAudioProcessor
{
    private readonly DoubleBuffer<float> _leftChannelBuffer = new(Plugin.DefaultSampleRate);
    private readonly DoubleBuffer<float> _rightChannelBuffer = new(Plugin.DefaultSampleRate);

    void IVstPluginAudioProcessor.Process(VstAudioBuffer[] inChannels, VstAudioBuffer[] outChannels)
    {
        bridge.Poll(_leftChannelBuffer, _rightChannelBuffer);
        var leftChannelBuffer = outChannels[0].AsSpan();
        var rightChannelBuffer = outChannels[1].AsSpan();
        _leftChannelBuffer.Read(leftChannelBuffer);
        _rightChannelBuffer.Read(rightChannelBuffer);
    }

    bool IVstPluginAudioProcessor.SetPanLaw(VstPanLaw type, float gain)
    {
        _panLaw = type;
        _gain = gain;
        return true;
    }

    public int InputCount => 2;
    public int OutputCount => 2;
    public int TailSize => 0;
    public bool NoSoundInStop => true;

    private VstPanLaw _panLaw;
    private float _gain;
    
    public float SampleRate
    {
        get => bridge.SampleRate;
        set => bridge.SampleRate = value;
    }

    public int BlockSize
    {
        get => bridge.BlockSize;
        set => bridge.BlockSize = value;
    }
}