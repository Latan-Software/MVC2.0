using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC2._0.Models;

namespace MVC2._0.Controllers
{
    public class ALTERNADORESController : Controller
    {
        private MyBDatosEntities db = new MyBDatosEntities();

        // GET: ALTERNADORES
        public ActionResult Index()
        {
            var aLTERNADORES = db.ALTERNADORES.Include(a => a.Marca1).Include(a => a.Modelo1).Include(a => a.Proveedor1);
            return View(aLTERNADORES.ToList());
        }

        // GET: ALTERNADORES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALTERNADORES aLTERNADORES = db.ALTERNADORES.Find(id);
            if (aLTERNADORES == null)
            {
                return HttpNotFound();
            }
            return View(aLTERNADORES);
        }

        // GET: ALTERNADORES/Create
        public ActionResult Create()
        {
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1");
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1");
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE");
            return View();
        }

        // POST: ALTERNADORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] ALTERNADORES aLTERNADORES)
        {
            if (ModelState.IsValid)
            {
                db.ALTERNADORES.Add(aLTERNADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", aLTERNADORES.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", aLTERNADORES.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", aLTERNADORES.PROVEEDOR);
            return View(aLTERNADORES);
        }

        // GET: ALTERNADORES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALTERNADORES aLTERNADORES = db.ALTERNADORES.Find(id);
            if (aLTERNADORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", aLTERNADORES.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", aLTERNADORES.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", aLTERNADORES.PROVEEDOR);
            return View(aLTERNADORES);
        }

        // POST: ALTERNADORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] ALTERNADORES aLTERNADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLTERNADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", aLTERNADORES.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", aLTERNADORES.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", aLTERNADORES.PROVEEDOR);
            return View(aLTERNADORES);
        }

        // GET: ALTERNADORES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALTERNADORES aLTERNADORES = db.ALTERNADORES.Find(id);
            if (aLTERNADORES == null)
            {
                return HttpNotFound();
            }
            return View(aLTERNADORES);
        }

        // POST: ALTERNADORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALTERNADORES aLTERNADORES = db.ALTERNADORES.Find(id);
            db.ALTERNADORES.Remove(aLTERNADORES);
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
