using Infrastructure.DataBase.Entities;
using Infrastructure.DataBase.NHibernateSession;
using NHibernate;

namespace Infrastructure.DataBase.Repositories
{
    public class RepositoryBase<T, IdT> : IRepository<T, IdT> where T : EntityBase
    {
        private ISession Session
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
    }
}
