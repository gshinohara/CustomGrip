using System.Drawing;

namespace CustomGrip
{
    public abstract class TargetObject<TObject, TConnectedGrip> where TConnectedGrip : Grip
    {
        public TObject Owner { get; }

        public TConnectedGrip ConnectedGrip { get; }

        public TargetObject(TObject owner, TConnectedGrip connectedGrip)
        {
            Owner = owner;
            ConnectedGrip = connectedGrip;
        }

        public abstract RectangleF GetBounds();

        public abstract Grip GetGrip();
    }
}
