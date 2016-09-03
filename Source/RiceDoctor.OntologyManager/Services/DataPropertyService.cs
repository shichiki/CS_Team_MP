using System;
using System.Collections.Generic;
using RiceDoctor.OntologyManager.Models;
using RiceDoctor.OntologyManager.OntologyModels;
using RiceDoctor.OntologyManager.Repositories;

namespace RiceDoctor.OntologyManager.Services
{
    public interface IDataPropertyService
    {
        IEnumerable<DataProperty> GetAll();

        IEnumerable<Entity> GetDomains(string name);
    }

    public class DataPropertyService : IDataPropertyService
    {
        private readonly UnitOfWork _unitOfWork;

        public DataPropertyService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<DataProperty> GetAll()
        {
            IEnumerable<Declaration> declarations =
                _unitOfWork.DeclarationRepository.GetMany(d => d.Type.Equals(DeclarationType.DataProperty.ToString()));

            if (declarations == null)
            {
                return null;
            }

            IList<DataProperty> dataProperties = new List<DataProperty>();
            foreach (Declaration declaration in declarations)
            {
                dataProperties.Add(new DataProperty
                {
                    Name = declaration.Iri,
                    VietnameseName = declaration.Keyword.VietnameseName,
                    Definition = declaration.Keyword.Definition
                });
            }

            return dataProperties;
        }

        public IEnumerable<Entity> GetDomains(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Data property's name cannot be null.");
            }

            string dataPropertyIri = name.Trim();

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(dataPropertyIri));
            if (declaration == null)
            {
                throw new Exception("Data property does not exist.");
            }

            if (declaration.DataPropertyAssertionDataProperty == null)
            {
                return null;
            }

            IList<Entity> entities = new List<Entity>();
            foreach (DataPropertyDomain dataProperty in declaration.DataPropertyDomainDataProperty)
            {
                Declaration entityDeclaration = dataProperty.Class;

                entities.Add(new Entity
                {
                    Name = entityDeclaration.Iri,
                    VietnameseName = entityDeclaration.Keyword.VietnameseName,
                    Definition = entityDeclaration.Keyword.Definition
                });
            }

            return entities;
        }
    }
}