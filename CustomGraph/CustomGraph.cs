using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System;

namespace CustomGraph;

public partial class CustomGraph : Control
{
    private const int axis_x_height = 50, legend_width = 0;

    private int r_legend_width = legend_width;
    private int r_axis_y_width = 50;

    private float MaxValue => ChartData.Max(x => x.Data.Sum());
    private float YStep => MaxValue / Yrows;

    public int Yrows = 7;

    private readonly List<Column> ChartData =
    [
        new Column() { Data = [ 10, 20 ], Name = "col0" },
        new Column() { Data = [ 05 ], Name = "col1" },
        new Column() { Data = [ 10 ], Name = "col2" },
        new Column() { Data = [ 7.5f ], Name = "col3" },
        new Column() { Data = [ 00 ], Name = "col4" },
        new Column() { Data = [ 00 ], Name = "col5" },
        new Column() { Data = [ 00 ], Name = "col6" },
    ];

    public CustomGraph()
    {
        InitializeComponent();
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        r_legend_width = (ClientSize.Width <= 500) ? 0 : legend_width;
        r_axis_y_width = (int)e.Graphics.MeasureString(MaxValue.ToString(), Font).Width + 10;
        e.Graphics.Clear(Color.White);

        // Draw axis Y lines
        e.Graphics.DrawLine(Pens.Black, r_axis_y_width, 0, r_axis_y_width, ClientSize.Height - axis_x_height + 5);
        for (int i = 1; i <= Yrows; i++)
        {
            int y = i * (ClientSize.Height - axis_x_height) / Yrows;
            e.Graphics.DrawLine(Pens.Black, r_axis_y_width - 5, y, r_axis_y_width, y);
            e.Graphics.DrawLine((i == Yrows) ? Pens.Black : Pens.Gray, r_axis_y_width, y, ClientSize.Width - r_legend_width, y);
            int textheight = (int)e.Graphics.MeasureString((MaxValue - YStep * i).ToString(), Font).Height / 2;
            e.Graphics.DrawString(Math.Round((MaxValue - YStep * i)).ToString(), Font, Brushes.Black, 2.5f, y - textheight);
        }
        e.Graphics.DrawString(MaxValue.ToString(), Font, Brushes.Black, 2.5f, -2);
        // Draw axis X lines
        for (int i = 1; i <= ChartData.Count; i++)
        {
            int x = i * (ClientSize.Width - r_axis_y_width - r_legend_width) / (ChartData.Count + 1) + r_axis_y_width;
            e.Graphics.DrawLine(Pens.Black, x, ClientSize.Height - axis_x_height, x, ClientSize.Height - axis_x_height + 5);
            e.Graphics.DrawLine(Pens.Gray, x, ClientSize.Height - axis_x_height, x, 0);
            int textWidth = (int)e.Graphics.MeasureString(ChartData[i - 1].Name, Font).Width / 2;
            e.Graphics.DrawString(ChartData[i - 1].Name, Font, Brushes.Black, x - textWidth, ClientSize.Height - axis_x_height + 10);
        }
        // Draw rectangles
        float totalWidthForRectangles = ClientSize.Width - r_axis_y_width - r_legend_width;
        float effectiveRectangleWidth = totalWidthForRectangles / ChartData.Count;
        float rectangleWidth = (float)(effectiveRectangleWidth * 0.5);
        for (int i = 1; i <= ChartData.Count; i++)
        {
            float x = i * (ClientSize.Width - r_axis_y_width - r_legend_width) / (ChartData.Count + 1) + r_axis_y_width;
            float availibleHeight = ClientSize.Height - axis_x_height; float endY = availibleHeight;
            float oneUnit = availibleHeight / MaxValue;

            for (int j = 0; j < ChartData[i - 1].Data.Count; j++)
            {
                float height = oneUnit * ChartData[i - 1].Data[j];
                e.Graphics.FillRectangle(Brushes.Red, x - (x - r_axis_y_width) / i / 4, availibleHeight - height, (x - r_axis_y_width) / i / 2, height);
            }
        }
    }
}

public class Column
{
    public List<float> Data = [];
    public Color Color;
    public string? Name;
}