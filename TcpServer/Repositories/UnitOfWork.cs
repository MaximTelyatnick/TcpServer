using System;
using System.Collections.Generic;
using TVM_WMS.SERVER.Entities;
using TVM_WMS.SERVER.Services;


namespace TVM_WMS.SERVER.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WH_Context db;
        private bool disposed;
        private Dictionary<Type, object> repositories;

        public UnitOfWork(string connectionString)
        {
            db = new WH_Context(connectionString);
            repositories = new Dictionary<Type, object>();
            disposed = false;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (repositories.ContainsKey(typeof(T)))
            {
                return repositories[typeof(T)] as IRepository<T>;
            }

            var repository = new Repository<T>(db);

            repositories.Add(typeof(T), repository);

            return repository;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
