namespace Module3.Sample1;

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
        labelDirectory = new Label();
        textBoxDirectory = new TextBox();
        buttonBrowse = new Button();
        labelWord = new Label();
        textBoxWord = new TextBox();
        buttonSearch = new Button();
        buttonCancel = new Button();
        labelModel = new Label();
        radioApm = new RadioButton();
        radioEap = new RadioButton();
        listViewResults = new ListView();
        columnFileName = new ColumnHeader();
        columnFilePath = new ColumnHeader();
        columnCount = new ColumnHeader();
        progressBar = new ProgressBar();
        labelStatus = new Label();

        panelTop.SuspendLayout();
        SuspendLayout();

        // panelTop
        panelTop.Controls.Add(labelDirectory);
        panelTop.Controls.Add(textBoxDirectory);
        panelTop.Controls.Add(buttonBrowse);
        panelTop.Controls.Add(labelWord);
        panelTop.Controls.Add(textBoxWord);
        panelTop.Controls.Add(buttonSearch);
        panelTop.Controls.Add(buttonCancel);
        panelTop.Controls.Add(labelModel);
        panelTop.Controls.Add(radioApm);
        panelTop.Controls.Add(radioEap);
        panelTop.Dock = DockStyle.Top;
        panelTop.Height = 115;

        // labelDirectory
        labelDirectory.AutoSize = true;
        labelDirectory.Location = new Point(10, 12);
        labelDirectory.Text = "Папка:";

        // textBoxDirectory
        textBoxDirectory.Location = new Point(75, 9);
        textBoxDirectory.Size = new Size(410, 31);

        // buttonBrowse
        buttonBrowse.Location = new Point(490, 7);
        buttonBrowse.Size = new Size(70, 31);
        buttonBrowse.Text = "Обзор";
        buttonBrowse.Click += buttonBrowse_Click;

        // labelWord
        labelWord.AutoSize = true;
        labelWord.Location = new Point(10, 48);
        labelWord.Text = "Слово:";

        // textBoxWord
        textBoxWord.Location = new Point(75, 45);
        textBoxWord.Size = new Size(200, 31);

        // buttonSearch
        buttonSearch.Location = new Point(290, 43);
        buttonSearch.Size = new Size(90, 31);
        buttonSearch.Text = "Найти";
        buttonSearch.Click += buttonSearch_Click;

        // buttonCancel
        buttonCancel.Location = new Point(385, 43);
        buttonCancel.Size = new Size(90, 31);
        buttonCancel.Text = "Отмена";
        buttonCancel.Enabled = false;
        buttonCancel.Click += buttonCancel_Click;

        // labelModel
        labelModel.AutoSize = true;
        labelModel.Location = new Point(10, 84);
        labelModel.Text = "Модель:";

        // radioApm
        radioApm.AutoSize = true;
        radioApm.Location = new Point(85, 82);
        radioApm.Text = "APM (Begin/End)";
        radioApm.Checked = true;

        // radioEap
        radioEap.AutoSize = true;
        radioEap.Location = new Point(260, 82);
        radioEap.Text = "EAP (события)";

        // listViewResults
        listViewResults.Columns.AddRange(new ColumnHeader[] { columnFileName, columnFilePath, columnCount });
        listViewResults.Dock = DockStyle.Fill;
        listViewResults.FullRowSelect = true;
        listViewResults.GridLines = true;
        listViewResults.View = View.Details;

        // columnFileName
        columnFileName.Text = "Файл";
        columnFileName.Width = 150;

        // columnFilePath
        columnFilePath.Text = "Путь";
        columnFilePath.Width = 320;

        // columnCount
        columnCount.Text = "Вхождений";
        columnCount.Width = 90;

        // progressBar
        progressBar.Dock = DockStyle.Bottom;
        progressBar.Height = 23;
        progressBar.Minimum = 0;
        progressBar.Maximum = 100;

        // labelStatus
        labelStatus.Dock = DockStyle.Bottom;
        labelStatus.Height = 28;
        labelStatus.Text = "  Готов к поиску.";
        labelStatus.TextAlign = ContentAlignment.MiddleLeft;
        labelStatus.BorderStyle = BorderStyle.FixedSingle;

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(580, 430);
        Controls.Add(listViewResults);
        Controls.Add(panelTop);
        Controls.Add(progressBar);
        Controls.Add(labelStatus);
        MinimumSize = new Size(500, 380);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 3 — Поиск слова в файлах";

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        ResumeLayout(false);
    }

    private Panel panelTop;
    private Label labelDirectory;
    private TextBox textBoxDirectory;
    private Button buttonBrowse;
    private Label labelWord;
    private TextBox textBoxWord;
    private Button buttonSearch;
    private Button buttonCancel;
    private Label labelModel;
    private RadioButton radioApm;
    private RadioButton radioEap;
    private ListView listViewResults;
    private ColumnHeader columnFileName;
    private ColumnHeader columnFilePath;
    private ColumnHeader columnCount;
    private ProgressBar progressBar;
    private Label labelStatus;
}
