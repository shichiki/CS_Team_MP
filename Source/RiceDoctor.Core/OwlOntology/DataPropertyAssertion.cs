namespace RiceDoctor.Core.OwlOntology
{
    public class DataPropertyAssertion
    {
        public static string[] Datatypes =
        {
            "string" // http://www.w3.org/2001/XMLSchema#string
        };

        public string DataProperty { get; set; }
        public string NamedIndividual { get; set; }
        public string LiteralDatatype { get; set; }
        public string LiteralValue { get; set; }
    }
}