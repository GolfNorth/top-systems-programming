namespace Module2.Task2;

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
        listViewProcesses = new ListView();
        columnId = new ColumnHeader();
        columnName = new ColumnHeader();
        columnMemory = new ColumnHeader();
        columnThreads = new ColumnHeader();
        panelTop = new Panel();
        labelInterval = new Label();
        numericInterval = new NumericUpDown();
        labelSeconds = new Label();
        buttonStartAuto = new Button();
        buttonStopAuto = new Button();
        buttonRefresh = new Button();
        panelBottom = new Panel();
        labelCount = new Label();
        labelLastUpdate = new Label();
        labelStatus = new Label();
        panelDetails = new Panel();
        labelDetailsTitle = new Label();
        labelPid = new Label();
        labelPidValue = new Label();
        labelName = new Label();
        labelNameValue = new Label();
        labelStartTime = new Label();
        labelStartTimeValue = new Label();
        labelCpuTime = new Label();
        labelCpuTimeValue = new Label();
        labelThreads = new Label();
        labelThreadsValue = new Label();
        labelMemory = new Label();
        labelMemoryValue = new Label();
        labelInstances = new Label();
        labelInstancesValue = new Label();
        labelPriority = new Label();
        labelPriorityValue = new Label();

        panelTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericInterval).BeginInit();
        panelBottom.SuspendLayout();
        panelDetails.SuspendLayout();
        SuspendLayout();

        // listViewProcesses
        listViewProcesses.Columns.AddRange(new ColumnHeader[] { columnId, columnName, columnMemory, columnThreads });
        listViewProcesses.Dock = DockStyle.Fill;
        listViewProcesses.FullRowSelect = true;
        listViewProcesses.GridLines = true;
        listViewProcesses.View = View.Details;
        listViewProcesses.SelectedIndexChanged += listViewProcesses_SelectedIndexChanged;

        // columnId
        columnId.Text = "PID";
        columnId.Width = 60;

        // columnName
        columnName.Text = "Имя процесса";
        columnName.Width = 180;

        // columnMemory
        columnMemory.Text = "Память";
        columnMemory.Width = 80;

        // columnThreads
        columnThreads.Text = "Потоки";
        columnThreads.Width = 60;

        // panelTop
        panelTop.Controls.Add(labelInterval);
        panelTop.Controls.Add(numericInterval);
        panelTop.Controls.Add(labelSeconds);
        panelTop.Controls.Add(buttonStartAuto);
        panelTop.Controls.Add(buttonStopAuto);
        panelTop.Controls.Add(buttonRefresh);
        panelTop.Dock = DockStyle.Top;
        panelTop.Height = 40;

        // labelInterval
        labelInterval.AutoSize = true;
        labelInterval.Location = new Point(10, 10);
        labelInterval.Text = "Интервал:";

        // numericInterval
        numericInterval.Location = new Point(100, 7);
        numericInterval.Minimum = 1;
        numericInterval.Maximum = 60;
        numericInterval.Value = 5;
        numericInterval.Width = 50;

        // labelSeconds
        labelSeconds.AutoSize = true;
        labelSeconds.Location = new Point(155, 10);
        labelSeconds.Text = "сек";

        // buttonStartAuto
        buttonStartAuto.Location = new Point(195, 5);
        buttonStartAuto.Size = new Size(70, 28);
        buttonStartAuto.Text = "Старт";
        buttonStartAuto.Click += buttonStartAuto_Click;

        // buttonStopAuto
        buttonStopAuto.Location = new Point(270, 5);
        buttonStopAuto.Size = new Size(70, 28);
        buttonStopAuto.Text = "Стоп";
        buttonStopAuto.Enabled = false;
        buttonStopAuto.Click += buttonStopAuto_Click;

        // buttonRefresh
        buttonRefresh.Location = new Point(350, 5);
        buttonRefresh.Size = new Size(90, 28);
        buttonRefresh.Text = "Обновить";
        buttonRefresh.Click += buttonRefresh_Click;

        // panelBottom
        panelBottom.Controls.Add(labelCount);
        panelBottom.Controls.Add(labelLastUpdate);
        panelBottom.Controls.Add(labelStatus);
        panelBottom.Dock = DockStyle.Bottom;
        panelBottom.Height = 28;

        // labelCount
        labelCount.AutoSize = true;
        labelCount.Location = new Point(10, 5);
        labelCount.Text = "Процессов: 0";

        // labelLastUpdate
        labelLastUpdate.AutoSize = true;
        labelLastUpdate.Location = new Point(140, 5);
        labelLastUpdate.Text = "Обновлено: —";

        // labelStatus
        labelStatus.AutoSize = true;
        labelStatus.Location = new Point(300, 5);
        labelStatus.Text = "Авто: выкл";

        // panelDetails
        panelDetails.BorderStyle = BorderStyle.FixedSingle;
        panelDetails.Dock = DockStyle.Right;
        panelDetails.Width = 220;
        panelDetails.Padding = new Padding(10);
        panelDetails.Controls.Add(labelDetailsTitle);
        panelDetails.Controls.Add(labelPid);
        panelDetails.Controls.Add(labelPidValue);
        panelDetails.Controls.Add(labelName);
        panelDetails.Controls.Add(labelNameValue);
        panelDetails.Controls.Add(labelStartTime);
        panelDetails.Controls.Add(labelStartTimeValue);
        panelDetails.Controls.Add(labelCpuTime);
        panelDetails.Controls.Add(labelCpuTimeValue);
        panelDetails.Controls.Add(labelThreads);
        panelDetails.Controls.Add(labelThreadsValue);
        panelDetails.Controls.Add(labelMemory);
        panelDetails.Controls.Add(labelMemoryValue);
        panelDetails.Controls.Add(labelInstances);
        panelDetails.Controls.Add(labelInstancesValue);
        panelDetails.Controls.Add(labelPriority);
        panelDetails.Controls.Add(labelPriorityValue);

        // labelDetailsTitle
        labelDetailsTitle.Font = new Font(labelDetailsTitle.Font, FontStyle.Bold);
        labelDetailsTitle.Location = new Point(10, 10);
        labelDetailsTitle.Size = new Size(200, 25);
        labelDetailsTitle.Text = "Детали процесса";

        int y = 45;
        int step = 28;

        // PID
        labelPid.Location = new Point(10, y);
        labelPid.AutoSize = true;
        labelPid.Text = "PID:";
        labelPidValue.Location = new Point(110, y);
        labelPidValue.AutoSize = true;
        labelPidValue.Text = "—";
        y += step;

        // Name
        labelName.Location = new Point(10, y);
        labelName.AutoSize = true;
        labelName.Text = "Имя:";
        labelNameValue.Location = new Point(110, y);
        labelNameValue.AutoSize = true;
        labelNameValue.Text = "—";
        y += step;

        // StartTime
        labelStartTime.Location = new Point(10, y);
        labelStartTime.AutoSize = true;
        labelStartTime.Text = "Запуск:";
        labelStartTimeValue.Location = new Point(110, y);
        labelStartTimeValue.AutoSize = true;
        labelStartTimeValue.Text = "—";
        y += step;

        // CpuTime
        labelCpuTime.Location = new Point(10, y);
        labelCpuTime.AutoSize = true;
        labelCpuTime.Text = "CPU время:";
        labelCpuTimeValue.Location = new Point(110, y);
        labelCpuTimeValue.AutoSize = true;
        labelCpuTimeValue.Text = "—";
        y += step;

        // Threads
        labelThreads.Location = new Point(10, y);
        labelThreads.AutoSize = true;
        labelThreads.Text = "Потоков:";
        labelThreadsValue.Location = new Point(110, y);
        labelThreadsValue.AutoSize = true;
        labelThreadsValue.Text = "—";
        y += step;

        // Memory
        labelMemory.Location = new Point(10, y);
        labelMemory.AutoSize = true;
        labelMemory.Text = "Память:";
        labelMemoryValue.Location = new Point(110, y);
        labelMemoryValue.AutoSize = true;
        labelMemoryValue.Text = "—";
        y += step;

        // Instances
        labelInstances.Location = new Point(10, y);
        labelInstances.AutoSize = true;
        labelInstances.Text = "Копий:";
        labelInstancesValue.Location = new Point(110, y);
        labelInstancesValue.AutoSize = true;
        labelInstancesValue.Text = "—";
        y += step;

        // Priority
        labelPriority.Location = new Point(10, y);
        labelPriority.AutoSize = true;
        labelPriority.Text = "Приоритет:";
        labelPriorityValue.Location = new Point(110, y);
        labelPriorityValue.AutoSize = true;
        labelPriorityValue.Text = "—";

        // MainForm
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 450);
        Controls.Add(listViewProcesses);
        Controls.Add(panelDetails);
        Controls.Add(panelTop);
        Controls.Add(panelBottom);
        MinimumSize = new Size(600, 350);
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Модуль 2 Задание 2 — Детали процесса";

        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericInterval).EndInit();
        panelBottom.ResumeLayout(false);
        panelBottom.PerformLayout();
        panelDetails.ResumeLayout(false);
        panelDetails.PerformLayout();
        ResumeLayout(false);
    }

    private ListView listViewProcesses;
    private ColumnHeader columnId;
    private ColumnHeader columnName;
    private ColumnHeader columnMemory;
    private ColumnHeader columnThreads;
    private Panel panelTop;
    private Label labelInterval;
    private NumericUpDown numericInterval;
    private Label labelSeconds;
    private Button buttonStartAuto;
    private Button buttonStopAuto;
    private Button buttonRefresh;
    private Panel panelBottom;
    private Label labelCount;
    private Label labelLastUpdate;
    private Label labelStatus;
    private Panel panelDetails;
    private Label labelDetailsTitle;
    private Label labelPid;
    private Label labelPidValue;
    private Label labelName;
    private Label labelNameValue;
    private Label labelStartTime;
    private Label labelStartTimeValue;
    private Label labelCpuTime;
    private Label labelCpuTimeValue;
    private Label labelThreads;
    private Label labelThreadsValue;
    private Label labelMemory;
    private Label labelMemoryValue;
    private Label labelInstances;
    private Label labelInstancesValue;
    private Label labelPriority;
    private Label labelPriorityValue;
}
