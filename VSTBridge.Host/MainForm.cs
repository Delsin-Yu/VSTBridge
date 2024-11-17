// ReSharper disable LocalizableElement

using Jacobi.Vst.Core;
using Jacobi.Vst.Host.Interop;

namespace VSTBridge.Host;

public partial class MainForm
{
    private readonly Dictionary<VstPluginContext, ListViewItem> _loadedPlugins = [];
    private readonly Dictionary<VstPluginContext, EditorFrame> _pluginWindows = [];
    private readonly AudioServer _audioServer;

    private VstPluginContext? _currentPluginContext;

    public MainForm()
    {
        InitializeComponent();

        _audioServer = new();

        BrowseVstBtn!.Click += (_, _) =>
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "VST(*.dll)|*.dll|VST2(*.vst2)|*.vst2|VST3(*.vst3)|*.vst3";

            if (openFileDialog.ShowDialog(this) != DialogResult.OK) return;

            SelectedPathInput!.Text = openFileDialog.FileName;
        };

        LoadInstanceBtn!.Click += (_, _) =>
        {
            var path = SelectedPathInput!.Text;
            if (!File.Exists(path)) return;

            try
            {
                var commandStub = new PluginCommandStub(path, new());
                var pluginContext = VstPluginContext.Create(path, commandStub);
                pluginContext.PluginCommandStub.Commands.Open();
                pluginContext.Set("PluginPath", path);
                AddPluginListItem(pluginContext);
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    this,
                    e.ToString(),
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
            }
        };

        VstPluginList!.SelectedIndexChanged += (_, _) =>
        {
            if (VstPluginList.SelectedItems.Count == 0) _currentPluginContext = null;
            else _currentPluginContext = (VstPluginContext)VstPluginList.SelectedItems[0].Tag!;
        };

        DeleteInstanceBtn!.Click += (_, _) =>
        {
            if (_currentPluginContext is null) return;
            RemovePluginListItem(_currentPluginContext);
        };

        OpenInstanceWindowBtn!.Click += (_, _) =>
        {
            if (_currentPluginContext is null) return;
            if (!_pluginWindows.TryGetValue(_currentPluginContext, out var window))
            {
                window = new(
                    _currentPluginContext.PluginCommandStub,
                    (PluginCommandStub)_currentPluginContext.HostCommandStub
                );
                _pluginWindows.Add(_currentPluginContext, window);
            }
            window.ShowPluginWindow();
        };

        FormClosed += (_, _) =>
        {
            _audioServer.Dispose();
            foreach (var pluginWindow in _pluginWindows)
            {
                pluginWindow.Value.Close();
                pluginWindow.Value.Dispose();
            }
            foreach (var plugin in _loadedPlugins)
                plugin.Key.Dispose();
            _loadedPlugins.Clear();
        };
    }

    private void AddPluginListItem(VstPluginContext context)
    {
        var commands = context.PluginCommandStub.Commands;
        var item = new ListViewItem(commands.GetEffectName());
        item.SubItems.Add(commands.GetProductString());
        item.SubItems.Add(commands.GetVendorString());
        item.SubItems.Add(commands.GetVendorVersion().ToString());
        item.SubItems.Add(context.Find<string>("PluginPath"));
        item.Tag = context;
        VstPluginList.Items.Add(item);
        _loadedPlugins.Add(context, item);
        StartPlugin(commands);
        _audioServer.Add(context);
    }

    private void RemovePluginListItem(VstPluginContext context)
    {
        using var _ = context;
        if (_pluginWindows.Remove(context, out var window))
        {
            window.Close();
            window.Dispose();
        }
        if (!_loadedPlugins.Remove(context, out var item)) return;
        VstPluginList.Items.Remove(item);
        var commands = context.PluginCommandStub.Commands;
        _audioServer.Remove(context);
        StopPlugin(commands);
    }

    private static void StartPlugin(IVstPluginCommands24 commands)
    {
        commands.SetBlockSize(2048);
        commands.SetSampleRate(4.8f);
        commands.MainsChanged(true);
        commands.StartProcess();
    }

    private static void StopPlugin(IVstPluginCommands24 commands)
    {
        commands.MainsChanged(false);
        commands.StopProcess();
    }
}