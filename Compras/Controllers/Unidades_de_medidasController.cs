using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compras.Models;

namespace Compras.Controllers
{
    public class Unidades_de_medidasController : Controller
    {
        private DBComprasEntities db = new DBComprasEntities();

        // GET: Unidades_de_medidas
        public ActionResult Index()
        {
            return View(db.Unidades_de_medidas.ToList());
        }

        // GET: Unidades_de_medidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidades_de_medidas unidades_de_medidas = db.Unidades_de_medidas.Find(id);
            if (unidades_de_medidas == null)
            {
                return HttpNotFound();
            }
            return View(unidades_de_medidas);
        }

        // GET: Unidades_de_medidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unidades_de_medidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnidadMedidaId,Descripcion,Estado")] Unidades_de_medidas unidades_de_medidas)
        {
            if (ModelState.IsValid)
            {
                unidades_de_medidas.Estado = true;
                db.Unidades_de_medidas.Add(unidades_de_medidas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidades_de_medidas);
        }

        // GET: Unidades_de_medidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidades_de_medidas unidades_de_medidas = db.Unidades_de_medidas.Find(id);
            if (unidades_de_medidas == null)
            {
                return HttpNotFound();
            }
            return View(unidades_de_medidas);
        }

        // POST: Unidades_de_medidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnidadMedidaId,Descripcion,Estado")] Unidades_de_medidas unidades_de_medidas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidades_de_medidas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidades_de_medidas);
        }

        // GET: Unidades_de_medidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidades_de_medidas unidades_de_medidas = db.Unidades_de_medidas.Find(id);
            if (unidades_de_medidas == null)
            {
                return HttpNotFound();
            }
            return View(unidades_de_medidas);
        }

        // POST: Unidades_de_medidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidades_de_medidas unidades_de_medidas = db.Unidades_de_medidas.Find(id);
            db.Unidades_de_medidas.Remove(unidades_de_medidas);
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
