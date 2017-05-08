using System;
using System.Net;
using System.Web.Mvc;
using Infrastructure.Fundamental.Controllers;
using Infrastructure.Fundamental.ServiceBase;
using Infrastructure.DataBase.Entities;
using Infrastructure.Fundamental.DtoBase;

namespace Infrastructure.Fundamental.ControllerBase
{
    public class AppCrudControllerBase<T, DtoInfoT, DtoCreateT, IServiceType> : AppControllerBase
                                                        where T : EntityWithDescriptionBase
                                                        where DtoInfoT : DtoInfoWithDescriptionBase
                                                        where DtoCreateT : DtoCreateWithDescriptionBase
                                                        where IServiceType : IServiceCrudBase<T, DtoInfoT, DtoCreateT>

    {
        protected readonly IServiceType service;

        public AppCrudControllerBase(IServiceType service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View(service.GetAll());
        }
    }
}
