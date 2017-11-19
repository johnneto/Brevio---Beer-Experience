using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Brevio___Beer_Experience.Models;
using Brevio___Beer_Experience.DAL;
using System.Web.Security;

namespace Brevio___Beer_Experience.Controllers
{
    public class FamiliaController : Controller
    {
        private static Context ctx = Singleton.Instance.Context;

        // GET: Familia
        public ActionResult Index()
        {
            return View(FamiliaDAO.ListarFamilias());
        }

        // GET: Familia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia familia = FamiliaDAO.BuscarFamiliaPorId(id);
            if (familia == null)
            {
                return HttpNotFound();
            }
            return View(familia);
        }

        // GET: Familia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Familia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,usuario_id,nome,ult_modificacao")] Familia familia)
        {
            String email = Session["email"].ToString();
            Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
            familia.usuario_id = usuario.id;
           
            familia.ult_modificacao = DateTime.Now;
            if (ModelState.IsValid)
            {
                FamiliaDAO.CadastrarFamilia(familia);
                return RedirectToAction("Index");
            }

            return View(familia);
        }

        // GET: Familia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia familia = FamiliaDAO.BuscarFamiliaPorId(id); 
            if (familia == null)
            {
                return HttpNotFound();
            }
            return View(familia);
        }

        // POST: Familia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,usuario_id,nome,ult_modificacao")] Familia familia)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(familia).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(familia);
        }

        // GET: Familia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Familia familia = FamiliaDAO.BuscarFamiliaPorId(id);
            if (familia == null)
            {
                return HttpNotFound();
            }
            return View(familia);
        }

        // POST: Familia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Familia familia = FamiliaDAO.BuscarFamiliaPorId(id);
            FamiliaDAO.RemoverFamilia(familia);
            return RedirectToAction("Index");
        }
    }
}
