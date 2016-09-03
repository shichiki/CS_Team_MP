namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class DataProperty : Keyword
    {
        public DataType Range { get; set; }

        public DataProperty() : base(DeclarationType.DataProperty)
        {
        }
    }
}