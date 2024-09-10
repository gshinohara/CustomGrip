using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;

namespace CustomGrip
{
    internal class CursorAproachingInteraction<TTarget> : BaseInteraction<TTarget>
          where TTarget : ITargetObject
    {
        public CursorAproachingInteraction(GH_Canvas canvas, GH_CanvasMouseEvent e, WiringObjectInputGrip<TTarget> sourceGrip) : base(canvas, e, sourceGrip)
        {
        }

        public override GH_ObjectResponse RespondToMouseMove(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (GH_GraphicsUtil.Distance(SourceGrip.Position, e.CanvasLocation) >= 10)
                sender.ActiveInteraction = null;

            return base.RespondToMouseMove(sender, e);
        }

        public override GH_ObjectResponse RespondToMouseDown(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                sender.ActiveInteraction = new WiringInteraction<TTarget>(sender, e, SourceGrip);

            return base.RespondToMouseDown(sender, e);
        }
    }
}
