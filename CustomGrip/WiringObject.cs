using Grasshopper.Kernel;

namespace CustomGrip
{
    public abstract class WiringObject<TTarget> : GH_DocumentObject//, IGH_Param
    {
        public WiringObject(string name, string nickname, string description, string category, string subCategory)
            : base(name, nickname, description, category, subCategory)
        {
        }

        /*

        public GH_ParamAccess Access { get; set; }

        public GH_DataMapping DataMapping { get; set; }

        public GH_ParamData DataType { get; }

        public bool HasProxySources { get; }

        public bool IsDataProvider { get; }

        public GH_ParamKind Kind { get; }

        public bool Locked { get; set; }

        public bool MutableNickName { get; set; }

        public bool Optional { get; set; }

        public GH_SolutionPhase Phase { get; set; }

        public TimeSpan ProcessorTime { get; }

        public int ProxySourceCount { get; }

        public IList<IGH_Param> Recipients { get; }

        public bool Reverse { get; set; }

        public GH_RuntimeMessageLevel RuntimeMessageLevel { get; }

        public bool Simplify { get; set; }

        public int SourceCount { get; }

        public IList<IGH_Param> Sources { get; }

        public GH_StateTagList StateTags { get; }

        public Type Type { get; }

        public string TypeName { get; }

        public IGH_Structure VolatileData { get; }

        public int VolatileDataCount { get; }

        public GH_ParamWireDisplay WireDisplay { get; set; }

        */
    }
}