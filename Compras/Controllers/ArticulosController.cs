﻿using System;
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
    public class ArticulosController : Controller
    {
        private DBComprasEntities db = new DBComprasEntities();

        // GET: Articulos
        public ActionResult Index()
        {
            var articulos = db.Articulos.Include(a => a.Unidades_de_medidas);
            return View(articulos.ToList());
        }

        // GET: Articulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // GET: Articulos/Create
        public ActionResult Create()
        {
            ViewBag.UnidadMedidaId = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion");
            return View();
        }

        // POST: Articulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticuloId,Descripción,Marca,UnidadMedidaId,Existencia,Estado")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                if (articulos.Existencia > 0)
                {

                    db.Articulos.Add(articulos);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UnidadMedidaId = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", articulos.UnidadMedidaId);
                    ViewBag.Existencia = "La existencia tiene que ser mayor a 0";
                    return View(articulos);
                }
            }

            ViewBag.UnidadMedidaId = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", articulos.UnidadMedidaId);
            return View(articulos);
        }

        // GET: Articulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.UnidadMedidaId = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", articulos.UnidadMedidaId);
            return View(articulos);
        }

        // POST: Articulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArticuloId,Descripción,Marca,UnidadMedidaId,Existencia,Estado")] Articulos articulos)
        {
            if (ModelState.IsValid)
            {
                if (articulos.Existencia > 0)
                {
                    db.Entry(articulos).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UnidadMedidaId = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", articulos.UnidadMedidaId);
                    ViewBag.Existencia = "La existencia tiene que ser mayor a 0";
                    return View(articulos);
                }
            }
            ViewBag.UnidadMedidaId = new SelectList(db.Unidades_de_medidas, "UnidadMedidaId", "Descripcion", articulos.UnidadMedidaId);
            return View(articulos);
        }

        // GET: Articulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulos articulos = db.Articulos.Find(id);
            if (articulos == null)
            {
                return HttpNotFound();
            }
            return View(articulos);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulos articulos = db.Articulos.Find(id);
            db.Articulos.Remove(articulos);
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
