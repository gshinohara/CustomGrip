using CustomGrip.Grips;

namespace CustomGrip.Targets
{
    public interface ITargetObject
    {
        Grip GetGrip();

        void DrawTarget(System.Drawing.Graphics graphics);

        bool IsEqualOwner(ITargetObject other);
    }
}
