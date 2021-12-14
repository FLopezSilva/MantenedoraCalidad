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
    public class PRUEBAsController : Controller
    {

        public IEnumerable<COMBU> combu { get; set; }

        private NuevaQAEntities1 db = new NuevaQAEntities1();

        // GET: PRUEBAs
        public ActionResult Index(string searchBy, string search, int? page)
        {
            //var pRUEBA = db.PRUEBA.Include(p => p.CONDICION_ENSAYO).Include(p => p.ENSAYO_BASCUL).Include(p => p.ENSAYO_C_LLAMA).Include(p => p.ENSAYO_COMB).Include(p => p.ENSAYO_ELECTR).Include(p => p.ENSAYO_FUGA_G).Include(p => p.ENSAYO_NIVELAC).Include(p => p.ENSAYO_RESIST).Include(p => p.ENSAYO_RETENCION).Include(p => p.ENSAYO_TERMOCUP).Include(p => p.ENSAYO_TRABAM).Include(p => p.INFORME_PRUEBA);
            //return View(pRUEBA.ToList());

            if (searchBy == "id_prueba")
            {

                return View(db.PRUEBA.Where(x => x.id_resist == search || search == null).ToList().ToPagedList(page ?? 1, 10));
              
            }

            else
            {
                return View(db.PRUEBA.Where(x => x.id_resist.Contains(search) || search == null).ToList().ToPagedList(page ?? 1, 10));
            }
        }

        // GET: PRUEBAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRUEBA pRUEBA = db.PRUEBA.Find(id);
            if (pRUEBA == null)
            {
                return HttpNotFound();
            }
            return View(pRUEBA);
        }

        // GET: PRUEBAs/Create
        public ActionResult Create()
        {
            ViewBag.id_condicion = new SelectList(db.CONDICION_ENSAYO, "id_condicion", "cod_cocina");
            ViewBag.id_basc = new SelectList(db.ENSAYO_BASCUL, "id_basc", "id_basc");
            ViewBag.id_c_llama = new SelectList(db.ENSAYO_C_LLAMA, "id_c_llama", "id_c_llama");
            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu");
            ViewBag.id_electr = new SelectList(db.ENSAYO_ELECTR, "id_electr", "id_electr");
            ViewBag.id_fuga = new SelectList(db.ENSAYO_FUGA_G, "id_fuga", "id_fuga");
            ViewBag.id_nivelac = new SelectList(db.ENSAYO_NIVELAC, "id_nivelac", "id_nivelac");
            ViewBag.id_resist = new SelectList(db.ENSAYO_RESIST, "id_resist", "id_resist");
            ViewBag.id_retencion = new SelectList(db.ENSAYO_RETENCION, "id_retencion", "id_retencion");
            ViewBag.id_termo = new SelectList(db.ENSAYO_TERMOCUP, "id_termo", "id_termo");
            ViewBag.id_trab = new SelectList(db.ENSAYO_TRABAM, "id_trab", "id_trab");
            ViewBag.n_planilla = new SelectList(db.INFORME_PRUEBA, "n_planilla", "n_planilla");
            return View();
        }

        // POST: PRUEBAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prueba,fec_pruebas,hora_inicio_p,hora_termino_p,tiem_prueba,id_combu,id_electr,id_termo,id_retencion,id_basc,id_resist,id_trab,id_nivelac,id_condicion,id_fuga,n_planilla,id_c_llama")] PRUEBA pRUEBA)
        {
            if (ModelState.IsValid)
            {
                db.PRUEBA.Add(pRUEBA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_condicion = new SelectList(db.CONDICION_ENSAYO, "id_condicion", "cod_cocina", pRUEBA.id_condicion);
            ViewBag.id_basc = new SelectList(db.ENSAYO_BASCUL, "id_basc", "id_basc", pRUEBA.id_basc);
            ViewBag.id_c_llama = new SelectList(db.ENSAYO_C_LLAMA, "id_c_llama", "id_c_llama", pRUEBA.id_c_llama);
            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu", pRUEBA.id_combu);
            ViewBag.id_electr = new SelectList(db.ENSAYO_ELECTR, "id_electr", "id_electr", pRUEBA.id_electr);
            ViewBag.id_fuga = new SelectList(db.ENSAYO_FUGA_G, "id_fuga", "id_fuga", pRUEBA.id_fuga);
            ViewBag.id_nivelac = new SelectList(db.ENSAYO_NIVELAC, "id_nivelac", "id_nivelac", pRUEBA.id_nivelac);
            ViewBag.id_resist = new SelectList(db.ENSAYO_RESIST, "id_resist", "id_resist", pRUEBA.id_resist);
            ViewBag.id_retencion = new SelectList(db.ENSAYO_RETENCION, "id_retencion", "id_retencion", pRUEBA.id_retencion);
            ViewBag.id_termo = new SelectList(db.ENSAYO_TERMOCUP, "id_termo", "id_termo", pRUEBA.id_termo);
            ViewBag.id_trab = new SelectList(db.ENSAYO_TRABAM, "id_trab", "id_trab", pRUEBA.id_trab);
            ViewBag.n_planilla = new SelectList(db.INFORME_PRUEBA, "n_planilla", "n_planilla", pRUEBA.n_planilla);
            return View(pRUEBA);
        }

        // GET: PRUEBAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRUEBA pRUEBA = db.PRUEBA.Find(id);
            if (pRUEBA == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_condicion = new SelectList(db.CONDICION_ENSAYO, "id_condicion", "cod_cocina", pRUEBA.id_condicion);
            ViewBag.id_basc = new SelectList(db.ENSAYO_BASCUL, "id_basc", "id_basc", pRUEBA.id_basc);
            ViewBag.id_c_llama = new SelectList(db.ENSAYO_C_LLAMA, "id_c_llama", "id_c_llama", pRUEBA.id_c_llama);
            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu", pRUEBA.id_combu);
            ViewBag.id_electr = new SelectList(db.ENSAYO_ELECTR, "id_electr", "id_electr", pRUEBA.id_electr);
            ViewBag.id_fuga = new SelectList(db.ENSAYO_FUGA_G, "id_fuga", "id_fuga", pRUEBA.id_fuga);
            ViewBag.id_nivelac = new SelectList(db.ENSAYO_NIVELAC, "id_nivelac", "id_nivelac", pRUEBA.id_nivelac);
            ViewBag.id_resist = new SelectList(db.ENSAYO_RESIST, "id_resist", "id_resist", pRUEBA.id_resist);
            ViewBag.id_retencion = new SelectList(db.ENSAYO_RETENCION, "id_retencion", "id_retencion", pRUEBA.id_retencion);
            ViewBag.id_termo = new SelectList(db.ENSAYO_TERMOCUP, "id_termo", "id_termo", pRUEBA.id_termo);
            ViewBag.id_trab = new SelectList(db.ENSAYO_TRABAM, "id_trab", "id_trab", pRUEBA.id_trab);
            ViewBag.n_planilla = new SelectList(db.INFORME_PRUEBA, "n_planilla", "observacion", pRUEBA.n_planilla);
            return View(pRUEBA);
        }

        // POST: PRUEBAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prueba,fec_pruebas,hora_inicio_p,hora_termino_p,tiem_prueba,id_combu,id_electr,id_termo,id_retencion,id_basc,id_resist,id_trab,id_nivelac,id_condicion,id_fuga,n_planilla,id_c_llama")] PRUEBA pRUEBA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRUEBA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_condicion = new SelectList(db.CONDICION_ENSAYO, "id_condicion", "cod_cocina", pRUEBA.id_condicion);
            ViewBag.id_basc = new SelectList(db.ENSAYO_BASCUL, "id_basc", "id_basc", pRUEBA.id_basc);
            ViewBag.id_c_llama = new SelectList(db.ENSAYO_C_LLAMA, "id_c_llama", "id_c_llama", pRUEBA.id_c_llama);
            ViewBag.id_combu = new SelectList(db.ENSAYO_COMB, "id_combu", "id_combu", pRUEBA.id_combu);
            ViewBag.id_electr = new SelectList(db.ENSAYO_ELECTR, "id_electr", "id_electr", pRUEBA.id_electr);
            ViewBag.id_fuga = new SelectList(db.ENSAYO_FUGA_G, "id_fuga", "id_fuga", pRUEBA.id_fuga);
            ViewBag.id_nivelac = new SelectList(db.ENSAYO_NIVELAC, "id_nivelac", "id_nivelac", pRUEBA.id_nivelac);
            ViewBag.id_resist = new SelectList(db.ENSAYO_RESIST, "id_resist", "id_resist", pRUEBA.id_resist);
            ViewBag.id_retencion = new SelectList(db.ENSAYO_RETENCION, "id_retencion", "id_retencion", pRUEBA.id_retencion);
            ViewBag.id_termo = new SelectList(db.ENSAYO_TERMOCUP, "id_termo", "id_termo", pRUEBA.id_termo);
            ViewBag.id_trab = new SelectList(db.ENSAYO_TRABAM, "id_trab", "id_trab", pRUEBA.id_trab);
            ViewBag.n_planilla = new SelectList(db.INFORME_PRUEBA, "n_planilla", "observacion", pRUEBA.n_planilla);
            return View(pRUEBA);
        }

        // GET: PRUEBAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRUEBA pRUEBA = db.PRUEBA.Find(id);
            if (pRUEBA == null)
            {
                return HttpNotFound();
            }
            return View(pRUEBA);
        }

        // POST: PRUEBAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRUEBA pRUEBA = db.PRUEBA.Find(id);
            db.PRUEBA.Remove(pRUEBA);
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
