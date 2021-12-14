using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MantenedoraCalidad.Models;
using PagedList;

namespace MantenedoraCalidad.Controllers
{
    [Authorize]
    public class MODELOController : Controller
    {
        private NuevaQAEntities1 db = new NuevaQAEntities1();

        // GET: MODELO
        public ActionResult Index(string searchBy, string search, int? page)
        {
            if (searchBy == "id_modelo")
            {
                return View(db.MODELO.Where(x => x.id_modelo == search || search == null).ToList().ToPagedList(page ?? 1, 10));
            }

            else
            {
                return View(db.MODELO.Where(x => x.nom_modelo.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }

        }

        // GET: MODELO/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODELO mODELO = db.MODELO.Find(id);
            if (mODELO == null)
            {
                return HttpNotFound();
            }
            return View(mODELO);
        }

        // GET: MODELO/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: MODELO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_modelo,nom_modelo,nom_familia,nom_marca")] MODELO mODELO)
        {
            if (ModelState.IsValid)
            {
                db.MODELO.Add(mODELO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mODELO);
        }

        // GET: MODELO/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODELO mODELO = db.MODELO.Find(id);
            if (mODELO == null)
            {
                return HttpNotFound();
            }
            return View(mODELO);
        }

        // POST: MODELO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_modelo,nom_modelo,nom_familia,nom_marca")] MODELO mODELO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODELO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mODELO);
        }

        // GET: MODELO/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODELO mODELO = db.MODELO.Find(id);
            if (mODELO == null)
            {
                return HttpNotFound();
            }
            return View(mODELO);
        }

        // POST: MODELO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MODELO mODELO = db.MODELO.Find(id);
            db.MODELO.Remove(mODELO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
