using System.Drawing;

namespace CustomGrip
{
    internal static class Util
    {
        public static void DrawWire(Grip sourceGrip, Grip targetGrip, Graphics graphics, Color color, int thickness)
        {
            Pen pen = new Pen(color, thickness);
            graphics.DrawBezier(pen, sourceGrip.Position, sourceGrip.Position + sourceGrip.Direction, targetGrip.Position + targetGrip.Direction, targetGrip.Position);
            pen.Dispose();
        }
    }
}
