namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class Annotation
    {
        public long? AnnotationId { get; set; }

        public AnnotationType AnnotationType { get; set; }

        public string Identifier { get; set; }

        public DataType DataType { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Value { get; set; }
    }
}