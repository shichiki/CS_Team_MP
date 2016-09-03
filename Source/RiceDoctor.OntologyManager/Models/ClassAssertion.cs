namespace RiceDoctor.OntologyManager.Models
{
    public partial class ClassAssertion
    {
        public long Id { get; set; }
        public long ClassId { get; set; }
        public long NamedIndividualId { get; set; }

        public virtual Declaration Class { get; set; }
        public virtual Declaration NamedIndividual { get; set; }
    }
}