using Infrastructure.DataBase.Entities;
using Infrastructure.Fundamental.DtoBase;
using Infrastructure.Shared.Components;

namespace Solano.Web.Areas.Main.Models.MappingServices
{
    public interface IMapping<T, DtoInfoT, DtoCreateT> : IComponent where T : EntityWithDescriptionBase
                                                                    where DtoInfoT : DtoInfoWithDescriptionBase
                                                                    where DtoCreateT : DtoCreateWithDescriptionBase
    {
        T MapToNewEntity(DtoCreateT dtoCreate);

        DtoInfoT MapToInfoDto(T Entity);

        T MapToEntity(T entity, DtoInfoT dtoInfo);
    }
}