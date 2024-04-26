using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace CustomGraph;

public partial class CustomGraph : Control
{
    private const int axis_y_width = 50, legend_width = 150;
    private const int axis_x_height = 50;

    private int runtime_legend_width = legend_width;

    private readonly List<Column> ChartData =
    [
        new Column() { Data = [ 10, 10 ], Name = "col1" },
        new Column() { Data = [ 02, 08 ], Name = "col2" },
        new Column() { Data = [ 10, 10, 10 ], Name = "col3" },
    ];

    public CustomGraph()
    {
        InitializeComponent();
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (Width <= 500) runtime_legend_width = 0;
        else runtime_legend_width = legend_width;

        // Draw axis Y lines
        e.Graphics.DrawLine(Pens.Black, axis_y_width, 0, axis_y_width, Height - axis_x_height + 5);
        for (int i = 1; i <= 6; i++)
        {
            int y = i * (Height - axis_x_height) / 6;
            e.Graphics.DrawLine(Pens.Black, axis_y_width - 5, y, axis_y_width, y);
            e.Graphics.DrawLine((i == 6) ? Pens.Black : Pens.Gray, axis_y_width, y, Width - runtime_legend_width, y);
        }
        // Draw axis X lines
        for (int i = 1; i < ChartData.Count + 1; i++)
        {
            int x = i * (Width - axis_y_width - runtime_legend_width) / (ChartData.Count + 1) + axis_y_width;
            e.Graphics.DrawLine(Pens.Black, x, Height - axis_x_height, x, Height - axis_x_height + 5);
            e.Graphics.DrawLine(Pens.Gray, x, Height - axis_x_height, x, 0);
            int textWidth = (int)e.Graphics.MeasureString(ChartData[i - 1].Name, Font).Width / 2;
            e.Graphics.DrawString(ChartData[i - 1].Name, Font, Brushes.Black, x - textWidth, Height - axis_x_height + 10);
        }
    }
}

public class Column
{
    public List<int> Data = [];
    public Color Color;
    public string? Name;
}