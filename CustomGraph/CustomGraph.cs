using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace CustomGraph;

public partial class CustomGraph : UserControl
{
    private readonly int MaxValue;

    public CustomGraph(List<List<int>> ChartData)
    {
        InitializeComponent();
        MaxValue = ChartData.Max(x => x.Sum());

        RenderAxisY();

    }

    private void RenderAxisY()
    {
        for (int i = 0; i < 7; i++)
        {
            if (i != 0)
            {
                axis_y.ColumnCount++;
                axis_y.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            }
            Label label = new()
            {
                Text = ((MaxValue / 6) * i).ToString(),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Visible = true
            };
            MessageBox.Show(((MaxValue / 6) * i).ToString());
            axis_y.SetRow(label, i);
            axis_y.Controls.Add(label);
        }
    }
}
