using CustomGrip.Targets;
using Grasshopper.Kernel;

namespace CustomGrip.Sources
{
    public abstract class WiringObject<TTarget> : GH_DocumentObject
        where TTarget : ITargetObject
    {
        public TargetCollection<TTarget> TargetCollection { get; protected set; }

        public WiringObject(string name, string nickname, string description, string category, string subCategory)
            : base(name, nickname, description, category, subCategory)
        {
        }

        public override void AddedToDocument(GH_Document document)
        {
            base.AddedToDocument(document);

            document.ObjectsDeleted += Document_ObjectsDeleted;
        }

        public override void RemovedFromDocument(GH_Document document)
        {
            base.RemovedFromDocument(document);

            document.ObjectsDeleted -= Document_ObjectsDeleted;
        }

        protected abstract void Document_ObjectsDeleted(object sender, GH_DocObjectEventArgs e);
    }
}