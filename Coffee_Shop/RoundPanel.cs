using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Coffee_Shop
{
    internal class RoundPanel : Panel
    {
        public int CornerRadius { get; set; } = 10; // Adjust the corner radius as needed

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw a rounded rectangle with rounded top-left, top-right, and bottom-left corners
            using (Brush brush = new SolidBrush(this.BackColor))
            {
                g.FillRoundedRectangle(brush, ClientRectangle, CornerRadius, RoundedCorners.TopLeft | RoundedCorners.TopRight | RoundedCorners.BottomLeft);
            }
        }

    }
}

[Flags]
public enum RoundedCorners
{
    None = 0,
    TopLeft = 10,
    TopRight = 10,
    BottomLeft = 4,
    BottomRight = 8,
    All = TopLeft | TopRight | BottomLeft | BottomRight
}

public static class GraphicsExtensions
{
    public static void FillRoundedRectangle(this Graphics g, Brush brush, Rectangle bounds, int radius, RoundedCorners roundedCorners)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);

        GraphicsPath path = new GraphicsPath();

        if ((roundedCorners & RoundedCorners.TopLeft) == RoundedCorners.TopLeft)
        {
            Rectangle arc = new Rectangle(bounds.Location, size);
            path.AddArc(arc, 180, 90);
        }
        else
        {
            path.AddLine(bounds.Left, bounds.Top, bounds.Left, bounds.Top);
        }

        if ((roundedCorners & RoundedCorners.TopRight) == RoundedCorners.TopRight)
        {
            Rectangle arc = new Rectangle(new Point(bounds.Right - diameter, bounds.Top), size);
            path.AddArc(arc, 270, 90);
        }
        else
        {
            path.AddLine(bounds.Right, bounds.Top, bounds.Right, bounds.Top);
        }

        path.AddLine(bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);

        path.AddLine(bounds.Right, bounds.Bottom, bounds.Left, bounds.Bottom);

        if ((roundedCorners & RoundedCorners.BottomLeft) == RoundedCorners.BottomLeft)
        {
            Rectangle arc = new Rectangle(new Point(bounds.Left, bounds.Bottom - diameter), size);
            path.AddArc(arc, 90, 90);
        }
        else
        {
            path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Bottom);
        }

        path.CloseFigure();

        g.FillPath(brush, path);
    }
}