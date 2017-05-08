namespace Infrastructure.DataBase.Entities
{
    public class EntityWithDescriptionBase : EntityWithIdBase
    {
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Notes { get; set; }
    }
}
