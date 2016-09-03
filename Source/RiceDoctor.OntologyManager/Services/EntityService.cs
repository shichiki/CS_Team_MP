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

        Entity Get(string entityName);

        void Add(Entity entity);

        void Update(Entity entity);

        void Delete(string entityName);
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

            return declarations?.Select(HelperService.CreateEntity).ToList();
        }

        public Entity Get(string entityName)
        {
            if (string.IsNullOrEmpty(entityName))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entityName.Trim()));

            return declaration == null ? null : HelperService.CreateEntity(declaration);
        }

        public void Add(Entity entity)
        {
            CheckValidSyntax(entity);

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

            entity.DeclarationId = declaration.Id;
        }

        public void Update(Entity entity)
        {
            CheckValidSyntax(entity);

            if (entity.DeclarationId == null)
            {
                throw new Exception("Entity's declaration id cannot be null.");
            }

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Id == entity.DeclarationId);
            if (declaration == null)
            {
                throw new Exception("Entity does not exist.");
            }

            declaration.Iri = entity.Name.Trim();

            _unitOfWork.DeclarationRepository.Update(declaration);
            _unitOfWork.Save();
        }

        public void Delete(string entityName)
        {
            if (string.IsNullOrEmpty(entityName))
            {
                throw new Exception("Entity's name cannot be null.");
            }

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(entityName.Trim()));
            if (declaration == null)
            {
                throw new Exception("Entity does not exist.");
            }

            _unitOfWork.DeclarationRepository.Delete(declaration);
            _unitOfWork.Save();
        }

        private void CheckValidSyntax(Entity entity)
        {
            if (entity == null)
            {
                throw new Exception("Entity cannot be null.");
            }

            if (string.IsNullOrEmpty(entity.Name))
            {
                throw new Exception("Entity's name cannot be null.");
            }
        }
    }
}