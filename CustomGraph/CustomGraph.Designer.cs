using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace CustomGraph;

partial class CustomGraph : Control
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
        SuspendLayout();
        // 
        // CustomGraph
        //
        BackColor = Color.White;
        Name = "CustomGraph";
        Size = new Size(800, 450);
        ResumeLayout(false);
    }

    #endregion
}
