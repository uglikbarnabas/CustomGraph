﻿using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace CustomGraph;

partial class CustomGraph : Panel
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
<<<<<<< Updated upstream
        graph_wrapper = new TableLayoutPanel();
        legend = new TableLayoutPanel();
        axis_y = new TableLayoutPanel();
        render_wrapper = new TableLayoutPanel();
        graph_outer = new Panel();
        graph_dataView = new TableLayoutPanel();
        graph_wrapper.SuspendLayout();
        render_wrapper.SuspendLayout();
        graph_outer.SuspendLayout();
=======
        graph_wrapper = new FastGrid();
        axisy_wrapper = new FastGrid();
        MAIN = new Panel();
>>>>>>> Stashed changes
        SuspendLayout();
        // 
        // graph_wrapper
        // 
        graph_wrapper.ColumnCount = 5;
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50F));
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
<<<<<<< Updated upstream
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        graph_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
        graph_wrapper.Controls.Add(legend, 3, 1);
        graph_wrapper.Controls.Add(axis_y, 1, 1);
        graph_wrapper.Controls.Add(render_wrapper, 2, 1);
        graph_wrapper.Dock = DockStyle.Fill;
=======
        graph_wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        graph_wrapper.Controls.Add(axisy_wrapper);
>>>>>>> Stashed changes
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
        // MAIN
        //
        MAIN.Padding = MAIN.Margin = new Padding(0);
        MAIN.Location = new Point(0, 0);
        MAIN.Size = new Size(800, 450);
        MAIN.Dock = DockStyle.Fill;
        MAIN.Controls.Add(graph_wrapper);
        // 
        // legend
        // 
        legend.BackColor = Color.Transparent;
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
        // axis_y
        // 
        axis_y.BackColor = Color.Transparent;
        axis_y.ColumnCount = 1;
        axis_y.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        axis_y.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        axis_y.Dock = DockStyle.Left;
        axis_y.Location = new Point(10, 10);
        axis_y.Margin = new Padding(0);
        axis_y.Name = "axis_y";
        axis_y.RowCount = 1;
        axis_y.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        axis_y.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        axis_y.Size = new Size(50, 380);
        axis_y.TabIndex = 0;
        // 
        // render_wrapper
        // 
        render_wrapper.BackColor = Color.Transparent;
        render_wrapper.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
        render_wrapper.ColumnCount = 1;
        render_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        render_wrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        render_wrapper.Controls.Add(graph_outer, 0, 0);
        render_wrapper.Dock = DockStyle.Fill;
        render_wrapper.Location = new Point(60, 10);
        render_wrapper.Margin = new Padding(0);
        render_wrapper.Name = "render_wrapper";
        render_wrapper.RowCount = 2;
        graph_wrapper.SetRowSpan(render_wrapper, 2);
        render_wrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        render_wrapper.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        render_wrapper.Size = new Size(580, 430);
        render_wrapper.TabIndex = 3;
        // 
        // graph_outer
        // 
        graph_outer.BackColor = Color.FromArgb(100, 100, 255, 255);
        graph_outer.Controls.Add(graph_dataView);
        graph_outer.Dock = DockStyle.Fill;
        graph_outer.Location = new Point(1, 1);
        graph_outer.Margin = new Padding(0);
        graph_outer.Name = "graph_outer";
        graph_outer.Size = new Size(578, 377);
        graph_outer.TabIndex = 0;
        // 
        // graph_dataView
        // 
        graph_dataView.ColumnCount = 1;
        graph_dataView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        graph_dataView.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
        graph_dataView.Dock = DockStyle.Fill;
        graph_dataView.Location = new Point(0, 0);
        graph_dataView.Margin = new Padding(0);
        graph_dataView.Name = "graph_dataView";
        graph_dataView.RowCount = 1;
        graph_dataView.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        graph_dataView.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        graph_dataView.Size = new Size(578, 377);
        graph_dataView.TabIndex = 0;
        // 
        // CustomGraph
        //
        BackColor = Color.White;
        Controls.Add(MAIN);
        Name = "CustomGraph";
        Size = new Size(800, 450);
        graph_wrapper.ResumeLayout(false);
        render_wrapper.ResumeLayout(false);
        graph_outer.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

<<<<<<< Updated upstream
    private TableLayoutPanel graph_wrapper;
    private TableLayoutPanel legend;
    private TableLayoutPanel axis_y;
    private TableLayoutPanel render_wrapper;
    private Panel graph_outer;
    private TableLayoutPanel graph_dataView;
=======
    private FastGrid graph_wrapper;
    private FastGrid axisy_wrapper;

    private Panel MAIN;
>>>>>>> Stashed changes
}
