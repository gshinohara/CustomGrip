using Grasshopper.Documentation;
using Grasshopper.GUI.Canvas;
using Grasshopper.GUI;
using Grasshopper;
using Grasshopper.GUI.Canvas.Interaction;
using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGrip
{
    internal class WiringInteraction : GH_AbstractInteraction
    {
        private enum LinkMode
        {
            Replace,
            Add,
            Remove
        }

        private LinkMode m_mode;

        private PointF m_MouseLocation;

        public WiringInteraction(GH_Canvas canvas, GH_CanvasMouseEvent mouseEvent) : base(canvas, mouseEvent)
        {
            m_mode = LinkMode.Replace;
            m_MouseLocation = PointF.Empty;
            canvas.CanvasPostPaintObjects += Canvas_CanvasPostPaintObjects;
            Instances.CursorServer.AttachCursor(canvas, "GH_NewWire");
        }

        public override void Destroy()
        {
            m_canvas.CanvasPostPaintObjects -= Canvas_CanvasPostPaintObjects;
            base.Destroy();
        }

        private void Canvas_CanvasPostPaintObjects(GH_Canvas sender)
        {
        }
    }
}
