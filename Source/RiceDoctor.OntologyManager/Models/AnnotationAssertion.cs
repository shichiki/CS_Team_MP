namespace RiceDoctor.OntologyManager.Models
{
    public partial class AnnotationAssertion
    {
        public long Id { get; set; }
        public string AnnotationPropertyAbbreviatedIri { get; set; }
        public long IriId { get; set; }
        public string LiteralXmlLang { get; set; }
        public string LiteralDatatypeIri { get; set; }
        public string LiteralValue { get; set; }

        public virtual Declaration Declaration { get; set; }
    }
}