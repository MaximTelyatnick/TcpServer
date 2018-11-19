using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FirebirdSql.Data.FirebirdClient;
using System;
using TVM_WMS.SERVER.Services;
using TVM_WMS.SERVER.Entities;

namespace TVM_WMS.SERVER.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private WH_Context db;

        public Repository(WH_Context context)
        {
            this.db = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T Create(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return db.Set<T>().Local.Last();
        }

        public void CreateRange(IEnumerable<T> entity)
        {
            db.Set<T>().AddRange(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();

            //using (var dbCtxTxn = db.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        db.Set<T>().Remove(entity);
            //        db.SaveChanges();

            //        dbCtxTxn.Commit();
            //    }
            //    catch (FbException ex)
            //    {
            //        dbCtxTxn.Rollback();
            //    }
            //} 
        }

        public void DeleteAll(IEnumerable<T> entity)
        {
            db.Set<T>().RemoveRange(entity);
            db.SaveChanges();
        }

        public IEnumerable<T> SQLExecuteProc(string executeProcString, params FbParameter[] paramArr)
        {
            return db.Set<T>().SqlQuery(executeProcString, paramArr);
        }

    }
}
