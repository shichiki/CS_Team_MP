namespace RiceDoctor.OntologyManager.Models
{
    public partial class DataPropertyDomain
    {
        public long Id { get; set; }
        public long DataPropertyId { get; set; }
        public long ClassId { get; set; }

        public virtual Declaration Class { get; set; }
        public virtual Declaration DataProperty { get; set; }
    }
}