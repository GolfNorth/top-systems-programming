namespace Module3.Sample2;

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
        panelTop = new Panel();
        labelCount = new Label();
        numericCount = new NumericUpDown();
        buttonCreate = new Button();
        panelBars = new Panel();

        panelTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericCount).BeginInit();
        SuspendLayout();

        // panelTop
        panelTop.Controls.Add(labelCount);
        panelTop.Controls.Add(numericCount);
        panelTop.Controls.Add(buttonCreate);
        panelTop.Dock = DockStyle.Top;
        panelTop.Height = 50;

        // labelCount
        labelCount.AutoSize = true;
        labelCount.Location = new Point(10, 15);
        labelCount.Text = "Количество:";

        // numericCount
        numericCount.Location = new Point(120, 12);
        numericCount.Size = new Size(70, 31);
        numericCount.Minimum = 1;
        numericCount.Maximum = 50;
        numericCount.Value = 5;

        // buttonCreate
        buttonCreate.Location = new Point(210, 10);
        buttonCreate.Size = new Size(90, 31);
        buttonCreate.Text = "Создать";
        buttonCreate.Click += buttonCreate_Click;

        // panelBars
        panelBars.Dock = DockStyle.Fill;
        panelBars.AutoScroll = true;
        panelBars.Padding = new Padding(10);

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(500, 450);
        Controls.Add(panelBars);
        Controls.Add(panelTop);
        MinimumSize = new Size(400, 300);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 3 — Танцующие прогресс-бары";

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericCount).EndInit();
        ResumeLayout(false);
    }

    private Panel panelTop;
    private Label labelCount;
    private NumericUpDown numericCount;
    private Button buttonCreate;
    private Panel panelBars;
}
