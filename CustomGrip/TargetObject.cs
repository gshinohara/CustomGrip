using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGrip
{
    public abstract class TargetObject<T>
    {
        public T Owner { get; }

        public TargetObject(T owner)
        {
            Owner = owner;
        }

        public abstract RectangleF GetBounds();

        public abstract Grip GetGrip();
    }
}
