using System;
using System.Collections.Generic;
using System.Linq;
using RiceDoctor.OntologyManager.Models;
using RiceDoctor.OntologyManager.OntologyModels;
using RiceDoctor.OntologyManager.Repositories;

namespace RiceDoctor.OntologyManager.Services
{
    public interface IDataPropertyService
    {
        IEnumerable<DataProperty> GetAll();

        DataProperty Get(string dataPropertyName);

        void Add(DataProperty dataProperty);

        void Update(DataProperty dataProperty);

        void Delete(string dataPropertyName);
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

            return declarations?.Select(HelperService.CreateDataProperty).ToList();
        }

        public DataProperty Get(string dataPropertyName)
        {
            if (string.IsNullOrEmpty(dataPropertyName))
            {
                throw new Exception("Data property's name cannot be null.");
            }

            string dataPropertyIri = dataPropertyName.Trim();

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(dataPropertyIri));
            if (declaration == null)
            {
                return null;
            }

            return HelperService.CreateDataProperty(declaration);
        }

        public void Add(DataProperty dataProperty)
        {
            CheckValidSyntax(dataProperty);

            string dataPropertyIri = dataProperty.Name.Trim();

            Declaration existedDeclaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(dataPropertyIri));
            if (existedDeclaration != null)
            {
                throw new Exception("Existed data property cannot be readded.");
            }

            Declaration declaration = new Declaration
            {
                Type = DeclarationType.DataProperty.ToString(),
                Iri = dataPropertyIri,
                DataPropertyRange = new DataPropertyRange
                {
                    DatatypeAbbreviatedIri = DefaultValue.DataTypes[dataProperty.Range]
                }
            };

            _unitOfWork.DeclarationRepository.Add(declaration);
            _unitOfWork.Save();

            dataProperty.DeclarationId = declaration.Id;
        }

        public void Update(DataProperty dataProperty)
        {
            CheckValidSyntax(dataProperty);

            if (dataProperty.DeclarationId == null)
            {
                throw new Exception("Data property's declaration id cannot be null.");
            }

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Id == dataProperty.DeclarationId);
            if (declaration == null)
            {
                throw new Exception("Data property does not exist.");
            }

            declaration.Iri = dataProperty.Name.Trim();
            if (declaration.DataPropertyRange == null)
            {
                declaration.DataPropertyRange = new DataPropertyRange();
            }
            declaration.DataPropertyRange.DatatypeAbbreviatedIri = DefaultValue.DataTypes[dataProperty.Range];

            _unitOfWork.DeclarationRepository.Update(declaration);
            _unitOfWork.Save();
        }

        public void Delete(string dataPropertyName)
        {
            if (string.IsNullOrEmpty(dataPropertyName))
            {
                throw new Exception("Data property's name cannot be null.");
            }

            Declaration declaration = _unitOfWork.DeclarationRepository.Get(d => d.Iri.Equals(dataPropertyName.Trim()));
            if (declaration == null)
            {
                throw new Exception("Data property does not exist.");
            }

            _unitOfWork.DeclarationRepository.Delete(declaration);
            _unitOfWork.Save();
        }

        private void CheckValidSyntax(DataProperty dataProperty)
        {
            if (dataProperty == null)
            {
                throw new Exception("Data property cannot be null.");
            }

            if (string.IsNullOrEmpty(dataProperty.Name))
            {
                throw new Exception("Data property's name cannot be null.");
            }

            if (dataProperty.Range == DataType.PlainLiteral || !DefaultValue.DataTypes.ContainsKey(dataProperty.Range))
            {
                throw new Exception("Data property's range is not supported.");
            }
        }
    }
}