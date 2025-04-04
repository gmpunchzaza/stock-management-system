using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_management__system
{
    [DesignerCategory("Code")]
    [ToolboxItem(true)]
    public partial class CustomPanel : Panel
    {
        private Color _gradientColor1 = Color.LightBlue;
        private Color _gradientColor2 = Color.Blue;
        private int _borderRadius = 20; // Default border radius

        [Category("Appearance"), Description("The first gradient color.")]
        public Color GradientColor1
        {
            get { return _gradientColor1; }
            set { _gradientColor1 = value; Invalidate(); } // Invalidate to trigger repaint
        }

        [Category("Appearance"), Description("The second gradient color.")]
        public Color GradientColor2
        {
            get { return _gradientColor2; }
            set { _gradientColor2 = value; Invalidate(); } // Invalidate to trigger repaint
        }

        [Category("Appearance"), Description("The border radius of the panel.")]
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; Invalidate(); } // Invalidate to trigger repaint
        }

        public CustomPanel()
        {
            this.DoubleBuffered = true; // Enable double buffering to prevent flickering
        }

        // Override the OnPaint method to customize the panel's appearance
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Smooth the edges of the drawing

            // Create a rectangle for the panel
            Rectangle panelRect = this.ClientRectangle;

            // Create the rounded rectangle path
            using (GraphicsPath path = GetRoundedRectanglePath(panelRect, BorderRadius))
            {
                // Create a gradient brush with the two colors
                using (LinearGradientBrush brush = new LinearGradientBrush(panelRect, GradientColor1, GradientColor2, LinearGradientMode.Vertical))
                {
                    g.FillPath(brush, path); // Fill the panel with the gradient brush
                }

                // Optionally, draw a border around the panel
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        // Helper method to create a rounded rectangle path
        private GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int arcDiameter = radius * 2;
            path.AddArc(rect.X, rect.Y, arcDiameter, arcDiameter, 180, 90); // Top-left corner
            path.AddArc(rect.Right - arcDiameter, rect.Y, arcDiameter, arcDiameter, 270, 90); // Top-right corner
            path.AddArc(rect.Right - arcDiameter, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 0, 90); // Bottom-right corner
            path.AddArc(rect.X, rect.Bottom - arcDiameter, arcDiameter, arcDiameter, 90, 90); // Bottom-left corner
            path.CloseFigure(); // Close the path to create a complete shape
            return path;
        }
    }
}
