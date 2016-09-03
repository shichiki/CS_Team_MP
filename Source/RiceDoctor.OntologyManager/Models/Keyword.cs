namespace RiceDoctor.OntologyManager.Models
{
    public partial class Keyword
    {
        public long Id { get; set; }
        public string VietnameseName { get; set; }
        public string Definition { get; set; }
        public long DeclarationId { get; set; }

        public virtual Declaration Declaration { get; set; }
    }
}