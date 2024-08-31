using Rhino.DocObjects.Tables;
using System.Collections.Generic;
using System.Drawing;

namespace CustomGrip
{
    public abstract class WiringObjectInputGrip<TTarget> : Grip
    {
        public IList<TargetObject<TTarget>> TargetObjects { get; } = new List<TargetObject<TTarget>>();

        public WiringObjectInputGrip(float startAngle, float sweepAngle) : base(startAngle, sweepAngle)
        {
        }

        public void DrawWireToTarget(Graphics graphics, Color color, int thickness)
        {
            foreach (TargetObject<TTarget> target in TargetObjects)
                Util.DrawWire(this, target.GetGrip(), graphics, color, thickness);
        }
    }
}
