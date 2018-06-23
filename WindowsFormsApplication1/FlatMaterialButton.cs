using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    class FlatMaterialButton : Button
    {
        private Color ColorState;
        private StringFormat SF = new StringFormat();
        private Rectangle R;
        public FlatMaterialButton()
        {
            Size = new Size(145, 45);
            BackColor = CurrentColor;
            ForeColor = Color.White;
            SF.LineAlignment = StringAlignment.Center;
            SF.Alignment = StringAlignment.Center;
            R = new Rectangle(0, 0, Width, Height);
            Font = new Font("Segoe UI", 14);
        }

        public Color CurrentColor
        {
            get { return ColorState; }
            set { ColorState = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var G = pevent.Graphics;
            G.FillRectangle(new SolidBrush(CurrentColor), 0, 0, Width, Height);
            G.DrawString(Text, Font, new SolidBrush(Color.White), R, SF);
        }
    }
}
