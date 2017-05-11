using Infrastructure.DataBase.Entities;
using Infrastructure.DataBase.Repositories;
using Infrastructure.Fundamental.DtoBase;
using Infrastructure.Shared.Common;
using Infrastructure.Shared.Components;
using Infrastructure.Fundamental.MappingServiceBase;
using System;
using System.Collections.Generic;

namespace Infrastructure.Fundamental.ServiceBase
{
    public interface IServiceCrudBase<T, DtoInfoT, DtoCreateT> : IService where T : EntityWithDescriptionBase
                                                                          where DtoInfoT : DtoInfoWithDescriptionBase
                                                                          where DtoCreateT : DtoCreateWithDescriptionBase
    {
        List<DtoInfoT> GetAll();

        DtoInfoT GetById(Guid id);

        MethodResult Create(DtoCreateT formTypeCreateDto);

        MethodResult Update(DtoInfoT formTypeUpdateDto);

        MethodResult Delete(Guid id);
    }

    public class ServiceCrudBase<T, DtoInfoT, DtoCreateT> 
        : IServiceCrudBase<T, DtoInfoT, DtoCreateT> where T : EntityWithDescriptionBase
                                                    where DtoInfoT : DtoInfoWithDescriptionBase
                                                    where DtoCreateT : DtoCreateWithDescriptionBase
    {
        private readonly IRepository<T> repository;
        private readonly IMapping<T, DtoInfoT, DtoCreateT> mapping;

        protected ServiceCrudBase(
            IRepository<T> repository,
            IMapping<T, DtoInfoT, DtoCreateT> mapping)
        {
            this.repository = repository;
            this.mapping = mapping;
        }

        public MethodResult Create(DtoCreateT createDto)
        {
            var newEntity = mapping.MapToNewEntity(createDto);
            return repository.SaveAndFlush(newEntity);            
        }

        public MethodResult Delete(Guid id)
        {
            var entity = repository.GetById(id);
            return repository.DeleteAndFlush(entity);
        }

        public virtual List<DtoInfoT> GetAll()
        {
            var lista = repository.GetAll() as List<T>;
            var destList = new List<DtoInfoT>();

            foreach (var item in lista)
            {
                destList.Add(mapping.MapToInfoDto(item));
            }
            return destList;
        }

        public DtoInfoT GetById(Guid id)
        {
            var entity = repository.GetById(id);
            return mapping.MapToInfoDto(entity);
        }

        public MethodResult Update(DtoInfoT updateDto)
        {
            var entity = repository.GetById(updateDto.Id);

            if (entity == null)
                return MethodResult.ReturnError("Brak encji o id:" + updateDto.Id);

            var entityUpdated = mapping.MapToEntity(entity, updateDto);

            return repository.SaveOrUpdateAndFlush(entityUpdated);
        }
    }
}
