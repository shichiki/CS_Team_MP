namespace RiceDoctor.OntologyManager.OntologyModels
{
    public class Keyword
    {
        public Keyword(DeclarationType declarationType)
        {
            DeclarationType = declarationType;
        }

        public string Name { get; set; }

        public string VietnameseName { get; set; }

        public string Definition { get; set; }

        public DeclarationType DeclarationType { get; }
    }
}