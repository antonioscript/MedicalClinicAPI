using MedicalClinic.Application.Interfaces.Repositories;
using MedicalClinic.Infrastructure.MedicalClinic.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool disposed;

        public bool HasChanges => _dbContext != null ? _dbContext.HasChanges : false;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task Rollback()
        {
            throw new NotImplementedException();
        }



        //public Task Rollback()
        //{
        //    //todo
        //    return Task.CompletedTask;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposed)
        //    {
        //        if (disposing)
        //        {
        //            _dbContext.Dispose();
        //        }
        //    }

        //    disposed = true;
        //}
    }
}
