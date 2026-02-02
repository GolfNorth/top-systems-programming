namespace Module1.CsWin32;

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
        buttonMessageBox = new Button();
        buttonFindNotepad = new Button();
        buttonSetTitle = new Button();
        labelStatus = new Label();
        SuspendLayout();

        // labelTitle
        labelTitle.Location = new Point(0, 15);
        labelTitle.Size = new Size(400, 40);
        labelTitle.Text = "CsWin32 — автогенерация P/Invoke\n(без ручного DllImport)";
        labelTitle.TextAlign = ContentAlignment.MiddleCenter;

        // buttonMessageBox
        buttonMessageBox.Location = new Point(30, 70);
        buttonMessageBox.Size = new Size(160, 35);
        buttonMessageBox.Text = "MessageBox";
        buttonMessageBox.Click += buttonMessageBox_Click;

        // buttonFindNotepad
        buttonFindNotepad.Location = new Point(210, 70);
        buttonFindNotepad.Size = new Size(160, 35);
        buttonFindNotepad.Text = "Найти Блокнот";
        buttonFindNotepad.Click += buttonFindNotepad_Click;

        // buttonSetTitle
        buttonSetTitle.Location = new Point(120, 115);
        buttonSetTitle.Size = new Size(160, 35);
        buttonSetTitle.Text = "Изменить заголовок";
        buttonSetTitle.Click += buttonSetTitle_Click;

        // labelStatus
        labelStatus.Location = new Point(0, 160);
        labelStatus.Size = new Size(400, 25);
        labelStatus.Text = "Статус: Ожидание";
        labelStatus.TextAlign = ContentAlignment.MiddleCenter;

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 200);
        Controls.Add(labelTitle);
        Controls.Add(buttonMessageBox);
        Controls.Add(buttonFindNotepad);
        Controls.Add(buttonSetTitle);
        Controls.Add(labelStatus);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 1 — CsWin32";
        ResumeLayout(false);
    }

    private Label labelTitle;
    private Button buttonMessageBox;
    private Button buttonFindNotepad;
    private Button buttonSetTitle;
    private Label labelStatus;
}
