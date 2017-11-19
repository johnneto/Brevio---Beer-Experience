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
using System.IO;

namespace Brevio___Beer_Experience.Controllers
{
    public class CervejaController : Controller
    {
        private static Context ctx = Singleton.Instance.Context;

        // GET: Cerveja
        public ActionResult Index()
        {
            return View(CervejaDAO.ListarCervejas());
        }

        // GET: Cerveja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cerveja cerveja = CervejaDAO.BuscarCervejaPorId(id);
            if (cerveja == null)
            {
                return HttpNotFound();
            }
            return View(cerveja);
        }

        // GET: Cerveja/Create
        public ActionResult Create()
        {
            List<Estilo> listaestilos = new List<Estilo>();
            listaestilos = EstiloDAO.ListarEstilos();
            ViewBag.EstiloId = new SelectList(listaestilos, "id", "nome");

            List<Cervejaria> listacervejarias = new List<Cervejaria>();
            listacervejarias = CervejariaDAO.ListarCervejarias();
            ViewBag.CervejariaId = new SelectList(listacervejarias, "id", "nome");

            return View();
        }

      

        // POST: Cerveja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cervejaria_id,usuario_id,estilo_id,nome,abv,ibu,srm,descricao,img,ult_modificacao")] Cerveja cerveja, int EstiloId, int CervejariaId, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/images"), pic);
                    // file is uploaded
                    file.SaveAs(path);
                    cerveja.img = ("../images/"+file.FileName);
                }

                String email = Session["email"].ToString();
                cerveja.estilo_id = EstiloId;
                cerveja.cervejaria_id = CervejariaId;
                Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
                cerveja.usuario_id = usuario.id;
                cerveja.ult_modificacao = DateTime.Now;

                CervejaDAO.CadastrarCerveja(cerveja);
                return RedirectToAction("Index");
            }

            return View(cerveja);
        }

        // GET: Cerveja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cerveja cerveja = CervejaDAO.BuscarCervejaPorId(id);
            if (cerveja == null)
            {
                return HttpNotFound();
            }
            return View(cerveja);
        }

        // POST: Cerveja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cervejaria_id,usuario_id,estilo_id,nome,abv,ibu,srm,descricao,img,ult_modificacao")] Cerveja cerveja, int EstiloId, int CervejariaId, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(
                                           Server.MapPath("~/images"), pic);
                    // file is uploaded
                    file.SaveAs(path);
                    cerveja.img = ("../images/" + file.FileName);
                }

                String email = Session["email"].ToString();
                cerveja.estilo_id = EstiloId;
                cerveja.cervejaria_id = CervejariaId;
                Usuario usuario = UsuarioDAO.BuscarUsuarioPorEmail(email);
                cerveja.usuario_id = usuario.id;
                cerveja.ult_modificacao = DateTime.Now;

                ctx.Entry(cerveja).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cerveja);
        }

        // GET: Cerveja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cerveja cerveja = ctx.Cervejas.Find(id);
            if (cerveja == null)
            {
                return HttpNotFound();
            }
            return View(cerveja);
        }

        // POST: Cerveja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cerveja cerveja = ctx.Cervejas.Find(id);
            ctx.Cervejas.Remove(cerveja);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
