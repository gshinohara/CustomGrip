using Grasshopper;
using Grasshopper.GUI;
using Grasshopper.GUI.Canvas;
using Grasshopper.Kernel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CustomGrip
{
    public abstract class WiringObjectAttributes<TTarget> : GH_Attributes<WiringObject<TTarget>>
    {
        private IEnumerable<WiringObjectInputGrip<TTarget>> m_MyInputGrips;

        public IEnumerable<WiringObjectInputGrip<TTarget>> MyInputGrips
        {
            get
            {
                foreach (WiringObjectInputGrip<TTarget> grip in m_MyInputGrips)
                    yield return grip;
            }
        }

        public WiringObjectAttributes(WiringObject<TTarget> owner, IEnumerable<WiringObjectInputGrip<TTarget>> grips) : base(owner)
        {
            m_MyInputGrips = grips;
        }

        protected override void Render(GH_Canvas canvas, Graphics graphics, GH_CanvasChannel channel)
        {
            base.Render(canvas, graphics, channel);

            switch (channel)
            {
                case GH_CanvasChannel.Wires:
                    foreach (WiringObjectInputGrip<TTarget> inputGrip in MyInputGrips)
                        inputGrip.DrawWireToTarget(graphics, Color.Gray, 3);
                    break;
                case GH_CanvasChannel.Objects:
                    foreach (WiringObjectInputGrip<TTarget> inputGrip in MyInputGrips)
                        inputGrip.DrawGrip(graphics, canvas.Viewport.Zoom);
                    break;
            }
        }

        public override GH_ObjectResponse RespondToMouseDown(GH_Canvas sender, GH_CanvasMouseEvent e)
        {
            foreach (WiringObjectInputGrip<TTarget> grip in MyInputGrips)
            {
                if (GH_GraphicsUtil.Distance(e.CanvasLocation, grip.Position) <= 10)
                {
                    Instances.CursorServer.AttachCursor(sender, "GH_NewWire");
                    if (e.Button == MouseButtons.Left)
                        sender.ActiveInteraction = new WiringInteraction(sender, e);
                }
                else
                    Instances.CursorServer.ResetCursor(sender);

            }

            return base.RespondToMouseDown(sender, e);
        }
    }
}
