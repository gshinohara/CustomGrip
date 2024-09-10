using Grasshopper.Kernel;
using System.Collections;
using System.Collections.Generic;

namespace CustomGrip
{
    /// <summary>
    /// Collection class of target objects.
    /// </summary>
    /// <typeparam name="TTarget">Target objectts to be contained in the collection.</typeparam>
    public abstract class TargetCollection<TTarget> : IEnumerable<TTarget>
        where TTarget : ITargetObject
    {
        /// <summary>
        /// When the collection is called, the collection is initialized with the property.
        /// </summary>
        protected abstract IEnumerable<TTarget> Targets { get; }

        protected GH_Document Document { get; }

        public TargetCollection(GH_Document document)
        {
            Document = document;
        }

        public abstract TTarget Find(System.Drawing.PointF point);

        public IEnumerator<TTarget> GetEnumerator()
        {
            foreach (TTarget value in Targets)
                yield return value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
