namespace RiceDoctor.OntologyManager.OntologyModels
{
    // References:
    // - http://www.xml.dvint.com/docs/SchemaDataTypesQR-2.pdf
    // - https://www.w3.org/2001/XMLSchema-datatypes
    public class DataType
    {
        public string Iri { get; set; }

        public string AbbreviatedIri { get; set; }

        public string Kind { get; set; }

        public string Definition { get; set; }
    }
}