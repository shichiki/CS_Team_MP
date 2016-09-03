namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class Annotation
    {
        public AnnotationType AnnotationType { get; set; }

        public string Name { get; set; }

        public DataType DataType { get; set; }

        public LanguageType LanguageType { get; set; }

        public string Value { get; set; }
    }
}