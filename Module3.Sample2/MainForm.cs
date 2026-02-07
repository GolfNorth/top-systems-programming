namespace Module3.Sample2;

public partial class MainForm : Form
{
    private readonly Random _random = new();

    public MainForm()
    {
        InitializeComponent();
    }

    private void buttonCreate_Click(object? sender, EventArgs e)
    {
        panelBars.Controls.Clear();

        var count = (int)numericCount.Value;
        var barWidth = panelBars.ClientSize.Width - 40;
        var y = 5;

        for (var i = 0; i < count; i++)
        {
            var bar = new ColoredProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                BarColor = Color.FromArgb(
                    _random.Next(50, 256),
                    _random.Next(50, 256),
                    _random.Next(50, 256)),
                Location = new Point(10, y),
                Size = new Size(barWidth, 28),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
            };

            panelBars.Controls.Add(bar);
            y += 35;
        }
    }
}
