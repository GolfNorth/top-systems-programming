namespace Module2.Task4;

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
        groupBoxStandard = new GroupBox();
        buttonNotepad = new Button();
        buttonCalc = new Button();
        buttonPaint = new Button();
        groupBoxCustom = new GroupBox();
        textBoxCustomPath = new TextBox();
        buttonBrowse = new Button();
        buttonLaunchCustom = new Button();
        groupBoxLog = new GroupBox();
        listBoxLog = new ListBox();

        groupBoxStandard.SuspendLayout();
        groupBoxCustom.SuspendLayout();
        groupBoxLog.SuspendLayout();
        SuspendLayout();

        // groupBoxStandard
        groupBoxStandard.Controls.Add(buttonNotepad);
        groupBoxStandard.Controls.Add(buttonCalc);
        groupBoxStandard.Controls.Add(buttonPaint);
        groupBoxStandard.Location = new Point(15, 15);
        groupBoxStandard.Size = new Size(360, 80);
        groupBoxStandard.Text = "Стандартные приложения";

        // buttonNotepad
        buttonNotepad.Location = new Point(15, 30);
        buttonNotepad.Size = new Size(100, 35);
        buttonNotepad.Text = "Блокнот";
        buttonNotepad.Click += buttonNotepad_Click;

        // buttonCalc
        buttonCalc.Location = new Point(125, 30);
        buttonCalc.Size = new Size(110, 35);
        buttonCalc.Text = "Калькулятор";
        buttonCalc.Click += buttonCalc_Click;

        // buttonPaint
        buttonPaint.Location = new Point(245, 30);
        buttonPaint.Size = new Size(100, 35);
        buttonPaint.Text = "Paint";
        buttonPaint.Click += buttonPaint_Click;

        // groupBoxCustom
        groupBoxCustom.Controls.Add(textBoxCustomPath);
        groupBoxCustom.Controls.Add(buttonBrowse);
        groupBoxCustom.Controls.Add(buttonLaunchCustom);
        groupBoxCustom.Location = new Point(15, 105);
        groupBoxCustom.Size = new Size(360, 85);
        groupBoxCustom.Text = "Своё приложение";

        // textBoxCustomPath
        textBoxCustomPath.Location = new Point(15, 30);
        textBoxCustomPath.Size = new Size(250, 31);
        textBoxCustomPath.PlaceholderText = "Путь к .exe файлу...";

        // buttonBrowse
        buttonBrowse.Location = new Point(275, 28);
        buttonBrowse.Size = new Size(70, 31);
        buttonBrowse.Text = "Обзор";
        buttonBrowse.Click += buttonBrowse_Click;

        // buttonLaunchCustom
        buttonLaunchCustom.Location = new Point(125, 70);
        buttonLaunchCustom.Size = new Size(110, 35);
        buttonLaunchCustom.Text = "Запустить";
        buttonLaunchCustom.Anchor = AnchorStyles.None;
        buttonLaunchCustom.Click += buttonLaunchCustom_Click;

        // groupBoxLog
        groupBoxLog.Controls.Add(listBoxLog);
        groupBoxLog.Location = new Point(15, 200);
        groupBoxLog.Size = new Size(360, 150);
        groupBoxLog.Text = "Журнал запусков";

        // listBoxLog
        listBoxLog.Dock = DockStyle.Fill;
        listBoxLog.IntegralHeight = false;

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(390, 365);
        Controls.Add(groupBoxStandard);
        Controls.Add(groupBoxCustom);
        Controls.Add(groupBoxLog);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 2 Задание 4 — Запуск приложений";

        groupBoxStandard.ResumeLayout(false);
        groupBoxCustom.ResumeLayout(false);
        groupBoxCustom.PerformLayout();
        groupBoxLog.ResumeLayout(false);
        ResumeLayout(false);
    }

    private GroupBox groupBoxStandard;
    private Button buttonNotepad;
    private Button buttonCalc;
    private Button buttonPaint;
    private GroupBox groupBoxCustom;
    private TextBox textBoxCustomPath;
    private Button buttonBrowse;
    private Button buttonLaunchCustom;
    private GroupBox groupBoxLog;
    private ListBox listBoxLog;
}
