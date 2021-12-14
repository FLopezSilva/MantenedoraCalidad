using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MantenedoraCalidad.Models;

namespace MantenedoraCalidad.Controllers
{
    public class COCINAsController : Controller
    {
        private NuevaQAEntities1 db = new NuevaQAEntities1();

        // GET: COCINAs
        public ActionResult Index()
        {
            var cOCINA = db.COCINA.Include(c => c.MODELO).Include(c => c.N_ENSAYO);
            return View(cOCINA.ToList());
        }

        // GET: COCINAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COCINA cOCINA = db.COCINA.Find(id);
            if (cOCINA == null)
            {
                return HttpNotFound();
            }
            return View(cOCINA);
        }

        // GET: COCINAs/Create
        public ActionResult Create()
        {
            ViewBag.id_modelo = new SelectList(db.MODELO, "id_modelo", "nom_modelo");
            ViewBag.id_n_ensayo = new SelectList(db.N_ENSAYO, "id_n_ensayo", "id_n_ensayo");
            return View();
        }

        // POST: COCINAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_cocina,mes_certif,solicitud,n_serie_desde,n_serie_hasta,id_modelo,id_n_ensayo")] COCINA cOCINA)
        {
            if (ModelState.IsValid)
            {
                db.COCINA.Add(cOCINA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_modelo = new SelectList(db.MODELO, "id_modelo", "nom_modelo", cOCINA.id_modelo);
            ViewBag.id_n_ensayo = new SelectList(db.N_ENSAYO, "id_n_ensayo", "id_n_ensayo", cOCINA.id_n_ensayo);
            return View(cOCINA);
        }

        // GET: COCINAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COCINA cOCINA = db.COCINA.Find(id);
            if (cOCINA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_modelo = new SelectList(db.MODELO, "id_modelo", "nom_modelo", cOCINA.id_modelo);
            ViewBag.id_n_ensayo = new SelectList(db.N_ENSAYO, "id_n_ensayo", "id_n_ensayo", cOCINA.id_n_ensayo);
            return View(cOCINA);
        }

        // POST: COCINAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_cocina,mes_certif,solicitud,n_serie_desde,n_serie_hasta,id_modelo,id_n_ensayo")] COCINA cOCINA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOCINA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_modelo = new SelectList(db.MODELO, "id_modelo", "nom_modelo", cOCINA.id_modelo);
            ViewBag.id_n_ensayo = new SelectList(db.N_ENSAYO, "id_n_ensayo", "id_n_ensayo", cOCINA.id_n_ensayo);
            return View(cOCINA);
        }

        // GET: COCINAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COCINA cOCINA = db.COCINA.Find(id);
            if (cOCINA == null)
            {
                return HttpNotFound();
            }
            return View(cOCINA);
        }

        // POST: COCINAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            COCINA cOCINA = db.COCINA.Find(id);
            db.COCINA.Remove(cOCINA);
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
