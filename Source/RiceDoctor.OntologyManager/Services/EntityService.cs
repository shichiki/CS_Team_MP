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

        void Update(Entity entity);

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
                Entity entity = CreateEntity(declaration);
                entity.Instances = CreateInstances(entity);

                entities.Add(entity);
            }

            return entities;
        }

        public Entity Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            string entityIri = name.Trim();

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entityIri));
            if (declaration == null)
            {
                return null;
            }

            Entity entity = CreateEntity(declaration);
            entity.Instances = CreateInstances(entity);

            return entity;
        }

        public void Add(Entity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            string entiyIri = entity.Name.Trim();
            string entityVietnameseName = string.IsNullOrWhiteSpace(entity.VietnameseName)
                ? ""
                : entity.VietnameseName.Trim();
            string entityDefinition = string.IsNullOrWhiteSpace(entity.Definition) ? "" : entity.Definition.Trim();

            Declaration existedDeclaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entiyIri));
            if (existedDeclaration != null)
            {
                throw new Exception("Existed entity cannot be readded.");
            }

            Declaration declaration = new Declaration
            {
                Type = DeclarationType.Class.ToString(),
                Iri = entiyIri,
                Keyword = new Models.Keyword
                {
                    VietnameseName = entityVietnameseName,
                    Definition = entityDefinition
                }
            };

            _unitOfWork.DeclarationRepository.Add(declaration);
            _unitOfWork.Save();
        }

        public void Update(Entity entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            string entityIri = entity.Name.Trim();
            string entityVietnameseName = string.IsNullOrWhiteSpace(entity.VietnameseName)
                ? ""
                : entity.VietnameseName.Trim();
            string entityDefinition = string.IsNullOrWhiteSpace(entity.Definition) ? "" : entity.Definition.Trim();

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entityIri));
            if (declaration == null)
            {
                throw new Exception("Entity does not exist.");
            }

            declaration.Iri = entityIri;
            declaration.Keyword.VietnameseName = entityVietnameseName;
            declaration.Keyword.Definition = entityDefinition;

            _unitOfWork.DeclarationRepository.Update(declaration);
            _unitOfWork.Save();
        }

        public void Delete(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
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

        private Entity CreateEntity(Declaration declaration)
        {
            if (declaration == null)
            {
                return null;
            }

            return new Entity
            {
                Name = declaration.Iri,
                VietnameseName = declaration.Keyword.VietnameseName,
                Definition = declaration.Keyword.Definition
            };
        }

        private IEnumerable<string> CreateInstances(Entity entity)
        {
            if (entity == null)
            {
                return null;
            }

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entity.Name));

            return
                declaration?.ClassAssertionClass?.Select(classAssertion => classAssertion.NamedIndividual.Iri).ToList();
        }
    }
}