using System.ComponentModel;
using Jacobi.Vst.Core.Host;

namespace VSTBridge.Host;

/// <summary>
/// The frame in which a custom plugin editor UI is displayed.
/// </summary>
public partial class EditorFrame : Form, IResizableWindow
{
    public EditorFrame(IVstPluginCommandStub pluginCommandStub, PluginCommandStub hostCommandStub)
    {
        InitializeComponent();
        _pluginCommandStub = pluginCommandStub;
        _hostCommandStub = hostCommandStub;
    }

    private readonly IVstPluginCommandStub _pluginCommandStub;
    private readonly PluginCommandStub _hostCommandStub;

    public void ShowPluginWindow()
    {
        if (Visible) return;
        _hostCommandStub.Window = this;

        _pluginCommandStub.Commands.EditorGetRect(out var rect);
        Size = SizeFromClientSize(rect.Size);

        Text = _pluginCommandStub.Commands.GetEffectName();
        _pluginCommandStub.Commands.EditorOpen(Handle);

        Show();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        base.OnClosing(e);
        if (e.Cancel) return;
        _hostCommandStub.Window = null;
        _pluginCommandStub.Commands.EditorClose();
    }

    void IResizableWindow.Resize(int width, int height) => 
        Size = SizeFromClientSize(new(width, height));
}