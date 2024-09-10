namespace CustomGrip
{
    public interface ITargetObject
    {
        Grip GetGrip();

        void DrawTarget(System.Drawing.Graphics graphics);

        bool IsEqualOwner(ITargetObject other);
    }
}
