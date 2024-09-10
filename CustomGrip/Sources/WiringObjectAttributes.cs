using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CustomGrip
{
    public abstract class WiringObjectAttributes<TTarget> : GH_Attributes<WiringObject<TTarget>>
          where TTarget : ITargetObject
    {
        public List<WiringObjectInputGrip<TTarget>> MyInputGrips { get; } = new List<WiringObjectInputGrip<TTarget>>();

        public WiringObjectAttributes(WiringObject<TTarget> owner) : base(owner)
        {
        }

        public override GH_ObjectResponse RespondToMouseMove(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (MyInputGrips.FirstOrDefault(g => GH_GraphicsUtil.Distance(g.Position, e.CanvasLocation) < 10) is WiringObjectInputGrip<TTarget> grip)
                sender.ActiveInteraction = new CursorAproachingInteraction<TTarget>(sender, e, grip);

            sender.Refresh();

            return base.RespondToMouseMove(sender, e);
        }

        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
        {
            base.Render(canvas, graphics, channel);

            switch (channel)
            {
                case GH_CanvasChannel.Wires:
                    foreach (WiringObjectInputGrip<TTarget> inputGrip in MyInputGrips)
                        inputGrip.DrawWireToTarget(graphics, Color.Gray);
                    break;
                case GH_CanvasChannel.Objects:
                    foreach (WiringObjectInputGrip<TTarget> inputGrip in MyInputGrips)
                    {
                        inputGrip.DrawGrip(graphics);
                        foreach (TTarget target in inputGrip.TargetObjects)
                            target.DrawTarget(graphics);
                    }
                    break;
            }
        }
    }
}
