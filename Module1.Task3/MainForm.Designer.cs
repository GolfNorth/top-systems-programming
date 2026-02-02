namespace Module1.Task3;

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
        buttonFind = new Button();
        buttonClose = new Button();
        labelStatus = new Label();
        SuspendLayout();

        // labelTitle
        labelTitle.Location = new Point(0, 20);
        labelTitle.Size = new Size(350, 25);
        labelTitle.Text = "Управление окном Блокнота (Notepad)";
        labelTitle.TextAlign = ContentAlignment.MiddleCenter;

        // buttonFind
        buttonFind.Location = new Point(50, 60);
        buttonFind.Size = new Size(120, 35);
        buttonFind.Text = "Найти окно";
        buttonFind.Click += buttonFind_Click;

        // buttonClose
        buttonClose.Location = new Point(180, 60);
        buttonClose.Size = new Size(120, 35);
        buttonClose.Text = "Закрыть окно";
        buttonClose.Click += buttonClose_Click;

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
        Controls.Add(buttonFind);
        Controls.Add(buttonClose);
        Controls.Add(labelStatus);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 1 Задание 3";
        ResumeLayout(false);
    }

    private Label labelTitle;
    private Button buttonFind;
    private Button buttonClose;
    private Label labelStatus;
}
