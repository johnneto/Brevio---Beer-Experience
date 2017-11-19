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

namespace Brevio___Beer_Experience.Controllers
{
    public class CervejariaController : Controller
    {
        private static Context ctx = Singleton.Instance.Context;

        // GET: Cervejaria
        public ActionResult Index()
        {
            return View(CervejariaDAO.ListarCervejarias());
        }

        // GET: Cervejaria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cervejaria cervejaria = CervejariaDAO.BuscarCervejariaPorId(id);
            if (cervejaria == null)
            {
                return HttpNotFound();
            }
            return View(cervejaria);
        }

        // GET: Cervejaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cervejaria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,usuario_id,nome,endereco,cidade,estado,codigo,pais,telefone,website,descricao,ult_modificacao")] Cervejaria cervejaria)
        {
            if (ModelState.IsValid)
            {
                String email = Session["email"].ToString();
                Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
                cervejaria.usuario_id = usuario.id;
                cervejaria.ult_modificacao = DateTime.Now;
                CervejariaDAO.CadastrarCervejaria(cervejaria);
                return RedirectToAction("Index");
            }

            return View(cervejaria);
        }

        // GET: Cervejaria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cervejaria cervejaria = CervejariaDAO.BuscarCervejariaPorId(id);
            if (cervejaria == null)
            {
                return HttpNotFound();
            }
            return View(cervejaria);
        }

        // POST: Cervejaria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,usuario_id,nome,endereco,cidade,estado,codigo,pais,telefone,website,descricao,ult_modificacao")] Cervejaria cervejaria)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(cervejaria).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cervejaria);
        }

        // GET: Cervejaria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cervejaria cervejaria = CervejariaDAO.BuscarCervejariaPorId(id);
            if (cervejaria == null)
            {
                return HttpNotFound();
            }
            return View(cervejaria);
        }

        // POST: Cervejaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cervejaria cervejaria = CervejariaDAO.BuscarCervejariaPorId(id);
            ctx.Cervejarias.Remove(cervejaria);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
