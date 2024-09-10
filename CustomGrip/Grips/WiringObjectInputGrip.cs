using System.Collections.Generic;
using System.Drawing;

namespace CustomGrip
{
    public abstract class WiringObjectInputGrip<TTarget> : Grip
          where TTarget : ITargetObject
    {
        public List<TTarget> TargetObjects { get; } = new List<TTarget>();

        public WiringObjectAttributes<TTarget> Parent { get; }

        public abstract SizeF TargetDirection { get; }

        public WiringObjectInputGrip(WiringObjectAttributes<TTarget> parent, float startAngle, float sweepAngle) : base(startAngle, sweepAngle)
        {
            Parent = parent;
            parent.MyInputGrips.Add(this);
        }

        public void DrawWireToTarget(Graphics graphics, Color color)
        {
            foreach (TTarget target in TargetObjects)
                Util.DrawWire(this, target.GetGrip(), graphics, color);
        }
    }
}
