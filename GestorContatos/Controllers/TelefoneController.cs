using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
// using System.Net;
using System.Web;
using System.Web.Mvc;
using GestorContatos.Models;
using GestorContatos.Models.ViewModels;

namespace GestorContatos.Controllers
{
    public class TelefoneController : Controller
    {
        private contatosEntities db = new contatosEntities();

        public ActionResult Create(int CodContato)
        {
            TelefoneCreate fone = new TelefoneCreate();
            fone.CodContato = Convert.ToInt32(CodContato);
            fone.Operadora = db.Operadora.ToList<Operadora>();
            fone.Contato = db.Contato.ToList<Contato>();

            return View(fone);
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
    }
}