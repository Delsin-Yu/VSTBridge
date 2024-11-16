using System.Diagnostics.CodeAnalysis;
using Jacobi.Vst.Core;
using Jacobi.Vst.Plugin.Framework;
using Jacobi.Vst.Plugin.Framework.Plugin;

namespace VSTBridge.Client;

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicMethods)]
public class PluginCommandStub : StdPluginCommandStub
{
    protected override IVstPlugin CreatePluginInstance() => new Plugin();
}

public class Plugin : VstPlugin
{
    public const int DefaultSampleRate = 48000;

    private readonly MidiProcessor _midiProcessor;
    private readonly ConnectionManager _connectionManager;
    private readonly AudioProcessor _audioProcessor;

    public Plugin() : base(
        "VST Bridge",
        0x56_53_43_23,
        new("VST Bridge", "DE-YU", 0),
        VstPluginCategory.Synth
    )
    {
        MidiBridge midiBridge = new();
        _midiProcessor = new(midiBridge);
        _connectionManager = new(midiBridge);
        _audioProcessor = new(midiBridge);
    }

    public override bool Supports<T>()
    {
        if (typeof(T) == typeof(IVstMidiProcessor)) return true;
        if (typeof(T) == typeof(IVstPluginAudioProcessor)) return true;
        return false;
    }

    public override T? GetInstance<T>() where T : class
    {
        if (typeof(T) == typeof(IVstMidiProcessor)) return (T)(object)_midiProcessor;
        if (typeof(T) == typeof(IVstPluginAudioProcessor)) return (T)(object)_audioProcessor;
        return null;
    }

    //
    // protected override void ConfigureServices(IServiceCollection services) =>
    //     services
    //         .AddSingleton<MidiBridge>()
    //         .AddSingleton<ConnectionManager>()
    //         .AddSingleton<MidiProcessor>()
    //         .AddSingleton<AudioProcessor>();
}