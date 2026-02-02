namespace Module2.Task1;

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

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        listViewProcesses = new System.Windows.Forms.ListView();
        columnId = new System.Windows.Forms.ColumnHeader();
        columnName = new System.Windows.Forms.ColumnHeader();
        columnMemory = new System.Windows.Forms.ColumnHeader();
        columnStartTime = new System.Windows.Forms.ColumnHeader();
        panelTop = new System.Windows.Forms.Panel();
        labelInterval = new System.Windows.Forms.Label();
        numericInterval = new System.Windows.Forms.NumericUpDown();
        labelSeconds = new System.Windows.Forms.Label();
        buttonStartAuto = new System.Windows.Forms.Button();
        buttonStopAuto = new System.Windows.Forms.Button();
        buttonRefresh = new System.Windows.Forms.Button();
        panelBottom = new System.Windows.Forms.Panel();
        labelCount = new System.Windows.Forms.Label();
        labelLastUpdate = new System.Windows.Forms.Label();
        labelStatus = new System.Windows.Forms.Label();
        panelTop.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numericInterval).BeginInit();
        panelBottom.SuspendLayout();
        SuspendLayout();
        // 
        // listViewProcesses
        // 
        listViewProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnId, columnName, columnMemory, columnStartTime });
        listViewProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
        listViewProcesses.FullRowSelect = true;
        listViewProcesses.GridLines = true;
        listViewProcesses.Location = new System.Drawing.Point(0, 45);
        listViewProcesses.Name = "listViewProcesses";
        listViewProcesses.Size = new System.Drawing.Size(600, 375);
        listViewProcesses.TabIndex = 0;
        listViewProcesses.UseCompatibleStateImageBehavior = false;
        listViewProcesses.View = System.Windows.Forms.View.Details;
        // 
        // columnId
        // 
        columnId.Name = "columnId";
        columnId.Text = "PID";
        columnId.Width = 70;
        // 
        // columnName
        // 
        columnName.Name = "columnName";
        columnName.Text = "Имя процесса";
        columnName.Width = 340;
        // 
        // columnMemory
        // 
        columnMemory.Name = "columnMemory";
        columnMemory.Text = "Память";
        columnMemory.Width = 100;
        // 
        // columnStartTime
        // 
        columnStartTime.Name = "columnStartTime";
        columnStartTime.Text = "Запуск";
        columnStartTime.Width = 80;
        // 
        // panelTop
        // 
        panelTop.Controls.Add(labelInterval);
        panelTop.Controls.Add(numericInterval);
        panelTop.Controls.Add(labelSeconds);
        panelTop.Controls.Add(buttonStartAuto);
        panelTop.Controls.Add(buttonStopAuto);
        panelTop.Controls.Add(buttonRefresh);
        panelTop.Dock = System.Windows.Forms.DockStyle.Top;
        panelTop.Location = new System.Drawing.Point(0, 0);
        panelTop.Name = "panelTop";
        panelTop.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
        panelTop.Size = new System.Drawing.Size(600, 45);
        panelTop.TabIndex = 1;
        // 
        // labelInterval
        // 
        labelInterval.AutoSize = true;
        labelInterval.Location = new System.Drawing.Point(10, 12);
        labelInterval.Name = "labelInterval";
        labelInterval.Size = new System.Drawing.Size(94, 25);
        labelInterval.TabIndex = 0;
        labelInterval.Text = "Интервал:";
        // 
        // numericInterval
        // 
        numericInterval.Location = new System.Drawing.Point(100, 9);
        numericInterval.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
        numericInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        numericInterval.Name = "numericInterval";
        numericInterval.Size = new System.Drawing.Size(60, 31);
        numericInterval.TabIndex = 1;
        numericInterval.Value = new decimal(new int[] { 5, 0, 0, 0 });
        // 
        // labelSeconds
        // 
        labelSeconds.AutoSize = true;
        labelSeconds.Location = new System.Drawing.Point(165, 12);
        labelSeconds.Name = "labelSeconds";
        labelSeconds.Size = new System.Drawing.Size(38, 25);
        labelSeconds.TabIndex = 2;
        labelSeconds.Text = "сек";
        // 
        // buttonStartAuto
        // 
        buttonStartAuto.Location = new System.Drawing.Point(210, 7);
        buttonStartAuto.Name = "buttonStartAuto";
        buttonStartAuto.Size = new System.Drawing.Size(80, 28);
        buttonStartAuto.TabIndex = 3;
        buttonStartAuto.Text = "Старт";
        buttonStartAuto.Click += buttonStartAuto_Click;
        // 
        // buttonStopAuto
        // 
        buttonStopAuto.Enabled = false;
        buttonStopAuto.Location = new System.Drawing.Point(295, 7);
        buttonStopAuto.Name = "buttonStopAuto";
        buttonStopAuto.Size = new System.Drawing.Size(80, 28);
        buttonStopAuto.TabIndex = 4;
        buttonStopAuto.Text = "Стоп";
        buttonStopAuto.Click += buttonStopAuto_Click;
        // 
        // buttonRefresh
        // 
        buttonRefresh.Location = new System.Drawing.Point(390, 7);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new System.Drawing.Size(100, 28);
        buttonRefresh.TabIndex = 5;
        buttonRefresh.Text = "Обновить";
        buttonRefresh.Click += buttonRefresh_Click;
        // 
        // panelBottom
        // 
        panelBottom.Controls.Add(labelCount);
        panelBottom.Controls.Add(labelLastUpdate);
        panelBottom.Controls.Add(labelStatus);
        panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        panelBottom.Location = new System.Drawing.Point(0, 420);
        panelBottom.Name = "panelBottom";
        panelBottom.Size = new System.Drawing.Size(600, 30);
        panelBottom.TabIndex = 2;
        // 
        // labelCount
        // 
        labelCount.AutoSize = true;
        labelCount.Location = new System.Drawing.Point(10, 7);
        labelCount.Name = "labelCount";
        labelCount.Size = new System.Drawing.Size(123, 25);
        labelCount.TabIndex = 0;
        labelCount.Text = "Процессов: 0";
        // 
        // labelLastUpdate
        // 
        labelLastUpdate.AutoSize = true;
        labelLastUpdate.Location = new System.Drawing.Point(150, 7);
        labelLastUpdate.Name = "labelLastUpdate";
        labelLastUpdate.Size = new System.Drawing.Size(133, 25);
        labelLastUpdate.TabIndex = 1;
        labelLastUpdate.Text = "Обновлено: —";
        // 
        // labelStatus
        // 
        labelStatus.AutoSize = true;
        labelStatus.Location = new System.Drawing.Point(320, 7);
        labelStatus.Name = "labelStatus";
        labelStatus.Size = new System.Drawing.Size(256, 25);
        labelStatus.TabIndex = 2;
        labelStatus.Text = "Автообновление: выключено";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(600, 450);
        Controls.Add(listViewProcesses);
        Controls.Add(panelTop);
        Controls.Add(panelBottom);
        MinimumSize = new System.Drawing.Size(500, 300);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Модуль 2 Задание 1 — Список процессов";
        panelTop.ResumeLayout(false);
        panelTop.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numericInterval).EndInit();
        panelBottom.ResumeLayout(false);
        panelBottom.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListView listViewProcesses;
    private ColumnHeader columnId;
    private System.Windows.Forms.ColumnHeader columnName;
    private ColumnHeader columnMemory;
    private ColumnHeader columnStartTime;
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
}
