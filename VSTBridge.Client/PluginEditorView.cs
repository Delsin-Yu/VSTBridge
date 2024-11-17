// ReSharper disable LocalizableElement
namespace VSTBridge.Client;

public partial class PluginEditorView
{
    public PluginEditorView() => InitializeComponent();

    public void Initialize(Action onClick) => 
        DoConnectBtn.Click += (_, _) => onClick();

    public void UpdateContext(PluginEditor.Context context) => 
        (DoConnectBtn.Enabled, CurrentStatusLabel.Text) = context;

}