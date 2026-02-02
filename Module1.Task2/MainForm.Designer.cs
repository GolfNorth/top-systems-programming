namespace Module1.Task2;

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
        labelInstruction = new Label();
        buttonStart = new Button();
        SuspendLayout();

        // labelInstruction
        labelInstruction.Location = new Point(0, 40);
        labelInstruction.Size = new Size(300, 50);
        labelInstruction.Text = "Загадайте число от 0 до 100,\nа компьютер попробует угадать!";
        labelInstruction.TextAlign = ContentAlignment.MiddleCenter;

        // buttonStart
        buttonStart.Location = new Point(70, 110);
        buttonStart.Size = new Size(160, 40);
        buttonStart.Text = "Начать игру";
        buttonStart.Click += buttonStart_Click;

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(300, 180);
        Controls.Add(labelInstruction);
        Controls.Add(buttonStart);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 1 Задание 2";
        ResumeLayout(false);
    }

    private Label labelInstruction;
    private Button buttonStart;
}
