using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CustomGrip
{
    /// <summary>
    /// Wire target.
    /// </summary>
    /// <typeparam name="TObject">Targeted object.</typeparam>
    /// <typeparam name="TConnectedGrip">Custom grip on the target.</typeparam>
    public abstract class TargetObject<TObject, TConnectedGrip> : ITargetObject
        where TConnectedGrip : Grip
    {
        public TObject Owner { get; }

        public TConnectedGrip ConnectedGrip { get; set; }

        public TargetObject(TObject owner)
        {
            Owner = owner;
        }

        public abstract RectangleF GetBounds();

        public abstract Grip GetGrip();

        public abstract bool IsEqualOwner(ITargetObject other);

        public void DrawTarget(Graphics graphics)
        {
            GetGrip().DrawGrip(graphics);
            GraphicsPath path = GH_CapsuleRenderEngine.CreateRoundedRectangle(GetBounds(), 2);
            graphics.DrawPath(new Pen(Color.Orange, 4) { Alignment = PenAlignment.Outset}, path);
        }
    }
}
