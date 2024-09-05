using Grasshopper;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.GUI.Canvas.Interaction;
using System.Windows.Forms;

namespace CustomGrip
{
    internal abstract class BaseInteraction<TTarget> : GH_AbstractInteraction
    {
        protected LinkMode m_mode = LinkMode.Replace;

        protected WiringObjectInputGrip<TTarget> SourceGrip { get; }

        public BaseInteraction(GH_Canvas canvas, GH_CanvasMouseEvent e, WiringObjectInputGrip<TTarget> sourceGrip) : base(canvas, e)
        {
            SourceGrip = sourceGrip;
            canvas.CanvasPostPaintObjects += SetCursor;
        }

        public override void Destroy()
        {
            m_canvas.CanvasPostPaintObjects -= SetCursor;
            base.Destroy();
        }

        private void SetCursor(GH_Canvas sender)
        {
            switch (m_mode)
            {
                case LinkMode.Replace:
                    Instances.CursorServer.AttachCursor(Canvas, "GH_NewWire");
                    break;
                case LinkMode.Add:
                    Instances.CursorServer.AttachCursor(Canvas, "GH_AddWire");
                    break;
                case LinkMode.Remove:
                    Instances.CursorServer.AttachCursor(Canvas, "GH_RemoveWire");
                    break;
            }
        }

        public override GH_ObjectResponse RespondToMouseMove(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            sender.Refresh();

            return base.RespondToMouseMove(sender, e);
        }

        public override GH_ObjectResponse RespondToKeyDown(GH_Canvas sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.None:
                    m_mode = LinkMode.Replace;
                    break;
                case Keys.ShiftKey:
                    m_mode = LinkMode.Add;
                    break;
                case Keys.ControlKey:
                    m_mode = LinkMode.Remove;
                    break;
            }

            sender.Refresh();

            return base.RespondToKeyDown(sender, e);
        }

        public override GH_ObjectResponse RespondToKeyUp(GH_Canvas sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ShiftKey:
                case Keys.ControlKey:
                    m_mode = LinkMode.Replace;
                    break;
            }

            sender.Refresh();

            return base.RespondToKeyUp(sender, e);
        }
    }
}
