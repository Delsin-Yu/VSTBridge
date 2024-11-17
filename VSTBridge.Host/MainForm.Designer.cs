#nullable enable
namespace VSTBridge.Host;

public partial class MainForm : Form
{
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
        CurrentStatusLabel = new System.Windows.Forms.Label();
        DoConnectBtn = new System.Windows.Forms.Button();
        tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
        SelectedPathInput = new System.Windows.Forms.TextBox();
        BrowseVstBtn = new System.Windows.Forms.Button();
        LoadInstanceBtn = new System.Windows.Forms.Button();
        VstPluginList = new System.Windows.Forms.ListView();
        NameHdr = new System.Windows.Forms.ColumnHeader();
        ProductHdr = new System.Windows.Forms.ColumnHeader();
        VendorHdr = new System.Windows.Forms.ColumnHeader();
        VersionHdr = new System.Windows.Forms.ColumnHeader();
        AssemblyHdr = new System.Windows.Forms.ColumnHeader();
        tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
        DeleteInstanceBtn = new System.Windows.Forms.Button();
        OpenInstanceWindowBtn = new System.Windows.Forms.Button();
        tableLayoutPanel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        tableLayoutPanel3.SuspendLayout();
        tableLayoutPanel4.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.AutoSize = true;
        tableLayoutPanel1.ColumnCount = 1;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
        tableLayoutPanel1.Controls.Add(VstPluginList, 0, 2);
        tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel1.Location = new System.Drawing.Point(8, 11);
        tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 4;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tableLayoutPanel1.Size = new System.Drawing.Size(598, 389);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // tableLayoutPanel2
        // 
        tableLayoutPanel2.AutoSize = true;
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tableLayoutPanel2.Controls.Add(CurrentStatusLabel, 0, 0);
        tableLayoutPanel2.Controls.Add(DoConnectBtn, 1, 0);
        tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
        tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 1;
        tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
        tableLayoutPanel2.Size = new System.Drawing.Size(591, 40);
        tableLayoutPanel2.TabIndex = 1;
        // 
        // CurrentStatusLabel
        // 
        CurrentStatusLabel.AutoSize = true;
        CurrentStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        CurrentStatusLabel.Font = new System.Drawing.Font("Times New Roman", 15.5F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)));
        CurrentStatusLabel.Location = new System.Drawing.Point(3, 3);
        CurrentStatusLabel.Margin = new System.Windows.Forms.Padding(3);
        CurrentStatusLabel.Name = "CurrentStatusLabel";
        CurrentStatusLabel.Size = new System.Drawing.Size(490, 34);
        CurrentStatusLabel.TabIndex = 0;
        CurrentStatusLabel.Text = "Connection Status";
        CurrentStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // DoConnectBtn
        // 
        DoConnectBtn.AutoSize = true;
        DoConnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        DoConnectBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
        DoConnectBtn.Location = new System.Drawing.Point(496, 0);
        DoConnectBtn.Margin = new System.Windows.Forms.Padding(0);
        DoConnectBtn.Name = "DoConnectBtn";
        DoConnectBtn.Size = new System.Drawing.Size(95, 40);
        DoConnectBtn.TabIndex = 1;
        DoConnectBtn.Text = "Connect";
        DoConnectBtn.UseVisualStyleBackColor = true;
        // 
        // tableLayoutPanel3
        // 
        tableLayoutPanel3.AutoSize = true;
        tableLayoutPanel3.ColumnCount = 3;
        tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tableLayoutPanel3.Controls.Add(SelectedPathInput, 0, 0);
        tableLayoutPanel3.Controls.Add(BrowseVstBtn, 1, 0);
        tableLayoutPanel3.Controls.Add(LoadInstanceBtn, 2, 0);
        tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel3.Location = new System.Drawing.Point(3, 49);
        tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
        tableLayoutPanel3.Name = "tableLayoutPanel3";
        tableLayoutPanel3.RowCount = 1;
        tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel3.Size = new System.Drawing.Size(591, 35);
        tableLayoutPanel3.TabIndex = 2;
        // 
        // SelectedPathInput
        // 
        SelectedPathInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right));
        SelectedPathInput.Location = new System.Drawing.Point(3, 6);
        SelectedPathInput.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
        SelectedPathInput.Name = "SelectedPathInput";
        SelectedPathInput.Size = new System.Drawing.Size(390, 23);
        SelectedPathInput.TabIndex = 0;
        // 
        // BrowseVstBtn
        // 
        BrowseVstBtn.AutoSize = true;
        BrowseVstBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        BrowseVstBtn.Font = new System.Drawing.Font("Times New Roman", 10F);
        BrowseVstBtn.Location = new System.Drawing.Point(400, 0);
        BrowseVstBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        BrowseVstBtn.Name = "BrowseVstBtn";
        BrowseVstBtn.Size = new System.Drawing.Size(83, 35);
        BrowseVstBtn.TabIndex = 1;
        BrowseVstBtn.Text = "Browse Vst";
        BrowseVstBtn.UseVisualStyleBackColor = true;
        // 
        // LoadInstanceBtn
        // 
        LoadInstanceBtn.AutoSize = true;
        LoadInstanceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        LoadInstanceBtn.Font = new System.Drawing.Font("Times New Roman", 10F);
        LoadInstanceBtn.Location = new System.Drawing.Point(487, 0);
        LoadInstanceBtn.Margin = new System.Windows.Forms.Padding(0);
        LoadInstanceBtn.Name = "LoadInstanceBtn";
        LoadInstanceBtn.Size = new System.Drawing.Size(104, 35);
        LoadInstanceBtn.TabIndex = 2;
        LoadInstanceBtn.Text = "Load Instance";
        LoadInstanceBtn.UseVisualStyleBackColor = true;
        // 
        // VstPluginList
        // 
        VstPluginList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { NameHdr, ProductHdr, VendorHdr, VersionHdr, AssemblyHdr });
        VstPluginList.Dock = System.Windows.Forms.DockStyle.Fill;
        VstPluginList.FullRowSelect = true;
        VstPluginList.Location = new System.Drawing.Point(6, 90);
        VstPluginList.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
        VstPluginList.MultiSelect = false;
        VstPluginList.Name = "VstPluginList";
        VstPluginList.Size = new System.Drawing.Size(588, 258);
        VstPluginList.TabIndex = 3;
        VstPluginList.UseCompatibleStateImageBehavior = false;
        VstPluginList.View = System.Windows.Forms.View.Details;
        // 
        // NameHdr
        // 
        NameHdr.Name = "NameHdr";
        NameHdr.Text = "Name";
        NameHdr.Width = 120;
        // 
        // ProductHdr
        // 
        ProductHdr.DisplayIndex = 2;
        ProductHdr.Name = "ProductHdr";
        ProductHdr.Text = "Product";
        ProductHdr.Width = 120;
        // 
        // VendorHdr
        // 
        VendorHdr.DisplayIndex = 3;
        VendorHdr.Name = "VendorHdr";
        VendorHdr.Text = "Vendor";
        VendorHdr.Width = 120;
        // 
        // VersionHdr
        // 
        VersionHdr.DisplayIndex = 1;
        VersionHdr.Name = "VersionHdr";
        VersionHdr.Text = "Version";
        // 
        // AssemblyHdr
        // 
        AssemblyHdr.Name = "AssemblyHdr";
        AssemblyHdr.Text = "Assemlby";
        AssemblyHdr.Width = 164;
        // 
        // tableLayoutPanel4
        // 
        tableLayoutPanel4.AutoSize = true;
        tableLayoutPanel4.ColumnCount = 3;
        tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
        tableLayoutPanel4.Controls.Add(DeleteInstanceBtn, 1, 0);
        tableLayoutPanel4.Controls.Add(OpenInstanceWindowBtn, 2, 0);
        tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
        tableLayoutPanel4.Location = new System.Drawing.Point(3, 354);
        tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 3, 6, 3);
        tableLayoutPanel4.Name = "tableLayoutPanel4";
        tableLayoutPanel4.RowCount = 1;
        tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        tableLayoutPanel4.Size = new System.Drawing.Size(591, 32);
        tableLayoutPanel4.TabIndex = 4;
        // 
        // DeleteInstanceBtn
        // 
        DeleteInstanceBtn.AutoSize = true;
        DeleteInstanceBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        DeleteInstanceBtn.Font = new System.Drawing.Font("Times New Roman", 10F);
        DeleteInstanceBtn.Location = new System.Drawing.Point(334, 0);
        DeleteInstanceBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        DeleteInstanceBtn.Name = "DeleteInstanceBtn";
        DeleteInstanceBtn.Size = new System.Drawing.Size(107, 32);
        DeleteInstanceBtn.TabIndex = 0;
        DeleteInstanceBtn.Text = "Delete Instance";
        DeleteInstanceBtn.UseVisualStyleBackColor = true;
        // 
        // OpenInstanceWindowBtn
        // 
        OpenInstanceWindowBtn.AutoSize = true;
        OpenInstanceWindowBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        OpenInstanceWindowBtn.Font = new System.Drawing.Font("Times New Roman", 10F);
        OpenInstanceWindowBtn.Location = new System.Drawing.Point(445, 0);
        OpenInstanceWindowBtn.Margin = new System.Windows.Forms.Padding(0);
        OpenInstanceWindowBtn.Name = "OpenInstanceWindowBtn";
        OpenInstanceWindowBtn.Size = new System.Drawing.Size(146, 32);
        OpenInstanceWindowBtn.TabIndex = 1;
        OpenInstanceWindowBtn.Text = "Open Instace Window";
        OpenInstanceWindowBtn.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        AutoSize = true;
        ClientSize = new System.Drawing.Size(614, 411);
        Controls.Add(tableLayoutPanel1);
        Font = new System.Drawing.Font("Times New Roman", 10F);
        MinimumSize = new System.Drawing.Size(630, 450);
        Padding = new System.Windows.Forms.Padding(8, 11, 8, 11);
        ShowIcon = false;
        Text = "VST Bridge Host";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel2.PerformLayout();
        tableLayoutPanel3.ResumeLayout(false);
        tableLayoutPanel3.PerformLayout();
        tableLayoutPanel4.ResumeLayout(false);
        tableLayoutPanel4.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ListView VstPluginList;
    private System.Windows.Forms.ColumnHeader NameHdr = null!;
    private System.Windows.Forms.ColumnHeader VersionHdr = null!;
    private System.Windows.Forms.ColumnHeader ProductHdr = null!;
    private System.Windows.Forms.ColumnHeader VendorHdr = null!;
    private System.Windows.Forms.ColumnHeader AssemblyHdr = null!;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4 = null!;
    private System.Windows.Forms.Button DeleteInstanceBtn;
    private System.Windows.Forms.Button OpenInstanceWindowBtn;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3 = null!;
    private System.Windows.Forms.TextBox SelectedPathInput = null!;
    private System.Windows.Forms.Button BrowseVstBtn;
    private System.Windows.Forms.Button LoadInstanceBtn;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1 = null!;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2 = null!;
    private System.Windows.Forms.Label CurrentStatusLabel = null!;
    private System.Windows.Forms.Button DoConnectBtn = null!;
}