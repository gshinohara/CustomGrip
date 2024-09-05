using System.Drawing;

namespace CustomGrip
{
    internal static class Util
    {
        public static void DrawWire(Grip sourceGrip, Grip targetGrip, Graphics graphics, Color color)
        {
            Pen pen = new Pen(color, 3);
            graphics.DrawBezier(pen, sourceGrip.Position, sourceGrip.Position + sourceGrip.Direction, targetGrip.Position + targetGrip.Direction, targetGrip.Position);
            pen.Dispose();
        }
    }
}
