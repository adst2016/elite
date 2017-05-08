
namespace Infrastructure.Fundamental.DtoBase
{
    public class DtoCreateWithDescriptionBase : DtoWithSignatureBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public DtoCreateWithDescriptionBase()
        {
        }
    }
}
