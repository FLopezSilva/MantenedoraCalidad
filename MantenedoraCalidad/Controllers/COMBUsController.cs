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


    public class COMBUsController : Controller
    {
        private NuevaQAEntities1 db = new NuevaQAEntities1();

        // GET: COMBUs
        public ActionResult Index()
        {
            var cOMBU = db.COMBU.Include(c => c.ENSAYO_COMB);
            return View(cOMBU.ToList());
        }

        // GET: COMBUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMBU cOMBU = db.COMBU.Find(id);
            if (cOMBU == null)
            {
                return HttpNotFound();
            }
            return View(cOMBU);
        }

        // GET: COMBUs/Create
        public ActionResult Create()
        {
            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu");
            return View();
        }

        // POST: COMBUs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_comb,nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu")] COMBU cOMBU)
        {
            if (ModelState.IsValid)
            {
                db.COMBU.Add(cOMBU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu", cOMBU.id_combu);
            return View(cOMBU);
        }

        // GET: COMBUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMBU cOMBU = db.COMBU.Find(id);
            if (cOMBU == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu", cOMBU.id_combu);
            return View(cOMBU);
        }

        // POST: COMBUs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_comb,nom_quemador,nom_posicion,co,co_2,co_n,cumple_comb,id_combu")] COMBU cOMBU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMBU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu", cOMBU.id_combu);
            return View(cOMBU);
        }

        // GET: COMBUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMBU cOMBU = db.COMBU.Find(id);
            if (cOMBU == null)
            {
                return HttpNotFound();
            }
            return View(cOMBU);
        }

        // POST: COMBUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMBU cOMBU = db.COMBU.Find(id);
            db.COMBU.Remove(cOMBU);
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
