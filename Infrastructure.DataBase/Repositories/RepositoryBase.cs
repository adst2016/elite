using Infrastructure.DataBase.Entities;
using NHibernate;

namespace Infrastructure.DataBase.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        private readonly ISession session;

        public RepositoryBase(ISession session)
        {
            this.session = session;
        }

        public T GetById(object id)
        {
            return session.Get<T>(id);
        }
    }
}
