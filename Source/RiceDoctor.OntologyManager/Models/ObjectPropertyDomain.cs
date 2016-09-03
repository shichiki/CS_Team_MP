namespace RiceDoctor.OntologyManager.Models
{
    public partial class ObjectPropertyDomain
    {
        public long Id { get; set; }
        public long ObjectPropertyId { get; set; }
        public long ClassId { get; set; }

        public virtual Declaration Class { get; set; }
        public virtual Declaration ObjectProperty { get; set; }
    }
}