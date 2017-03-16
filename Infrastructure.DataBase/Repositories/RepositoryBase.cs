using System;
using Infrastructure.DataBase.Entities;
using Infrastructure.DataBase.NHibernateSession;
using Infrastructure.Shared.Common;
using NHibernate;
using System.Collections.Generic;

namespace Infrastructure.DataBase.Repositories
{
    public class RepositoryBase<T, IdT> : IRepository<T, IdT> where T : EntityWithIdBase
    {
        protected ISession Session
        {
            get
            {
                return NHibernateSessionManager.GetSession();
            }
        }        

        public T GetById(IdT id)
        {
            return Session.Get<T>(id);
        }

        public IList<T> GetAll()
        {
            return Session.CreateCriteria<T>().List<T>();
        }        

        public MetodResult SaveAndFlush(T entity)
        {
            entity.TimeCreation = DateTime.Now;
            entity.TimeUpdate = DateTime.Now;

            Session.Save(entity);
            Session.Flush();

            return MetodResult.ReturnSuccess();
        }

        public MetodResult SaveOrUpdateAndFlush(T entity)
        {
            if (entity.Id == Guid.Empty)
                return SaveAndFlush(entity);

            entity.TimeUpdate = DateTime.Now;

            Session.SaveOrUpdate(entity);
            Session.Flush();

            return MetodResult.ReturnSuccess();
        }
    }
}
