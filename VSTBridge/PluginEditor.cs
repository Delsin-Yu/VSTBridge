using Jacobi.Vst.Core;
using Jacobi.Vst.Plugin.Framework;
using Jacobi.Vst.Plugin.Framework.Common;

namespace VSTBridge.Client;

public class PluginEditor : IVstPluginEditor
{
    private readonly WinFormsControlWrapper<PluginEditorView> _view = new();
    private Context _currentContext;
    private readonly ConnectionManager _connectionManager;
    
    public PluginEditor(ConnectionManager connectionManager)
    {
        _connectionManager = connectionManager;
        Reset();
    }

    public Rectangle Bounds => _view.Bounds;

    private Context CurrentContext
    {
        set
        {
            _currentContext = value;
            _view.Instance?.UpdateContext(_currentContext);
        }
    }

    public void Open(IntPtr hWnd)
    {
        _view.SafeInstance.Initialize(ConnectToServer);
        CurrentContext = _currentContext;
        _view.Open(hWnd);
    }

    private void ConnectToServer()
    {
        CurrentContext = new(false, "Awaiting for Connection...");
        _connectionManager
            .ConnectAsync(Reset)
            .GetAwaiter()
            .OnCompleted(() => CurrentContext = new(false, "Connected"));
    }
    
    private void Reset() => CurrentContext = new(true, "Idle");


    public record struct Context(bool IsButtonEnabled, string CurrentText);

    public void Close() => _view.Close();

    public void ProcessIdle() { }

    public bool KeyDown(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers) => false;

    public bool KeyUp(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers) => false;

    public VstKnobMode KnobMode { get; set; }


}