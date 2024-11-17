namespace VSTBridge.Client;

public partial class PluginEditorView : UserControl
{
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        MainContainer = new System.Windows.Forms.TableLayoutPanel();
        CurrentStatusLabel = new System.Windows.Forms.Label();
        DoConnectBtn = new System.Windows.Forms.Button();
        MainContainer.SuspendLayout();
        SuspendLayout();
        // 
        // MainContainer
        // 
        MainContainer.ColumnCount = 1;
        MainContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        MainContainer.Controls.Add(CurrentStatusLabel, 0, 0);
        MainContainer.Controls.Add(DoConnectBtn, 0, 1);
        MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        MainContainer.Location = new System.Drawing.Point(0, 0);
        MainContainer.Name = "MainContainer";
        MainContainer.RowCount = 2;
        MainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
        MainContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        MainContainer.Size = new System.Drawing.Size(150, 150);
        MainContainer.TabIndex = 0;
        // 
        // CurrentStatusLabel
        // 
        CurrentStatusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        CurrentStatusLabel.Font = new System.Drawing.Font("Times New Roman", 10.5F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point, ((byte)0));
        CurrentStatusLabel.Location = new System.Drawing.Point(3, 3);
        CurrentStatusLabel.Margin = new System.Windows.Forms.Padding(3);
        CurrentStatusLabel.Name = "CurrentStatusLabel";
        CurrentStatusLabel.Size = new System.Drawing.Size(144, 23);
        CurrentStatusLabel.TabIndex = 0;
        CurrentStatusLabel.Text = "Status Display";
        CurrentStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // DoConnectBtn
        // 
        DoConnectBtn.Dock = System.Windows.Forms.DockStyle.Fill;
        DoConnectBtn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        DoConnectBtn.Location = new System.Drawing.Point(3, 32);
        DoConnectBtn.Name = "DoConnectBtn";
        DoConnectBtn.Size = new System.Drawing.Size(144, 115);
        DoConnectBtn.TabIndex = 1;
        DoConnectBtn.Text = "Connect";
        DoConnectBtn.UseVisualStyleBackColor = true;
        // 
        // PluginEditorView
        // 
        Controls.Add(MainContainer);
        MainContainer.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.TableLayoutPanel MainContainer;
    private System.Windows.Forms.Label CurrentStatusLabel;
    private System.Windows.Forms.Button DoConnectBtn;
}