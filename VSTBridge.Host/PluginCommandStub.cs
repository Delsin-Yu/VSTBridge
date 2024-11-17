using System.Diagnostics;
using Jacobi.Vst.Core;
using Jacobi.Vst.Core.Host;

namespace VSTBridge.Host;

public class PluginContext
{
    private readonly Dictionary<int, float> _pluginParameters = [];

    public void SetParameter(int index, float value)
    {
        _pluginParameters[index] = value;
    }
}

public interface IResizableWindow
{
    void Resize(int width, int height);
}

public class PluginCommandStub(string pluginPath, PluginContext context) : IVstHostCommandStub, IVstHostCommands20
{
    public IResizableWindow? Window { get; set; }
    public IVstPluginContext PluginContext { get; set; }
    public IVstHostCommands20 Commands => this;
    
    public void SetParameterAutomated(int index, float value) => context.SetParameter(index, value);

    public int GetVersion() => 1000;

    public int GetCurrentPluginID() => 0;

    public void ProcessIdle() { }

    public VstTimeInfo GetTimeInfo(VstTimeInfoFlags filterFlags) => null;

    public bool ProcessEvents(VstEvent[] events) => true;

    public bool IoChanged() => false;

    public bool SizeWindow(int width, int height)
    {
        if (Window is null) return false;
        Window.Resize(width, height);
        return true;
    }

    public float GetSampleRate() => 48.0f;

    public int GetBlockSize() => 2048;

    public int GetInputLatency() => 0;

    public int GetOutputLatency() => 0;

    public VstProcessLevels GetProcessLevel() => VstProcessLevels.Unknown;

    public VstAutomationStates GetAutomationState() => VstAutomationStates.ReadWrite;

    public string GetVendorString() => "DE-YU";

    public string GetProductString() => "VST Bridge Host";

    public int GetVendorVersion() => 1000;

    // private static class HostCanDos
    // {
    //     public const string SendVstEvents = "sendVstEvents";
    //     public const string SendVstMidiEvent = "sendVstMidiEvent";
    //     public const string SendVstTimeInfo = "sendVstTimeInfo";
    //     public const string ReceiveVstEvents = "receiveVstEvents";
    //     public const string ReceiveVstMidiEvent = "receiveVstMidiEvent";
    //     public const string ReceiveVstTimeInfo = "receiveVstTimeInfo";
    //     public const string ReportConnectionChanges = "reportConnectionChanges";
    //     public const string AcceptIOChanges = "acceptIOChanges";
    //     public const string SizeWindow = "sizeWindow";
    //     public const string AsyncProcessing = "asyncProcessing";
    //     public const string Offline = "offline";
    //     public const string SupplyIdle = "supplyIdle";
    //     public const string SupportShell = "supportShell";
    //     public const string OpenFileSelector = "openFileSelector";
    //     public const string EditFile = "editFile";
    //     public const string CloseFileSelector = "closeFileSelector";
    //     public const string StartStopProcess = "startStopProcess";
    // }


    public VstCanDoResult CanDo(string cando) => VstCanDoResult.Unknown;
        // cando switch
        // {
        //     HostCanDos.SendVstEvents => VstCanDoResult.No,
        //     HostCanDos.SendVstMidiEvent => VstCanDoResult.Yes,
        //     HostCanDos.SendVstTimeInfo => VstCanDoResult.No,
        //     HostCanDos.ReceiveVstEvents => VstCanDoResult.No,
        //     HostCanDos.ReceiveVstMidiEvent => VstCanDoResult.No,
        //     HostCanDos.ReceiveVstTimeInfo => VstCanDoResult.No,
        //     HostCanDos.ReportConnectionChanges => VstCanDoResult.No,
        //     HostCanDos.AcceptIOChanges => VstCanDoResult.No,
        //     HostCanDos.SizeWindow => VstCanDoResult.No,
        //     HostCanDos.AsyncProcessing => VstCanDoResult.No,
        //     HostCanDos.Offline => VstCanDoResult.No,
        //     HostCanDos.SupplyIdle => VstCanDoResult.No,
        //     HostCanDos.SupportShell => VstCanDoResult.No,
        //     HostCanDos.OpenFileSelector => VstCanDoResult.Yes,
        //     HostCanDos.EditFile => VstCanDoResult.Yes,
        //     HostCanDos.CloseFileSelector => VstCanDoResult.Yes,
        //     HostCanDos.StartStopProcess => VstCanDoResult.No,
        //     _ => VstCanDoResult.Unknown
        // };

    public VstHostLanguage GetLanguage() => VstHostLanguage.English;

    public string GetDirectory() => pluginPath;

    public bool UpdateDisplay() => true;

    public bool BeginEdit(int index) => false;

    public bool EndEdit(int index) => false;

    public bool OpenFileSelector(VstFileSelect fileSelect) => false;

    public bool CloseFileSelector(VstFileSelect fileSelect) => false;
}