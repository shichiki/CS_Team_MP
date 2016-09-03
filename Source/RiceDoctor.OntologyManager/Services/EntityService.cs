using System;
using System.Collections.Generic;
using System.Linq;
using RiceDoctor.OntologyManager.Models;
using RiceDoctor.OntologyManager.OntologyModels;
using RiceDoctor.OntologyManager.Repositories;

namespace RiceDoctor.OntologyManager.Services
{
    public interface IEntityService
    {
        IEnumerable<Entity> GetAll();

        Entity Get(string name);

        void Add(Entity entity);

        void Update(Entity entity, string oldName);

        void Delete(string name);
    }

    public class EntityService : IEntityService
    {
        private readonly UnitOfWork _unitOfWork;

        public EntityService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Entity> GetAll()
        {
            IEnumerable<Declaration> declarations =
                _unitOfWork.DeclarationRepository.GetMany(d => d.Type.Equals(DeclarationType.Class.ToString()));
            if (declarations == null)
            {
                return null;
            }

            IList<Entity> entities = new List<Entity>();
            foreach (Declaration declaration in declarations)
            {
                entities.Add(CreateEntity(declaration));
            }

            return entities;
        }

        public Entity Get(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            string entityIri = name.Trim();

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entityIri));
            if (declaration == null)
            {
                return null;
            }

            return CreateEntity(declaration);
        }

        public void Add(Entity entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            string entiyIri = entity.Name.Trim();

            Declaration existedDeclaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entiyIri));
            if (existedDeclaration != null)
            {
                throw new Exception("Existed entity cannot be readded.");
            }

            Declaration declaration = new Declaration
            {
                Type = DeclarationType.Class.ToString(),
                Iri = entiyIri
            };

            _unitOfWork.DeclarationRepository.Add(declaration);
            _unitOfWork.Save();
        }

        public void Update(Entity entity, string oldName)
        {
            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            string entityIri = entity.Name.Trim();

            Declaration declaration =
                _unitOfWork.DeclarationRepository.Get(
                    d => d.Iri.Equals(string.IsNullOrEmpty(oldName) ? entityIri : oldName.Trim()));

            if (declaration == null)
            {
                throw new Exception("Entity does not exist.");
            }

            declaration.Iri = entityIri;

            _unitOfWork.DeclarationRepository.Update(declaration);
            _unitOfWork.Save();
        }

        public void Delete(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            string entityIri = name.Trim();

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entityIri));
            if (declaration == null)
            {
                throw new Exception("Entity does not exist.");
            }

            _unitOfWork.DeclarationRepository.Delete(declaration);
            _unitOfWork.Save();
        }

        private static Entity CreateEntity(Declaration declaration)
        {
            if (declaration == null)
            {
                return null;
            }

            Entity entity = new Entity
            {
                Name = declaration.Iri,
                Instances =
                    declaration.ClassAssertionClass?.Select(classAssertion => classAssertion.NamedIndividual.Iri)
                        .ToList()
            };

            if (declaration.AnnotationAssertion != null)
            {
                entity.Annotations = declaration.AnnotationAssertion.Select(annotationAssertion => new Annotation
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
                    Value = annotationAssertion.LiteralValue
                }).ToList();
            }

            return entity;
        }
    }
}