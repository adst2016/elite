using Infrastructure.DataBase.Entities;
using Infrastructure.Shared.Components;

namespace Infrastructure.DataBase.Repositories
{
    public interface IRepository<T, IdT> : IRepository where T : EntityBase
    {
        T GetById(IdT id);
    }
}
