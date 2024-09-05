using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using System.Drawing;
using System.Windows.Forms;

namespace CustomGrip
{
    internal class WiringInteraction<TTarget> : BaseInteraction<TTarget>
    {
        public WiringInteraction(GH_Canvas canvas, GH_CanvasMouseEvent mouseEvent, WiringObjectInputGrip<TTarget> sourceGrip) : base(canvas, mouseEvent, sourceGrip)
        {
            canvas.CanvasPrePaintWires += PaintWire;
        }

        public override GH_ObjectResponse RespondToMouseUp(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sender.ActiveInteraction = null;
            }

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
