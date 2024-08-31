using Grasshopper.Kernel;
using System;
using System.Collections.Generic;

namespace CustomGrip
{
    public abstract class WiringObject<TTarget> : GH_DocumentObject
    {
        public WiringObject(string name, string nickname, string description, string category, string subCategory)
            : base(name, nickname, description, category, subCategory)
        {
        }
    }
}