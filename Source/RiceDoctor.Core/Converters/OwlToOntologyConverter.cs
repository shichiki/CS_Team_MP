using System;
using System.Collections.Generic;
using System.Xml.Linq;
using RiceDoctor.Core.Ontology;
using Attribute = RiceDoctor.Core.Ontology.Attribute;

namespace RiceDoctor.Core.Converters
{
    public class OwlToOntologyConverter
    {
        public Ontology.Ontology Convert(string xmlString)
        {
            XDocument document = XDocument.Parse(xmlString);

            Ontology.Ontology ontology = new Ontology.Ontology();

            AddDeclarations(document, ontology);

            AddDataPropertyDomains(document, ontology);

            AddDataPropertyRanges(document, ontology);

            return ontology;
        }

        private void AddDeclarations(XDocument document, Ontology.Ontology ontology)
        {
            IEnumerable<XElement> declarations = document.Descendants("{http://www.w3.org/2002/07/owl#}Declaration");

            foreach (XElement declaration in declarations)
            {
                foreach (XElement declarationElement in declaration.Elements())
                {
                    if (declarationElement.Name == "{http://www.w3.org/2002/07/owl#}Class")
                    {
                        if (ontology.Concepts == null)
                        {
                            ontology.Concepts = new List<Concept>();
                        }

                        string iri = declarationElement.Attribute("IRI").Value;

                        ontology.Concepts.Add(new Concept {Name = iri.Substring(1, iri.Length - 1)});
                    }
                    else if (declarationElement.Name == "{http://www.w3.org/2002/07/owl#}DataProperty")
                    {
                        if (ontology.Attributes == null)
                        {
                            ontology.Attributes = new List<Attribute>();
                        }

                        string iri = declarationElement.Attribute("IRI").Value;

                        ontology.Attributes.Add(new Attribute {Name = iri.Substring(1, iri.Length - 1)});
                    }
                }
            }
        }

        private void AddDataPropertyDomains(XDocument document, Ontology.Ontology ontology)
        {
            IEnumerable<XElement> dataPropertyDomains =
                document.Descendants("{http://www.w3.org/2002/07/owl#}DataPropertyDomain");
            foreach (XElement dataPropertyDomain in dataPropertyDomains)
            {
                XElement dataProperty = dataPropertyDomain.Element("{http://www.w3.org/2002/07/owl#}DataProperty");
                XElement _class = dataPropertyDomain.Element("{http://www.w3.org/2002/07/owl#}Class");

                string dataPropertyIri = dataProperty.Attribute("IRI").Value;
                string classIri = _class.Attribute("IRI").Value;

                string dataPropertyName = dataPropertyIri.Substring(1, dataPropertyIri.Length - 1);
                string className = classIri.Substring(1, classIri.Length - 1);

                Attribute attribute = ontology.Attributes.Single(a => a.Name.Equals(dataPropertyName));
                Concept concept = ontology.Concepts.Single(c => c.Name.Equals(className));

                if (concept.Attributes == null)
                {
                    concept.Attributes = new List<string>();
                }

                concept.Attributes.Add(attribute.Name);
            }
        }

        // SQLite Affinities: INTEGER, TEXT, BLOB, REAL, NUMERIC
        // https://www.sqlite.org/datatype3.html
        private void AddDataPropertyRanges(XDocument document, Ontology.Ontology ontology)
        {
            IEnumerable<XElement> dataPropertyRanges =
                document.Descendants("{http://www.w3.org/2002/07/owl#}DataPropertyRange");
            foreach (XElement dataPropertyRange in dataPropertyRanges)
            {
                XElement dataProperty = dataPropertyRange.Element("{http://www.w3.org/2002/07/owl#}DataProperty");
                XElement dataType = dataPropertyRange.Element("{http://www.w3.org/2002/07/owl#}Datatype");

                string dataPropertyIri = dataProperty.Attribute("IRI").Value;
                string dataTypeAbbreviatedIri = dataType.Attribute("abbreviatedIRI").Value;

                string dataPropertyName = dataPropertyIri.Substring(1, dataPropertyIri.Length - 1);
                string owlType = dataTypeAbbreviatedIri;
                string sqlType = null;

                switch (dataTypeAbbreviatedIri)
                {
                    case "xsd:integer":
                        sqlType = "Integer";
                        break;

                    case "xsd:string":
                        sqlType = "Text";
                        break;

                    // BLOB

                    case "owl:real":
                        sqlType = "Real";
                        break;

                    case "xsd:boolean":
                    case "xsd:decimal":
                    case "xsd:dateTime":
                        sqlType = "Numeric";
                        break;

                    default:
                        throw new Exception();
                }

                Attribute attribute = ontology.Attributes.Single(a => a.Name.Equals(dataPropertyName));
                attribute.OwlType = owlType;
                attribute.SqlType = sqlType;
            }
        }
    }
}