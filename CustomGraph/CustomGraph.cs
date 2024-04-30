using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System;

namespace CustomGraph;

public partial class Graph : Control
{
    private const int axis_x_height = 50, legend_width = 150;

    private float MaxSection => ChartData.Max(x => x.Data.Count(y => y != 0f));
    private float MaxValue => ChartData.Max(x => x.Data.Sum());
    private float YStep => MaxValue / yAxisRows;

    private int r_legend_width = legend_width;
    private bool r_draw_legend = true;
    private int r_axis_y_width = 50;

    public required List<ChartColorData> ChartColors;
    public required List<ChartColumn> ChartData;
    public int yAxisRows = 6;

    public Graph()
    {
        InitializeComponent();
        ResizeRedraw = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (ChartColors.Count < MaxSection)
            throw new IndexOutOfRangeException("Not enough chart colors to cover rendering.\nYou need " +
                MaxSection + " colors, you currently have " + ChartColors.Count);
        

        r_draw_legend = ClientSize.Width <= 500;
        r_legend_width = r_draw_legend ? 0 : legend_width;
        r_axis_y_width = (int)e.Graphics.MeasureString(MaxValue.ToString(), Font).Width + 10;

        // Draw axis Y lines
        e.Graphics.DrawLine(Pens.Black, r_axis_y_width, 0, r_axis_y_width, ClientSize.Height - axis_x_height + 5);
        for (int i = 1; i <= yAxisRows; i++)
        {
            int y = i * (ClientSize.Height - axis_x_height) / yAxisRows;
            e.Graphics.DrawLine((i == yAxisRows) ? Pens.Black : Pens.Gray, r_axis_y_width, y, ClientSize.Width - r_legend_width, y);
            e.Graphics.DrawLine(Pens.Black, r_axis_y_width - 5, y, r_axis_y_width, y);
            int textheight = (int)e.Graphics.MeasureString((MaxValue - YStep * i).ToString(), Font).Height / 2;
            e.Graphics.DrawString(Math.Round((MaxValue - YStep * i)).ToString(), Font, Brushes.Black, 2.5f, y - textheight);
        }
        e.Graphics.DrawString(MaxValue.ToString(), Font, Brushes.Black, 2.5f, -2);
        // Draw axis X lines
        for (int i = 1; i <= ChartData.Count; i++)
        {
            int x = i * (ClientSize.Width - r_axis_y_width - r_legend_width) / (ChartData.Count + 1) + r_axis_y_width;
            e.Graphics.DrawLine(Pens.Gray, x, ClientSize.Height - axis_x_height, x, 0);
            e.Graphics.DrawLine(Pens.Black, x, ClientSize.Height - axis_x_height, x, ClientSize.Height - axis_x_height + 5);
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
        // Draw legend
        if (r_draw_legend) return;
        float legendStartX = ClientSize.Width - legend_width;
        float currentYMargin = 15;
        for (int i = 0; i < MaxSection; i++)
        {
            e.Graphics.FillRectangle(ChartColors[i].Color, legendStartX + 5, currentYMargin, 15, 10);
            float labelHalfY = e.Graphics.MeasureString(ChartColors[i].Name, Font).Height / 4;
            e.Graphics.DrawString(ChartColors[i].Name, Font, Brushes.Black, legendStartX + 25, currentYMargin - labelHalfY);
            currentYMargin += 25;
        }
    }
}

public class ChartColumn
{
    public string Name = "Unknown";
    public List<float> Data = [];
}
public class ChartColorData
{
    public Brush Color = Brushes.Transparent;
    public string Name = "Unknown";
}