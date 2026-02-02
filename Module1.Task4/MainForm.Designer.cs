namespace Module1.Task4;

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
        labelTitle = new Label();
        buttonStart = new Button();
        buttonStop = new Button();
        labelStatus = new Label();
        SuspendLayout();

        // labelTitle
        labelTitle.Location = new Point(0, 20);
        labelTitle.Size = new Size(350, 25);
        labelTitle.Text = "Вывод времени в заголовок Блокнота";
        labelTitle.TextAlign = ContentAlignment.MiddleCenter;

        // buttonStart
        buttonStart.Location = new Point(50, 60);
        buttonStart.Size = new Size(120, 35);
        buttonStart.Text = "Запустить";
        buttonStart.Click += buttonStart_Click;

        // buttonStop
        buttonStop.Location = new Point(180, 60);
        buttonStop.Size = new Size(120, 35);
        buttonStop.Text = "Остановить";
        buttonStop.Enabled = false;
        buttonStop.Click += buttonStop_Click;

        // labelStatus
        labelStatus.Location = new Point(0, 110);
        labelStatus.Size = new Size(350, 25);
        labelStatus.Text = "Статус: Ожидание";
        labelStatus.TextAlign = ContentAlignment.MiddleCenter;

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(350, 150);
        Controls.Add(labelTitle);
        Controls.Add(buttonStart);
        Controls.Add(buttonStop);
        Controls.Add(labelStatus);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 1 Задание 4";
        ResumeLayout(false);
    }

    private Label labelTitle;
    private Button buttonStart;
    private Button buttonStop;
    private Label labelStatus;
}
