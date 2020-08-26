using DAL.Repositories;
using DAL.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Base.Entity;

namespace PortalBI.HUB.Controllers
{
    public class RecebimentohubController : Controller
    {
        private RecebimentohubRepository respository = new RecebimentohubRepository();
        // GET: Recebimentohub
        public ActionResult Index()
        {
            FiltroRecebimentoHub filtro = new FiltroRecebimentoHub();
            return View(respository.GetAll(filtro));
        }

        // GET: Recebimentohub/Create
        // GET: Recebimentohub/Create/
        public ActionResult Create()
        {
            FiltroRecebimentoHub filtro = new FiltroRecebimentoHub();
            List<Recebimentohub> ListaCliente = respository.GetAll(filtro);
            if (ListaCliente.Count > 0) {
                ViewBag.dados = ListaCliente.ToList();
            }
            else
            {
                ViewBag.dados = new List<Recebimentohub>();
            }
            return View();
        }

        // POST: Recebimentohub/Create
        [HttpPost]
        public ActionResult Create(Recebimentohub recebimentohub)
        {
            try
            {
                FiltroRecebimentoHub filtro = new FiltroRecebimentoHub();
                //filtro.Id = 1;
                List<Recebimentohub> ListaCliente = respository.GetAll(filtro);
                if (ListaCliente.Count > 0)
                {
                    ViewBag.dados = ListaCliente.ToList();
                }
                else
                {
                    ViewBag.dados = new List<Recebimentohub>();
                }

                if (ModelState.IsValid)
                {
                    respository.Save(recebimentohub);
                    return RedirectToAction("Create");
                }
                else
                {
                    return View(recebimentohub);
                }
            }
            catch
            {
                return View(recebimentohub);
            }
        }

        // GET: Recebimentohub/Edit/5
        public ActionResult Edit(int id)
        {
            FiltroRecebimentoHub filtro = new FiltroRecebimentoHub();
            //filtro.Id = 1;
            List<Recebimentohub> ListaCliente = respository.GetAll(filtro);
            if (ListaCliente.Count > 0)
            {
                ViewBag.dados = ListaCliente.ToList();
            }
            else
            {
                ViewBag.dados = new List<Recebimentohub>();
            }


            var recebimentohub = respository.GetById(id);

            if (recebimentohub == null)
            {
                return HttpNotFound();
            }

            return View(recebimentohub);
        }

        // POST: Recebimentohub/Edit/5
        [HttpPost]
        public ActionResult Edit(Recebimentohub recebimentohub)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    respository.Update(recebimentohub);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(recebimentohub);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Recebimentohub/Delete/5
        public ActionResult Delete(int id)
        {
            var recebimentohub = respository.GetById(id);

            if (recebimentohub == null)
            {
                return HttpNotFound();
            }

            return View(recebimentohub);
        }

        // POST: Recebimentohub/Delete/5
        [HttpPost]
        public ActionResult Delete(Recebimentohub recebimentohub)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    respository.Delete(recebimentohub);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(recebimentohub);
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
