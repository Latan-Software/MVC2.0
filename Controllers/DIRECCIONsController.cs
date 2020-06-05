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
    public class DIRECCIONsController : Controller
    {
        private MyBDatosEntities db = new MyBDatosEntities();

        // GET: DIRECCIONs
        public ActionResult Index()
        {
            var dIRECCION = db.DIRECCION.Include(d => d.Marca1).Include(d => d.Modelo1).Include(d => d.Proveedor1);
            return View(dIRECCION.ToList());
        }

        // GET: DIRECCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Create
        public ActionResult Create()
        {
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1");
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1");
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE");
            return View();
        }

        // POST: DIRECCIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                db.DIRECCION.Add(dIRECCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", dIRECCION.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", dIRECCION.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", dIRECCION.PROVEEDOR);
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", dIRECCION.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", dIRECCION.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", dIRECCION.PROVEEDOR);
            return View(dIRECCION);
        }

        // POST: DIRECCIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] DIRECCION dIRECCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dIRECCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", dIRECCION.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", dIRECCION.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", dIRECCION.PROVEEDOR);
            return View(dIRECCION);
        }

        // GET: DIRECCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            if (dIRECCION == null)
            {
                return HttpNotFound();
            }
            return View(dIRECCION);
        }

        // POST: DIRECCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DIRECCION dIRECCION = db.DIRECCION.Find(id);
            db.DIRECCION.Remove(dIRECCION);
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
