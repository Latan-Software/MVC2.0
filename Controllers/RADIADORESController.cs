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
    public class RADIADORESController : Controller
    {
        private MyBDatosEntities db = new MyBDatosEntities();

        // GET: RADIADORES
        public ActionResult Index()
        {
            var rADIADORES = db.RADIADORES.Include(r => r.Marca1).Include(r => r.Modelo1).Include(r => r.Proveedor1);
            return View(rADIADORES.ToList());
        }

        // GET: RADIADORES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RADIADORES rADIADORES = db.RADIADORES.Find(id);
            if (rADIADORES == null)
            {
                return HttpNotFound();
            }
            return View(rADIADORES);
        }

        // GET: RADIADORES/Create
        public ActionResult Create()
        {
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1");
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1");
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE");
            return View();
        }

        // POST: RADIADORES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] RADIADORES rADIADORES)
        {
            if (ModelState.IsValid)
            {
                db.RADIADORES.Add(rADIADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", rADIADORES.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", rADIADORES.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", rADIADORES.PROVEEDOR);
            return View(rADIADORES);
        }

        // GET: RADIADORES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RADIADORES rADIADORES = db.RADIADORES.Find(id);
            if (rADIADORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", rADIADORES.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", rADIADORES.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", rADIADORES.PROVEEDOR);
            return View(rADIADORES);
        }

        // POST: RADIADORES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] RADIADORES rADIADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rADIADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", rADIADORES.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", rADIADORES.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", rADIADORES.PROVEEDOR);
            return View(rADIADORES);
        }

        // GET: RADIADORES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RADIADORES rADIADORES = db.RADIADORES.Find(id);
            if (rADIADORES == null)
            {
                return HttpNotFound();
            }
            return View(rADIADORES);
        }

        // POST: RADIADORES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RADIADORES rADIADORES = db.RADIADORES.Find(id);
            db.RADIADORES.Remove(rADIADORES);
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
