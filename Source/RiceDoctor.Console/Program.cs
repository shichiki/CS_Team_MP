using System.IO;
using RiceDoctor.Core.Converters;
using RiceDoctor.Core.Ontology;

namespace RiceDoctor.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string xmlString = File.ReadAllText(@"G:\Code\CS_Team_MP\OWL\RiceOntology.owl");
            OwlToOntologyConverter converter = new OwlToOntologyConverter();
            Ontology ontology = converter.Convert(xmlString);
        }
    }
}