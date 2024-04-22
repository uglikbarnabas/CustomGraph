using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System;

namespace CustomGraph;

public class ChartData
{
    public List<Column> Data;
    public class Column
    {
        public List<int> Data;
        public Color Color;
        public string Name;
    }
}

public partial class CustomGraph : UserControl
{
    private readonly float MaxValue;

    public CustomGraph()
    {
        InitializeComponent();

        List<List<int>> ChartData = [ [ 30, 20 ], [ 15, 15 ] ];
        MaxValue = ChartData.Max(x => x.Sum());

        RenderAxisY();
        RenderAxisX();
        // When rendering graph column main
        // Do not add more columns!!
        // RenderAxisX already added all of them!

    }

    private void RenderAxisX()
    {
        for (int x = 0; x < Columns; x++)
        {
            // Add each column for rendering
            render_wrapper.Columns++;
            render_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Precent, 100F / Columns.Count));

            Label label = new()
            {
                Anchor = AchorStyles.Left | AchorStyles.Top | AchorStyles.Right | AchorStyles.Bottom,
                Text = Columns[i].Name, Visible = true, AutoSize = true
            };
            render_wrapper.Controls.Add(label, 1, x);
            
        }
    }

    private void RenderAxisY(int count)
    {
        axis_y.Controls.Clear();
        axis_y.RowCount = count;
        axis_y.RowStyles.Clear();

        for (int i = 0; i <= count; i++)
        {
            axis_y.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / count));
            Label label = new()
            {
                Text = Math.Round((MaxValue - (MaxValue / count * i))).ToString(),
                Dock = DockStyle.Fill, Margin = Padding = new Padding(0),
                TextAlign = ContentAlignment.TopRight,
            };
            label.Paint += (_, f) => ControlPaint.DrawBorder(f.Graphics, label.ClientRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Black, 1, ButtonBorderStyle.Solid,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None);
            axis_y.Controls.Add(label, 0, i);
        }
    }
}
