using System.Windows.Forms;
using System.Drawing;

namespace CustomGraph;

public partial class CustomGraph : Control
{
    //
    private int axis_y_width = 50, legend_width = 150;
    //
    private int axis_x_height = 50;
    //
    private int axis_y_rows = 6;
    private int axis_x_cols = 4;

    public CustomGraph()
    {
        InitializeComponent();
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Draw axis Y lines
        e.Graphics.DrawLine(Pens.Black, axis_y_width, 0, axis_y_width, Height - axis_x_height + 5);
        for (int i = 1; i <= axis_y_rows; i++)
        {
            int y = i * (Height - axis_x_height) / axis_y_rows;
            e.Graphics.DrawLine(Pens.Black, axis_y_width - 5, y, axis_y_width, y);
            e.Graphics.DrawLine((i == axis_y_rows) ? Pens.Black : Pens.Gray, axis_y_width, y, Width - legend_width, y);
            int textWidth = e.Graphics.MeasureString()
        }
        // Draw axis X lines
        for (int i = 1; i < axis_x_cols + 1; i++)
        {
            int x = i * (Width - axis_y_width - legend_width) / (axis_x_cols + 1) + axis_y_width;
            e.Graphics.DrawLine(Pens.Black, x, Height - axis_x_height, x, Height - axis_x_height + 5);
            e.Graphics.DrawLine(Pens.Gray, x, Height - axis_x_height, x, 0);
        }
    }

}