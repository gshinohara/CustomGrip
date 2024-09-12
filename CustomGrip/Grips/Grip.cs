using System.Drawing;

namespace CustomGrip.Grips
{
    public abstract class Grip
    {
        public string Name { get; set; }

        public object Tag { get; set; }

        public PointF Position { get; set; }

        public SizeF Direction { get; set; }

        public float GripStartAngle { get; }

        public float GripSweepAngle { get; }

        public Grip(float startAngle, float sweepAngle)
        {
            GripStartAngle = startAngle;
            GripSweepAngle = sweepAngle;
        }

        public virtual void DrawGrip(Graphics graphics)
        {
            Rectangle bounds = new Rectangle(new Point((int)Position.X, (int)Position.Y), new Size(10, 10));
            bounds.Offset(-bounds.Width / 2, -bounds.Height / 2);
            graphics.FillPie(new SolidBrush(Color.White), bounds, GripStartAngle, GripSweepAngle);
            graphics.DrawPie(new Pen(Color.Black, 2), bounds, GripStartAngle, GripSweepAngle);
        }
    }
}
