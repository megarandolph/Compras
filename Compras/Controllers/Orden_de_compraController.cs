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
            var orden_de_compra = db.Orden_de_compra.Include(o => o.Articulos).Include(o => o.Unidades_de_medidas).Include(o => o.usuarios);
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
            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción");
            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion");
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre");
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
                orden_de_compra.Enviado = false;
                db.Orden_de_compra.Add(orden_de_compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción", orden_de_compra.Articulo);
            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", orden_de_compra.Unidad_de_medida);
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre", orden_de_compra.UsuarioId);
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
            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción", orden_de_compra.Articulo);
            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", orden_de_compra.Unidad_de_medida);
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre", orden_de_compra.UsuarioId);
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
            ViewBag.Articulo = new SelectList(db.Articulos, "ArticuloId", "Descripción", orden_de_compra.Articulo);
            ViewBag.Unidad_de_medida = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", orden_de_compra.Unidad_de_medida);
            ViewBag.UsuarioId = new SelectList(db.usuarios, "UsuarioId", "Nombre", orden_de_compra.UsuarioId);
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

        public ActionResult VistaOrden()
        {
            var data = db.View_GetOrdenCompra.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult VistaOrden(int Parametro, string Busqueda)
        {
            var data = new List<View_GetOrdenCompra>();
            try
            {
                if (Parametro == 1)
                {
                    data = db.View_GetOrdenCompra.Where(x => x.Usuario.Contains(Busqueda)).ToList();

                }
                else if (Parametro == 2)
                {

                    var costo = Convert.ToDecimal(Busqueda);
                    data = db.View_GetOrdenCompra.Where(x => x.Costo == costo).ToList();

                }
                else if (Parametro == 3)
                {
                    data = db.View_GetOrdenCompra.Where(x => x.Articulo.Contains(Busqueda)).ToList();

                }
            }
            catch (Exception)
            {
               data = db.View_GetOrdenCompra.ToList();
            }     
            return View(data);
        }

        public ActionResult EnvioContabilidad()
        {
            var data = db.View_GetOrdenCompra.ToList();
            return View(data);
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
