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
    public class Orden_de_compraController : Controller
    {
        private DBComprasEntities db = new DBComprasEntities();

        // GET: Orden_de_compra
        public ActionResult Index()
        {
            var orden_de_compra = db.Orden_de_compra.Include(o => o.Unidades_de_medidas).Include(o => o.usuarios).Include(o => o.Articulos);
            return View(orden_de_compra.ToList());
        }

        // GET: Orden_de_compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_de_compra orden_de_compra = db.Orden_de_compra.Find(id);
            if (orden_de_compra == null)
            {
                return HttpNotFound();
            }
            return View(orden_de_compra);
        }

        // GET: Orden_de_compra/Create
        public ActionResult Create()
        {
            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion");
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre");
            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción");
            return View();
        }

        // POST: Orden_de_compra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero_de_orden,Fecha_orden,Estado,Articulo,Cantidad,Unidad_de_medida,Costo,UsuarioId")] Orden_de_compra orden_de_compra)
        {
            if (ModelState.IsValid)
            {
                db.Orden_de_compra.Add(orden_de_compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", orden_de_compra.Unidad_de_medida);
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre", orden_de_compra.UsuarioId);
            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción", orden_de_compra.Articulo);
            return View(orden_de_compra);
        }

        // GET: Orden_de_compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_de_compra orden_de_compra = db.Orden_de_compra.Find(id);
            if (orden_de_compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", orden_de_compra.Unidad_de_medida);
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre", orden_de_compra.UsuarioId);
            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción", orden_de_compra.Articulo);
            return View(orden_de_compra);
        }

        // POST: Orden_de_compra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero_de_orden,Fecha_orden,Estado,Articulo,Cantidad,Unidad_de_medida,Costo,UsuarioId")] Orden_de_compra orden_de_compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden_de_compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", orden_de_compra.Unidad_de_medida);
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre", orden_de_compra.UsuarioId);
            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción", orden_de_compra.Articulo);
            return View(orden_de_compra);
        }

        // GET: Orden_de_compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_de_compra orden_de_compra = db.Orden_de_compra.Find(id);
            if (orden_de_compra == null)
            {
                return HttpNotFound();
            }
            return View(orden_de_compra);
        }

        // POST: Orden_de_compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden_de_compra orden_de_compra = db.Orden_de_compra.Find(id);
            db.Orden_de_compra.Remove(orden_de_compra);
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
