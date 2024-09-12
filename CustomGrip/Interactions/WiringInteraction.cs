using CustomGrip.Grips;
using CustomGrip.Targets;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using System.Linq;

namespace CustomGrip.Interactions
{
    internal class WiringInteraction<TTarget> : BaseInteraction<TTarget>
          where TTarget : ITargetObject
    {
        public WiringInteraction(GH_Canvas canvas, GH_CanvasMouseEvent mouseEvent, WiringObjectInputGrip<TTarget> sourceGrip) : base(canvas, mouseEvent, sourceGrip)
        {
            canvas.CanvasPrePaintWires += PaintWire;
        }

        public override GH_ObjectResponse RespondToMouseUp(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (SourceGrip.Parent.Owner.TargetCollection.Find(e.CanvasLocation) is TTarget target)
            {
                TTarget targetMember = SourceGrip.TargetObjects.FirstOrDefault(o => o.IsEqualOwner(target));
                switch (m_mode)
                {
                    case LinkMode.Replace:
                        SourceGrip.TargetObjects.Clear();
                        SourceGrip.TargetObjects.Add(target);
                        break;
                    case LinkMode.Add:
                        if (targetMember != null)
                            break;
                        SourceGrip.TargetObjects.Add(target);
                        break;
                    case LinkMode.Remove:
                        SourceGrip.TargetObjects.Remove(targetMember);
                        break;
                }
            }

            sender.ActiveInteraction = null;

            return base.RespondToMouseUp(sender, e);
        }

        public override void Destroy()
        {
            m_canvas.CanvasPrePaintWires -= PaintWire;
            base.Destroy();
        }

        private void PaintWire(GH_Canvas sender)
        {
            Color color = Color.Empty;
            switch (m_mode)
            {
                case LinkMode.Replace:
                    color = Color.DarkGray;
                    break;
                case LinkMode.Add:
                    color = Color.Green;
                    break;
                case LinkMode.Remove:
                    color = Color.Red;
                    break;
            }

            Util.DrawWire(SourceGrip, new FloatingMouseGrip { Position = sender.CursorCanvasPosition, Direction = SourceGrip.TargetDirection }, sender.Graphics, color);
        }
    }
}
