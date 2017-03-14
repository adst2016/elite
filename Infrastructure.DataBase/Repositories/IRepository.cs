using Infrastructure.DataBase.Entities;

namespace Infrastructure.DataBase.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(object id);
    }
}
