using Infrastructure.DataBase.Entities;
using Infrastructure.Shared.Common;
using Infrastructure.Shared.Components;
using System.Collections.Generic;

namespace Infrastructure.DataBase.Repositories
{
    public interface IRepository<T, IdT> : IRepository where T : EntityBase
    {
        T GetById(IdT id);

        IList<T> GetAll();
        
        MetodResult SaveAndFlush(T entity);
        
        MetodResult SaveOrUpdateAndFlush(T entity);
    }
}
