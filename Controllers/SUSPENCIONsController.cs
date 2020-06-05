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
    public class SUSPENCIONsController : Controller
    {
        private MyBDatosEntities db = new MyBDatosEntities();

        // GET: SUSPENCIONs
        public ActionResult Index()
        {
            var sUSPENCION = db.SUSPENCION.Include(s => s.Marca1).Include(s => s.Modelo1).Include(s => s.Proveedor1);
            return View(sUSPENCION.ToList());
        }

        // GET: SUSPENCIONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUSPENCION sUSPENCION = db.SUSPENCION.Find(id);
            if (sUSPENCION == null)
            {
                return HttpNotFound();
            }
            return View(sUSPENCION);
        }

        // GET: SUSPENCIONs/Create
        public ActionResult Create()
        {
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1");
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1");
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE");
            return View();
        }

        // POST: SUSPENCIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] SUSPENCION sUSPENCION)
        {
            if (ModelState.IsValid)
            {
                db.SUSPENCION.Add(sUSPENCION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", sUSPENCION.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", sUSPENCION.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", sUSPENCION.PROVEEDOR);
            return View(sUSPENCION);
        }

        // GET: SUSPENCIONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUSPENCION sUSPENCION = db.SUSPENCION.Find(id);
            if (sUSPENCION == null)
            {
                return HttpNotFound();
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", sUSPENCION.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", sUSPENCION.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", sUSPENCION.PROVEEDOR);
            return View(sUSPENCION);
        }

        // POST: SUSPENCIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] SUSPENCION sUSPENCION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUSPENCION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", sUSPENCION.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", sUSPENCION.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", sUSPENCION.PROVEEDOR);
            return View(sUSPENCION);
        }

        // GET: SUSPENCIONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUSPENCION sUSPENCION = db.SUSPENCION.Find(id);
            if (sUSPENCION == null)
            {
                return HttpNotFound();
            }
            return View(sUSPENCION);
        }

        // POST: SUSPENCIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SUSPENCION sUSPENCION = db.SUSPENCION.Find(id);
            db.SUSPENCION.Remove(sUSPENCION);
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
