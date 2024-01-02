using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Shop

{
    public class RoundedPanel : Panel
    {
        private int borderRadius = 20;
        private int borderSize = 0;
        private Color borderColor = Color.PaleVioletRed;

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                Invalidate();
            }
        }

        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath gPath = new GraphicsPath();
            gPath.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            gPath.AddArc(Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            gPath.AddArc(Width - borderRadius, Height - borderRadius, borderRadius, borderRadius, 0, 90);
            gPath.AddArc(0, Height - borderRadius, borderRadius, borderRadius, 90, 90);
            gPath.CloseAllFigures();
            Region = new Region(gPath);

            if (borderSize > 0)
            {
                using (Pen pen = new Pen(borderColor, borderSize))
                {
                    e.Graphics.DrawPath(pen, gPath);
                }
            }
        }
    }
}


