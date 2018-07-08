using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGV.Web.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();            
            return View(obj.GetDataPersonasAll());
        }

        public ActionResult Create()
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();
            ViewBag.ciudadid = new SelectList(obj.GetDataCiudadesAll(), "id", "nombre");
            return View();
        }

        // POST: x/Create
        [HttpPost]
        public ActionResult Create(SGV.Web.ServiceReferenceVentas.Persona persona)
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();
            obj.CreatePersona(persona);
            return RedirectToAction("Index");
        }


        // GET: x/Edit/5
        public ActionResult Edit(int id)
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();
            var persona = obj.GetDataPersona(id);
            ViewBag.ciudadid = new SelectList(obj.GetDataCiudadesAll(),"id","nombre",persona.ciudadid);
            return View(persona);
        }

        // POST: x/Edit/5
        [HttpPost]
        public ActionResult Edit(SGV.Web.ServiceReferenceVentas.Persona persona)
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();
            obj.UpdatePersona(persona);
            return RedirectToAction("Index");
        }



        // GET: x/Delete/5
        public ActionResult Delete(int id)
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();
            return View(obj.GetDataPersona(id));
        }

        // POST: x/Delete/5
        [HttpPost]
        public ActionResult Delete(SGV.Web.ServiceReferenceVentas.Persona persona)
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();
            obj.DeletePersona(persona.id);
            return RedirectToAction("Index");            
        }

        // GET: x/Details/5
        public ActionResult Details(int id)
        {
            ServiceReferenceVentas.ServiceVentasClient obj = new ServiceReferenceVentas.ServiceVentasClient();
            return View(obj.GetDataPersona(id));
        }


    }
}