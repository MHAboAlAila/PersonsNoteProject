using Microsoft.EntityFrameworkCore.Storage;
using PersonsNoteBook.Core.Interfaces;
using System.Data.Entity.Validation;

namespace PersonsNoteBook.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DBContextClass _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private IDbContextTransaction _transaction;

        public UnitOfWork(DBContextClass context)
        {
            _context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CreateTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }

        public async void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbex)
            {
                foreach (var validationErrors in dbex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage = _errorMessage + $"property: {validationError.PropertyName} Error: {validationError.ErrorMessage} {Environment.NewLine}";
                    }
                }
                throw new Exception(_errorMessage, dbex);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }
    }
}
