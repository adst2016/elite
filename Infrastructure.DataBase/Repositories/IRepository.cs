using Infrastructure.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(object id);
    }
}
