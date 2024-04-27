using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System;

namespace CustomGraph;

public partial class CustomGraph : Control
{
    private const int axis_x_height = 50, legend_width = 150;

    private int r_legend_width = legend_width;
    private bool r_draw_legend = true;
    private int r_axis_y_width = 50;

    private float MaxValue => ChartData.Max(x => x.Data.Sum());
    private float YStep => MaxValue / Yrows;

    public int Yrows = 6;

    private readonly List<ChartColumn> ChartData =
    [
        new ChartColumn([ 10, 20 ], "col0"),
        new ChartColumn([ 05 ], "col1"),
        new ChartColumn([ 10 ], "col2"),
        new ChartColumn([ 7.5f ], "col3"),
        new ChartColumn([ 00 ]),
        new ChartColumn([ 00 ]),
        new ChartColumn([ 00 ]),
    ];

    private readonly List<ChartColorData> ChartColors =
    [
        new ChartColorData(new SolidBrush(Color.Red), ""),
        new ChartColorData(new SolidBrush(Color.Coral), ""),
        new ChartColorData(new SolidBrush(Color.Blue), ""),
        new ChartColorData(new SolidBrush(Color.Black), ""),
        new ChartColorData(new SolidBrush(Color.Brown), ""),
        new ChartColorData(new SolidBrush(Color.Firebrick), ""),
        new ChartColorData(new SolidBrush(Color.ForestGreen), ""),
    ];

    public CustomGraph()
    {
        InitializeComponent();
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        r_draw_legend = ClientSize.Width <= 500;
        r_legend_width = r_draw_legend ? 0 : legend_width;
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
        for (int i = 1; i <= ChartData.Count; i++)
        {
            float x = i * (ClientSize.Width - r_axis_y_width - r_legend_width) / (ChartData.Count + 1) + r_axis_y_width;
            float availibleHeight = ClientSize.Height - axis_x_height; float YPosMod = 0;
            float oneUnit = availibleHeight / MaxValue;
            for (int j = 0; j < ChartData[i - 1].Data.Count; j++)
            {
                float height = oneUnit * ChartData[i - 1].Data[j];
                e.Graphics.FillRectangle(ChartColors[j].Color, x - (x - r_axis_y_width) / i / 4,
                    availibleHeight - height - YPosMod, (x - r_axis_y_width) / i / 2, height);
                YPosMod += height;
            }
        }
    }
}

public record ChartColumn(List<float> Data, string Name = "Unknown");
public record ChartColorData(Brush Color, string Name = "Unknown");