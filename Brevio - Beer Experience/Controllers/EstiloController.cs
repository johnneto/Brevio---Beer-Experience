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
    public class EstiloController : Controller
    {
        private static Context ctx = Singleton.Instance.Context;

        // GET: Estilo
        public ActionResult Index()
        {
            return View(EstiloDAO.ListarEstilos());
        }

        // GET: Estilo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = EstiloDAO.BuscarEstiloPorId(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // GET: Estilo/Create
        public ActionResult Create()
        {
            List<Familia> listafamilias = new List<Familia>();
            listafamilias = FamiliaDAO.ListarFamilias();
            ViewBag.FamiliaId = new SelectList(listafamilias, "id", "nome");

            return View();
        }

        // POST: Estilo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,usuario_id,familia_id,nome,ult_modificacao")] Estilo estilo, int familiaId)
        {
            if (ModelState.IsValid)
            {
                String email = Session["email"].ToString();
                estilo.familia_id = familiaId;
                Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
                estilo.usuario_id = usuario.id;
                estilo.ult_modificacao = DateTime.Now;

                EstiloDAO.CadastrarEstilo(estilo);
                return RedirectToAction("Index");
            }

            return View(estilo);
        }

        // GET: Estilo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = EstiloDAO.BuscarEstiloPorId(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // POST: Estilo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,usuario_id,familia_id,nome,ult_modificacao")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(estilo).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estilo);
        }

        // GET: Estilo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estilo estilo = EstiloDAO.BuscarEstiloPorId(id);
            if (estilo == null)
            {
                return HttpNotFound();
            }
            return View(estilo);
        }

        // POST: Estilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estilo estilo = EstiloDAO.BuscarEstiloPorId(id);
            ctx.Estilos.Remove(estilo);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
