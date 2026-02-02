namespace Module1.Task1;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        buttonShowMessage = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // buttonShowMessage
        // 
        buttonShowMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
        buttonShowMessage.Location = new System.Drawing.Point(160, 140);
        buttonShowMessage.Name = "buttonShowMessage";
        buttonShowMessage.Size = new System.Drawing.Size(160, 40);
        buttonShowMessage.TabIndex = 0;
        buttonShowMessage.Text = "Показать сообщение";
        buttonShowMessage.UseVisualStyleBackColor = true;
        buttonShowMessage.Click += buttonShowMessage_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(480, 320);
        Controls.Add(buttonShowMessage);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Модуль 1 Задание 1";
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Button buttonShowMessage;
}