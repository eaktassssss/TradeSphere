using ProductService.Application.Interfaces.UnitOfWork;
using ProductService.Persistence.Context.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Persistence.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDdContext _context;

        public UnitOfWork(ProductDdContext context)
        {
            _context = context;
        }
        public async Task<bool> CommitAsync()
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
