namespace RiceDoctor.Core.OwlOntology
{
    public class Declaration
    {
        public enum Type
        {
            Class,
            DataProperty,
            NamedIndividual,
            ObjectProperty
        }

        public Type DeclarationType { get; set; }
        public string Value { get; set; }
    }
}