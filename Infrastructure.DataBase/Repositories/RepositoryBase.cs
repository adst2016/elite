using System;
using Infrastructure.DataBase.Entities;
using Infrastructure.DataBase.NHibernateSession;
using Infrastructure.Shared.Common;
using NHibernate;
using System.Collections.Generic;
using Infrastructure.Common.Authentication;
using System.Security.Claims;
using System.Threading;

namespace Infrastructure.DataBase.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityWithIdBase
    {
        protected ISession Session
        {
            get
            {
                return NHibernateSessionManager.GetSession();
            }
        }

        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(Thread.CurrentPrincipal as ClaimsPrincipal);
            }
        }

        public T GetById(Guid id)
        {
            return Session.Get<T>(id);
        }

        public IList<T> GetAll()
        {
            return Session.CreateCriteria<T>().List<T>();
        }        

        public MethodResult SaveAndFlush(T entity)
        {            
            entity.Id = Guid.NewGuid();

            entity.TimeCreation = DateTime.Now;
            entity.TimeUpdate = DateTime.Now;

            entity.UserCreation = CurrentUser.Id;
            entity.UserUpdate = CurrentUser.Id;

            Session.Save(entity);
            Session.Flush();

            return MethodResult.ReturnSuccess();
        }

        public MethodResult SaveOrUpdateAndFlush(T entity)
        {
            if (entity.Id == Guid.Empty)
                return SaveAndFlush(entity);

            entity.TimeUpdate = DateTime.Now;
            entity.UserUpdate = CurrentUser.Id;

            Session.SaveOrUpdate(entity);
            Session.Flush();

            return MethodResult.ReturnSuccess();
        }

        public MethodResult DeleteAndFlush(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
            return MethodResult.ReturnSuccess();
        }
    }
}
