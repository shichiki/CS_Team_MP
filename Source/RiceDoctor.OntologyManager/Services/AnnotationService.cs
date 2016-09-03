using System;
using System.Collections.Generic;
using System.Linq;
using RiceDoctor.OntologyManager.Models;
using RiceDoctor.OntologyManager.OntologyModels;
using RiceDoctor.OntologyManager.Repositories;

namespace RiceDoctor.OntologyManager.Services
{
    public interface IAnnotationService
    {
        IEnumerable<Annotation> GetAnnotations(string identifier);

        void Add(Annotation annotation);

        void Update(Annotation annotation);

        void Delete(long annotationId);
    }

    public class AnnotationService : IAnnotationService
    {
        private readonly UnitOfWork _unitOfWork;

        public AnnotationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Annotation> GetAnnotations(string identifier)
        {
            if (string.IsNullOrEmpty(identifier))
            {
                throw new Exception("Identifier's name cannot be null.");
            }

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(identifier.Trim()));
            if (declaration == null)
            {
                throw new Exception("Identifier does not exist.");
            }

            return declaration.AnnotationAssertion?.Select(HelperService.CreateAnnotation).ToList();
        }

        public void Add(Annotation annotation)
        {
            CheckValidSyntax(annotation);

            Declaration declaration =
                _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(annotation.Identifier.Trim()));
            if (declaration == null)
            {
                throw new Exception("Annotation's identifier does not exist.");
            }

            AnnotationAssertion annotationAssertion = new AnnotationAssertion
            {
                AnnotationPropertyAbbreviatedIri = DefaultValue.AnnotationTypes[annotation.AnnotationType],
                IriId = declaration.Id,
                LiteralDatatypeIri = DefaultValue.DataTypes[annotation.DataType],
                LiteralValue = annotation.Value.Trim(),
                LiteralXmlLang =
                    annotation.DataType == DataType.PlainLiteral
                        ? DefaultValue.LanguageTypes[annotation.LanguageType]
                        : ""
            };

            _unitOfWork.AnnotationAssertion.Add(annotationAssertion);
            _unitOfWork.Save();

            annotation.AnnotationId = annotationAssertion.Id;
        }

        public void Update(Annotation annotation)
        {
            CheckValidSyntax(annotation);

            if (annotation.AnnotationId == null)
            {
                throw new Exception("Annotation's annotation id cannot be null.");
            }

            Declaration declaration =
                _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(annotation.Identifier.Trim()));
            if (declaration == null)
            {
                throw new Exception("Annotation's identifier does not exist.");
            }

            AnnotationAssertion annotationAssertion =
                _unitOfWork.AnnotationAssertion.Get(aa => aa.Id == annotation.AnnotationId);

            if (annotationAssertion == null)
            {
                throw new Exception("Annotation does not exist.");
            }

            annotationAssertion.AnnotationPropertyAbbreviatedIri =
                DefaultValue.AnnotationTypes[annotation.AnnotationType];
            annotationAssertion.IriId = declaration.Id;
            annotationAssertion.LiteralDatatypeIri = DefaultValue.DataTypes[annotation.DataType];
            annotationAssertion.LiteralValue = annotation.Value.Trim();
            annotationAssertion.LiteralXmlLang = annotation.DataType == DataType.PlainLiteral
                ? DefaultValue.LanguageTypes[annotation.LanguageType]
                : "";

            _unitOfWork.AnnotationAssertion.Update(annotationAssertion);
            _unitOfWork.Save();
        }

        public void Delete(long annotationId)
        {
            AnnotationAssertion annotationAssertion = _unitOfWork.AnnotationAssertion.Get(aa => aa.Id == annotationId);
            if (annotationAssertion == null)
            {
                throw new Exception("Annotation does not exist.");
            }

            _unitOfWork.AnnotationAssertion.Delete(annotationAssertion);
            _unitOfWork.Save();
        }

        private static void CheckValidSyntax(Annotation annotation)
        {
            if (annotation == null)
            {
                throw new Exception("Annotation cannot be null.");
            }

            if (!DefaultValue.AnnotationTypes.ContainsKey(annotation.AnnotationType))
            {
                throw new Exception("Annotation's annotation type is not supported.");
            }

            if (!DefaultValue.DataTypes.ContainsKey(annotation.DataType))
            {
                throw new Exception("Annotation's data type is not supported.");
            }

            if (annotation.DataType == DataType.PlainLiteral &&
                DefaultValue.DataTypes.ContainsKey(DataType.PlainLiteral) &&
                annotation.LanguageType != LanguageType.Undefined)
            {
                throw new Exception("Annotation's language type is not supported.");
            }

            if (string.IsNullOrEmpty(annotation.Identifier))
            {
                throw new Exception("Annotation's identifier cannot be null.");
            }

            if (string.IsNullOrEmpty(annotation.Value))
            {
                throw new Exception("Annotation's value cannot be null.");
            }
        }
    }
}