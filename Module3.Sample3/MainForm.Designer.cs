namespace Module3.Sample3;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        buttonStart = new Button();
        textBoxResult = new TextBox();
        labelStatus = new Label();

        SuspendLayout();

        // buttonStart
        buttonStart.Location = new Point(20, 20);
        buttonStart.Size = new Size(200, 35);
        buttonStart.Text = "Запустить работу";
        buttonStart.Click += buttonStart_Click;

        // textBoxResult
        textBoxResult.Location = new Point(20, 70);
        textBoxResult.Size = new Size(340, 31);
        textBoxResult.ReadOnly = true;

        // labelStatus
        labelStatus.Dock = DockStyle.Bottom;
        labelStatus.Height = 28;
        labelStatus.Text = "  Готов.";
        labelStatus.TextAlign = ContentAlignment.MiddleLeft;
        labelStatus.BorderStyle = BorderStyle.FixedSingle;

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(380, 150);
        Controls.Add(buttonStart);
        Controls.Add(textBoxResult);
        Controls.Add(labelStatus);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 3 — SynchronizationContext";

        ResumeLayout(false);
        PerformLayout();
    }

    private Button buttonStart;
    private TextBox textBoxResult;
    private Label labelStatus;
}
