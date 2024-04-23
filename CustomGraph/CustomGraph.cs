using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using System;

namespace CustomGraph;

public partial class CustomGraph : UserControl
{
    private readonly List<Column> Data;
    private readonly float MaxValue;

    public CustomGraph()
    {
        InitializeComponent();

        Data = [
            new Column() { Name = "debug1", Data = [20], Color = Color.LightCoral },
            new Column() { Name = "debug2", Data = [10], Color = Color.LightPink },
            new Column() { Name = "other text very very very very very long", Data = [30], Color = Color.LightSeaGreen },
            new Column() { Name = "debug2", Data = [10], Color = Color.LightPink },
        ];
        MaxValue = Data.Max(x => x.Data.Sum());

        RenderAxisY(6);
        RenderAxisX();
        // When rendering graph column main
        // Do not add more columns!!
        // RenderAxisX already added all of them!
        RenderGraph();
        //RenderGraphLining();

    }

    //private void RenderGraphLining()
    //{
    //    for (int x = 0; x < Data.Count; x++)
    //    {
    //        FlowLayoutPanel container = new()
    //        {
    //            Dock = DockStyle.Fill,
    //            BackColor = Color.Blue,
    //            FlowDirection = FlowDirection.BottomUp,
    //            Margin = Padding = new Padding(0)
    //        };
    //        render_wrapper.Controls.Add(container, x, 0);
    //    }
    //}

    private void RenderGraph()
    {
        graph_dataView.ColumnCount = 0;
        graph_dataView.ColumnStyles.Clear();
        for (int i = 0; i < Data.Count; i++)
        {
            FlowLayoutPanel container = new()
            {
                FlowDirection = FlowDirection.BottomUp,
                Margin = Padding = new Padding(0),
                Dock = DockStyle.Fill
            };
            for (int j = 0; j < Data[i].Data.Count; j++)
            {
                Panel display = new()
                {
                    Height = (int)(graph_dataView.Height / MaxValue * Data[i].Data[j] + 1),
                    Width = container.Width / 2, BackColor = Data[i].Color,
                    Margin = Padding = new Padding(0), AutoSize = false,
                };
                container.Controls.Add(display);
            }
            graph_dataView.ColumnCount++;
            graph_dataView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / Data.Count));
            graph_dataView.Controls.Add(container, i, 0);
        }
    }

    private void RenderAxisX()
    {
        render_wrapper.ColumnCount = 0;
        render_wrapper.ColumnStyles.Clear();
        for (int x = 0; x < Data.Count; x++)
        {
            // Add each column for rendering
            render_wrapper.ColumnCount++;
            render_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / Data.Count));

            Label label = new()
            {
                Text = Data[x].Name, Visible = true, AutoSize = true, Padding = new Padding(0, 10, 0, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
                TextAlign = ContentAlignment.TopCenter, Margin = new Padding(0, 0, 0, 0)
            };
            label.Paint += (_, e) => ControlPaint.DrawBorder(e.Graphics, label.ClientRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Black, 1, ButtonBorderStyle.Solid,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Transparent, 0, ButtonBorderStyle.None);
            render_wrapper.Controls.Add(label, x, 1);
        }
        render_wrapper.SetColumnSpan(graph_outer, Data.Count);
    }
    private void RenderAxisY(int count)
    {
        axis_y.Controls.Clear();
        axis_y.RowCount = count;
        axis_y.RowStyles.Clear();

        MaxValue += MaxValue / count;

        for (int i = 0; i < count; i++)
        {
            axis_y.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / count));
            Label label = new()
            {
                Text = Math.Round(MaxValue - (MaxValue / count * i)).ToString(),
                Margin = new Padding(axis_y.Width - 20, 0, 0, 0),
                Dock = DockStyle.Fill, Padding = new Padding(0),
                TextAlign = ContentAlignment.TopRight,
            };
            label.Paint += (_, e) => ControlPaint.DrawBorder(e.Graphics, label.ClientRectangle,
                    Color.Transparent, 0, ButtonBorderStyle.None,
                    Color.Black,       1, ButtonBorderStyle.Solid,
                    Color.Black      , 1, ButtonBorderStyle.Solid,
                    Color.Transparent, 0, ButtonBorderStyle.None);
            axis_y.Controls.Add(label, 0, i);
        }
    }
}

public class Column
{
    public List<int> Data = [];
    public Color Color;
    public string? Name;
}