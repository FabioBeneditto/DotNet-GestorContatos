using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestorContatos.Models;

namespace GestorContatos.Controllers
{
    public class TelefoneController : Controller
    {
        private contatosEntities db = new contatosEntities();

        //
        // GET: /Telefone/

        public ActionResult Index()
        {
            var telefone = db.Telefone.Include(t => t.Contato).Include(t => t.Operadora);
            return View(telefone.ToList());
        }

        //
        // GET: /Telefone/Details/5

        public ActionResult Details(int id = 0)
        {
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        //
        // GET: /Telefone/Create

        public ActionResult Create()
        {
            ViewBag.CodContato = new SelectList(db.Contato, "CodContato", "Nome");
            ViewBag.CodOperadora = new SelectList(db.Operadora, "CodOperadora", "Nome");
            return View();
        }

        //
        // POST: /Telefone/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Telefone.Add(telefone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodContato = new SelectList(db.Contato, "CodContato", "Nome", telefone.CodContato);
            ViewBag.CodOperadora = new SelectList(db.Operadora, "CodOperadora", "Nome", telefone.CodOperadora);
            return View(telefone);
        }

        //
        // GET: /Telefone/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodContato = new SelectList(db.Contato, "CodContato", "Nome", telefone.CodContato);
            ViewBag.CodOperadora = new SelectList(db.Operadora, "CodOperadora", "Nome", telefone.CodOperadora);
            return View(telefone);
        }

        //
        // POST: /Telefone/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Telefone telefone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodContato = new SelectList(db.Contato, "CodContato", "Nome", telefone.CodContato);
            ViewBag.CodOperadora = new SelectList(db.Operadora, "CodOperadora", "Nome", telefone.CodOperadora);
            return View(telefone);
        }

        //
        // GET: /Telefone/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Telefone telefone = db.Telefone.Find(id);
            if (telefone == null)
            {
                return HttpNotFound();
            }
            return View(telefone);
        }

        //
        // POST: /Telefone/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefone telefone = db.Telefone.Find(id);
            db.Telefone.Remove(telefone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}