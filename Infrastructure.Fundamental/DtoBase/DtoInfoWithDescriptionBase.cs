using System;

namespace Infrastructure.Fundamental.DtoBase
{
    public class DtoInfoWithDescriptionBase : DtoWithSignatureBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public DtoInfoWithDescriptionBase()
        {
        }

        protected DtoInfoWithDescriptionBase(Guid id, string code, string name, string description, string notes)
        {
            Id = id;
            Code = code;
            Name = name;
            Description = description;
            Notes = notes;
        }

        public static DtoInfoWithDescriptionBase Create(Guid id, string code, string name, string description, string notes)
        {
            return new DtoInfoWithDescriptionBase(id, code, name, description, notes);
        }
    }
}
