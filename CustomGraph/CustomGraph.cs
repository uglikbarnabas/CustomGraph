using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System;

namespace CustomGraph;

public partial class CustomGraph : UserControl
{
    private readonly float MaxValue;

    public CustomGraph()
    {
        InitializeComponent();

        List<List<int>> ChartData = [ [ 30, 20 ], [ 15, 15 ] ];
        MaxValue = ChartData.Max(x => x.Sum());

        RenderAxisY(6);
    }

    private void RenderAxisY(int count)
    {
        axis_y.Controls.Clear();
        axis_y.RowCount = count;
        axis_y.RowStyles.Clear();

        for (int i = 0; i <= count; i++)
        {
            axis_y.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / count));
            Label label = new Label()
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
