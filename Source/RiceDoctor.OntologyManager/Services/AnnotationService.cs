using System;
using System.Collections.Generic;
using RiceDoctor.OntologyManager.OntologyModels;
using RiceDoctor.OntologyManager.Repositories;

namespace RiceDoctor.OntologyManager.Services
{
    public interface IAnnotationService
    {
        IEnumerable<Annotation> GetAnnotations(string name);
    }

    public class AnnotationService : IAnnotationService
    {
        private readonly UnitOfWork _unitOfWork;

        public AnnotationService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Annotation> GetAnnotations(string name)
        {
            throw new NotImplementedException();
        }
    }
}