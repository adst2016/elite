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

        public virtual ActionResult Index()
        {
            return View(service.GetAll());
        }

        public virtual ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var infoDto = service.GetById(id.Value);
            if (infoDto == null)
            {
                return HttpNotFound();
            }
            return View(infoDto);
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(DtoCreateT createDto)
        {
            if (ModelState.IsValid)
            {
                service.Create(createDto);
                return RedirectToAction("Index");
            }

            return View(createDto);
        }

        public virtual ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var infoDto = service.GetById(id.Value);

            if (infoDto == null)
            {
                return HttpNotFound();
            }

            return View(infoDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(DtoInfoT infoDto)
        {
            if (ModelState.IsValid)
            {
                service.Update(infoDto);
                return RedirectToAction("Index");
            }
            return View(infoDto);
        }

        public virtual ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var infoDto = service.GetById(id.Value);
            if (infoDto == null)
            {
                return HttpNotFound();
            }
            return View(infoDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(Guid id)
        {
            service.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
