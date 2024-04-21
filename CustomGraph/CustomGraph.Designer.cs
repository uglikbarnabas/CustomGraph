using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace CustomGraph;

partial class CustomGraph
{
    private IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        graph_wrapper = new TableLayoutPanel();
        renderSection = new TableLayoutPanel();
        axis_y = new TableLayoutPanel();
        legend = new TableLayoutPanel();
        graph_wrapper.SuspendLayout();
        SuspendLayout();
        // 
        // graph_wrapper
        // 
        graph_wrapper.ColumnCount = 5;
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
        graph_wrapper.Controls.Add(renderSection, 2, 1);
        graph_wrapper.Controls.Add(axis_y, 1, 1);
        graph_wrapper.Controls.Add(legend, 3, 1);
        graph_wrapper.Dock = DockStyle.Fill;
        graph_wrapper.Location = new Point(0, 0);
        graph_wrapper.Margin = new Padding(0);
        graph_wrapper.Name = "graph_wrapper";
        graph_wrapper.RowCount = 4;
        graph_wrapper.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
        graph_wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        graph_wrapper.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        graph_wrapper.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
        graph_wrapper.Size = new Size(800, 450);
        graph_wrapper.TabIndex = 0;
        // 
        // renderSection
        // 
        renderSection.BackColor = Color.Wheat;
        renderSection.ColumnCount = 7;
        renderSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857132F));
        renderSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
        renderSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
        renderSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
        renderSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
        renderSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
        renderSection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857161F));
        renderSection.Dock = DockStyle.Fill;
        renderSection.Location = new Point(60, 10);
        renderSection.Margin = new Padding(0);
        renderSection.Name = "renderSection";
        renderSection.RowCount = 2;
        graph_wrapper.SetRowSpan(renderSection, 2);
        renderSection.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        renderSection.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        renderSection.Size = new Size(580, 430);
        renderSection.TabIndex = 0;
        // 
        // axis_y
        // 
        axis_y.BackColor = Color.LightBlue;
        axis_y.ColumnCount = 1;
        axis_y.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        axis_y.Dock = DockStyle.Fill;
        axis_y.Location = new Point(10, 10);
        axis_y.Margin = new Padding(0);
        axis_y.Name = "axis_y";
        axis_y.RowCount = 1;
        axis_y.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
        axis_y.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        axis_y.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        axis_y.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        axis_y.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        axis_y.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        axis_y.Size = new Size(50, 380);
        axis_y.TabIndex = 1;
        // 
        // legend
        // 
        legend.BackColor = Color.LightBlue;
        legend.ColumnCount = 2;
        legend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        legend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        legend.Dock = DockStyle.Fill;
        legend.Location = new Point(640, 10);
        legend.Margin = new Padding(0);
        legend.Name = "legend";
        legend.RowCount = 1;
        legend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        legend.Size = new Size(150, 380);
        legend.TabIndex = 2;
        // 
        // CustomGraph
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Controls.Add(graph_wrapper);
        Name = "CustomGraph";
        Size = new Size(800, 450);
        graph_wrapper.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel graph_wrapper;
    private TableLayoutPanel renderSection;
    private TableLayoutPanel axis_y;
    private TableLayoutPanel legend;
}
