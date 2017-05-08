using Infrastructure.Shared.Components;
using System;

namespace Infrastructure.Fundamental.DtoBase
{
    public class DtoWithSignatureBase : IComponent
    {
        public Guid Id { get; set; }

        public DateTime TimeCreation { get; set; }
        public DateTime TimeUpdate { get; set; }

        public Guid UserCreation { get; set; }
        public Guid UserUpdate { get; set; }

    }
}
