using Infrastructure.DataBase.Entities;
using Infrastructure.Shared.Common;
using Infrastructure.Shared.Components;
using System;
using System.Collections.Generic;

namespace Infrastructure.DataBase.Repositories
{
    public interface IRepository<T> : IRepository where T : EntityBase
    {
        T GetById(Guid id);

        IList<T> GetAll();
        
        MethodResult SaveAndFlush(T entity);
        
        MethodResult SaveOrUpdateAndFlush(T entity);

        MethodResult DeleteAndFlush(T entity);
    }
}
