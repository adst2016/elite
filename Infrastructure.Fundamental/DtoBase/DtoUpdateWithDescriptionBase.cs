using System;

namespace Infrastructure.Fundamental.DtoBase
{
    public class DtoUpdateWithDescriptionBase : DtoWithSignatureBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public DtoUpdateWithDescriptionBase()
        {
        }

        protected DtoUpdateWithDescriptionBase(Guid id, string code, string name, string description, string notes)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Notes = notes;
        }

        public static DtoUpdateWithDescriptionBase Create(Guid id, string code, string name, string description, string notes)
        {
            return new DtoUpdateWithDescriptionBase(id, code, name, description, notes);
        }
    }
}
