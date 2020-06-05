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
    public class ENCENDIDOesController : Controller
    {
        private MyBDatosEntities db = new MyBDatosEntities();

        // GET: ENCENDIDOes
        public ActionResult Index()
        {
            var eNCENDIDO = db.ENCENDIDO.Include(e => e.Marca1).Include(e => e.Modelo1).Include(e => e.Proveedor1);
            return View(eNCENDIDO.ToList());
        }

        // GET: ENCENDIDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCENDIDO eNCENDIDO = db.ENCENDIDO.Find(id);
            if (eNCENDIDO == null)
            {
                return HttpNotFound();
            }
            return View(eNCENDIDO);
        }

        // GET: ENCENDIDOes/Create
        public ActionResult Create()
        {
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1");
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1");
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE");
            return View();
        }

        // POST: ENCENDIDOes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] ENCENDIDO eNCENDIDO)
        {
            if (ModelState.IsValid)
            {
                db.ENCENDIDO.Add(eNCENDIDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", eNCENDIDO.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", eNCENDIDO.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", eNCENDIDO.PROVEEDOR);
            return View(eNCENDIDO);
        }

        // GET: ENCENDIDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCENDIDO eNCENDIDO = db.ENCENDIDO.Find(id);
            if (eNCENDIDO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", eNCENDIDO.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", eNCENDIDO.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", eNCENDIDO.PROVEEDOR);
            return View(eNCENDIDO);
        }

        // POST: ENCENDIDOes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCTO,NOMBRE,SKU,PRECIO,MARCA,MODELO,DESCRIPCION,EXISTENCIA,PROVEEDOR,CODIGO")] ENCENDIDO eNCENDIDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNCENDIDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MARCA = new SelectList(db.Marca, "id_marca", "MARCA1", eNCENDIDO.MARCA);
            ViewBag.MODELO = new SelectList(db.Modelo, "id_modelo", "MODELO1", eNCENDIDO.MODELO);
            ViewBag.PROVEEDOR = new SelectList(db.Proveedor, "id_proveedor", "NOMBRE", eNCENDIDO.PROVEEDOR);
            return View(eNCENDIDO);
        }

        // GET: ENCENDIDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENCENDIDO eNCENDIDO = db.ENCENDIDO.Find(id);
            if (eNCENDIDO == null)
            {
                return HttpNotFound();
            }
            return View(eNCENDIDO);
        }

        // POST: ENCENDIDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ENCENDIDO eNCENDIDO = db.ENCENDIDO.Find(id);
            db.ENCENDIDO.Remove(eNCENDIDO);
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
