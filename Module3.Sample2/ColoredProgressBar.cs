using System.ComponentModel;

namespace Module3.Sample2;

public class ColoredProgressBar : ProgressBar
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color BarColor { get; set; } = Color.Green;

    public ColoredProgressBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var rect = ClientRectangle;
        ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rect);
        rect.Inflate(-3, -3);

        if (Value <= 0)
            return;

        var fillWidth = (int)(rect.Width * ((double)Value / Maximum));
        var fillRect = rect with { Width = fillWidth };
        using var brush = new SolidBrush(BarColor);
        e.Graphics.FillRectangle(brush, fillRect);
    }
}