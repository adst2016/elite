using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Infrastructure.Shared.Initialization
{
    public class InitializationContext
    {
        public ControllerBuilder controllerBuilder { get; private set; }

        private InitializationContext(ControllerBuilder controllerBuilder)
        {
            this.controllerBuilder = controllerBuilder;
        }

        public static InitializationContext Create(ControllerBuilder controllerBuilder)
        {
            return new InitializationContext(controllerBuilder);
        }
    }
}
