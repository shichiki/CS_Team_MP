using System.Linq;
using RiceDoctor.OntologyManager.Models;
using RiceDoctor.OntologyManager.OntologyModels;

namespace RiceDoctor.OntologyManager.Services
{
    internal static class HelperService
    {
        public static Annotation CreateAnnotation(AnnotationAssertion annotationAssertion)
        {
            return new Annotation
            {
                AnnotationType =
                    DefaultValue.AnnotationTypes.FirstOrDefault(
                        at => at.Value.Equals(annotationAssertion.AnnotationPropertyAbbreviatedIri)).Key,
                DataType =
                    DefaultValue.DataTypes.FirstOrDefault(
                        dt => dt.Value.Equals(annotationAssertion.LiteralDatatypeIri)).Key,
                LanguageType =
                    DefaultValue.LanguageTypes.FirstOrDefault(
                        lt => lt.Value.Equals(annotationAssertion.LiteralXmlLang)).Key,
                Identifier = annotationAssertion.Declaration.Iri,
                Value = annotationAssertion.LiteralValue
            };
        }

        public static DataProperty CreateDataProperty(Declaration dataPropertyDeclaration)
        {
            if (dataPropertyDeclaration == null)
            {
                return null;
            }

            DataProperty dataProperty = new DataProperty
            {
                DeclarationId = dataPropertyDeclaration.Id,
                Name = dataPropertyDeclaration.Iri,
                Range =
                    DefaultValue.DataTypes.FirstOrDefault(
                        dt => dt.Value.Equals(dataPropertyDeclaration.DataPropertyRange.DatatypeAbbreviatedIri)).Key,
                Domains = dataPropertyDeclaration.DataPropertyDomainDataProperty?.Select(dpd => dpd.Class.Iri).ToList(),
                Annotations = dataPropertyDeclaration.AnnotationAssertion?.Select(CreateAnnotation).ToList()
            };

            return dataProperty;
        }

        public static Entity CreateEntity(Declaration entityEeclaration)
        {
            if (entityEeclaration == null)
            {
                return null;
            }

            Entity entity = new Entity
            {
                DeclarationId = entityEeclaration.Id,
                Name = entityEeclaration.Iri,
                Instances =
                    entityEeclaration.ClassAssertionClass?.Select(ca => ca.NamedIndividual.Iri)
                        .ToList(),
                Annotations = entityEeclaration.AnnotationAssertion?.Select(CreateAnnotation).ToList()
            };

            return entity;
        }
    }
}