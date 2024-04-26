using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace CustomGraph;

public partial class CustomGraph : Control
{
    private const int axis_x_height = 50, legend_width = 0;

    private int r_legend_width = legend_width;
    private int r_axis_y_width = 50;

    private int MaxValue => ChartData.Max(x => x.Data.Sum());
    private int YStep => MaxValue / Yrows;

    public int Yrows = 6;

    private readonly List<Column> ChartData =
    [
        new Column() { Data = [ 10, 10 ], Name = "col1" },
        new Column() { Data = [ 02, 08 ], Name = "col2" },
        new Column() { Data = [ 10, 10, 10 ], Name = "col3" },
        new Column() { Data = [ 02, 08 ], Name = "col4" },
        new Column() { Data = [ 02, 08 ], Name = "col5" },
        new Column() { Data = [ 10, 10, 10 ], Name = "col6" },
        new Column() { Data = [ 10, 10 ], Name = "col7" },
    ];

    public CustomGraph()
    {
        InitializeComponent();
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        r_legend_width = (Width <= 500) ? 0 : legend_width;
        r_axis_y_width = (int)e.Graphics.MeasureString(MaxValue.ToString(), Font).Width + 10;

        // Draw axis Y lines
        e.Graphics.DrawLine(Pens.Black, r_axis_y_width, 0, r_axis_y_width, Height - axis_x_height + 5);
        for (int i = 1; i <= Yrows; i++)
        {
            int y = i * (Height - axis_x_height) / 6;
            e.Graphics.DrawLine(Pens.Black, r_axis_y_width - 5, y, r_axis_y_width, y);
            e.Graphics.DrawLine((i == Yrows) ? Pens.Black : Pens.Gray, r_axis_y_width, y, Width - r_legend_width, y);
            int textheight = (int)e.Graphics.MeasureString((MaxValue - YStep * i).ToString(), Font).Height / 2;
            e.Graphics.DrawString((MaxValue - YStep * i).ToString(), Font, Brushes.Black, 2.5f, y - textheight);
        }
        e.Graphics.DrawString(MaxValue.ToString(), Font, Brushes.Black, 2.5f, -2);
        // Draw axis X lines
        for (int i = 1; i <= ChartData.Count; i++)
        {
            int x = i * (Width - r_axis_y_width - r_legend_width) / (ChartData.Count + 1) + r_axis_y_width;
            e.Graphics.DrawLine(Pens.Black, x, Height - axis_x_height, x, Height - axis_x_height + 5);
            e.Graphics.DrawLine(Pens.Gray, x, Height - axis_x_height, x, 0);
            int textWidth = (int)e.Graphics.MeasureString(ChartData[i - 1].Name, Font).Width / 2;
            e.Graphics.DrawString(ChartData[i - 1].Name, Font, Brushes.Black, x - textWidth, Height - axis_x_height + 10);
        }
        // Draw rectangles
        for (int i = 1; i <= ChartData.Count; i++)
        {
            int x = i * (Width - r_axis_y_width - r_legend_width) / (ChartData.Count + 1);
            e.Graphics.DrawRectangle(Pens.Red, x - (x / i / 2), 0, (x / i / 2), Height - axis_x_height);
            // TODO -- Fix always full height
            // TODO -- Fix empty fill just outline
        }
    }
}

public class Column
{
    public List<int> Data = [];
    public Color Color;
    public string? Name;
}