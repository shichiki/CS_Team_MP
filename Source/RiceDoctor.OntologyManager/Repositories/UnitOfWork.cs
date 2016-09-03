using System;
using Microsoft.EntityFrameworkCore;
using RiceDoctor.OntologyManager.Models;

namespace RiceDoctor.OntologyManager.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _dbContext;

        private IRepository<AnnotationAssertion> _annotationAssertion;

        private IRepository<Declaration> _declarationRepository;

        public IRepository<AnnotationAssertion> AnnotationAssertion
            => _annotationAssertion ?? (_annotationAssertion = new GenericRepository<AnnotationAssertion>(_dbContext));

        public IRepository<Declaration> DeclarationRepository
            => _declarationRepository ?? (_declarationRepository = new GenericRepository<Declaration>(_dbContext));

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}