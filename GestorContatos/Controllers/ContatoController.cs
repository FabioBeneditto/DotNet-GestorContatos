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
    public class ContatoController : Controller
    {
        private contatosEntities db = new contatosEntities();

        public ActionResult Index()
        {
            List<Contato> contatos = db.Contato.ToList();
            return View(contatos);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Contato contato = db.Contato.Find(id);
           
            if (contato == null)
            {
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contato contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Contato.Add(contato);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Não foi possível salvar o contato. " + ex.Message);
            }
            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Contato contato = db.Contato.Find(id);
            if (contato == null)
            {
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contato contato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contato);
        }
    }
}