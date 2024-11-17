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
    public const int DefaultBlockSize = 2048;

    private readonly MidiProcessor _midiProcessor;
    private readonly AudioProcessor _audioProcessor;
    private readonly PluginEditor _editor;

    public Plugin() : base(
        "VST Bridge",
        new FourCharacterCode("VSC#").ToInt32(),
        new("VST Bridge", "DE-YU", 0),
        VstPluginCategory.Synth
    )
    {
        MidiBridge midiBridge = new();
        _midiProcessor = new(midiBridge);
        _audioProcessor = new(midiBridge);
        ConnectionManager connectionManager = new(midiBridge);
        _editor = new(connectionManager);
    }

    public override bool Supports<T>()
    {
        if (typeof(T) == typeof(IVstMidiProcessor)) return true;
        if (typeof(T) == typeof(IVstPluginAudioProcessor)) return true;
        if (typeof(T) == typeof(IVstPluginEditor)) return true;
        return false;
    }

    public override T? GetInstance<T>() where T : class
    {
        if (typeof(T) == typeof(IVstMidiProcessor)) return (T)(object)_midiProcessor;
        if (typeof(T) == typeof(IVstPluginAudioProcessor)) return (T)(object)_audioProcessor;
        if (typeof(T) == typeof(IVstPluginEditor)) return (T)(object)_editor;
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