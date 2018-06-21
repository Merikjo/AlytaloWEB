using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ÄlytaloWEB.Models;
using ÄlytaloWEB.ViewModels;
using System.Globalization;

namespace ÄlytaloWEB.Controllers
{
    public class TaloLampoController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: TaloLampo
        public ActionResult Index()
        {
            List<LampoViewModel> model = new List<LampoViewModel>();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            try
            {
                List<TaloLampo> talolammot = entities.TaloLampo.OrderByDescending(TaloLampo => TaloLampo.Huone).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (TaloLampo talolampo in talolammot)
                {
                    LampoViewModel lampo = new LampoViewModel();
                    lampo.Huone_ID = talolampo.Huone_ID;
                    lampo.Huone = talolampo.Huone;
                    lampo.HuoneNykyLampo = talolampo.HuoneNykyLampo;
                    lampo.HuoneTavoiteLampo = talolampo.HuoneTavoiteLampo;
                    lampo.LampoKirjattu= talolampo.LampoKirjattu;
                    lampo.LampoOn = talolampo.LampoOn;
                    lampo.LampoOff = talolampo.LampoOff;

                    model.Add(lampo);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);

        }
        CultureInfo fiFi = new CultureInfo("fi-FI");

        // GET: TaloLampo/Details/5
        public ActionResult Details(int? id)
        {
            LampoViewModel model = new LampoViewModel();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            try
            { 
                TaloLampo taloLampo = db.TaloLampo.Find(id);
                if (taloLampo == null)
            {
                return HttpNotFound();
            }

                TaloLampo lampodetail = entities.TaloLampo.Find(taloLampo.Huone_ID);

                LampoViewModel lampo = new LampoViewModel();
                lampo.Huone_ID = lampodetail.Huone_ID;
                lampo.Huone = lampodetail.Huone;
                lampo.HuoneNykyLampo = lampodetail.HuoneNykyLampo;
                lampo.HuoneTavoiteLampo = lampodetail.HuoneTavoiteLampo;
                lampo.LampoKirjattu = lampodetail.LampoKirjattu;
                lampo.LampoOn = lampodetail.LampoOn;
                lampo.LampoOff = lampodetail.LampoOff;

                model = lampo;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }
    

        // GET: TaloLampo/Create
        public ActionResult Create()
        {
            JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

            LampoViewModel model = new LampoViewModel();

            return View(model);
        }


        // POST: TaloLampo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LampoViewModel model)
        {
            TaloLampo lampo = new TaloLampo();
            lampo.Huone_ID = model.Huone_ID;
            lampo.Huone = model.Huone;
            lampo.HuoneNykyLampo = model.HuoneNykyLampo;
            lampo.HuoneTavoiteLampo = model.HuoneTavoiteLampo;
            //lampo.LampoKirjattu = model.LampoKirjattu;

            db.TaloLampo.Add(lampo);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }//create*/

        // GET: TaloLampo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampo talolampo = db.TaloLampo.Find(id);
            if (talolampo == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.Huone_ID = talolampo.Huone_ID;
            lampo.Huone = talolampo.Huone;
            lampo.HuoneNykyLampo = talolampo.HuoneNykyLampo;
            lampo.HuoneTavoiteLampo = talolampo.HuoneTavoiteLampo;
            //lampo.LampoKirjattu = talolampo.LampoKirjattu;

            return View(lampo);
        }

        // POST: TaloLampo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LampoViewModel model)
            {
                TaloLampo lampo = db.TaloLampo.Find(model.Huone_ID);
                //lampo.Huone_ID = model.Huone_ID;
                lampo.Huone = model.Huone;
                lampo.HuoneNykyLampo = model.HuoneNykyLampo;
                lampo.HuoneTavoiteLampo = model.HuoneTavoiteLampo;
                lampo.LampoKirjattu = DateTime.Now;

                db.SaveChanges();
                return RedirectToAction("Index");     
        }

        // GET: TaloLampo/LampoON/5
        public ActionResult LampoON(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampo talolampo = db.TaloLampo.Find(id);
            if (talolampo == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.Huone_ID = talolampo.Huone_ID;
            lampo.Huone = talolampo.Huone;
            //lampo.HuoneNykyLampo = talolampo.HuoneNykyLampo;
            //lampo.HuoneTavoiteLampo = talolampo.HuoneTavoiteLampo;
            lampo.LampoOn = true;
            lampo.LampoOff = false;
            //lampo.LampoKirjattu = talolampo.LampoKirjattu;

            return View(lampo);
        }

        // POST: TaloLampo/LampoON/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LampoON(LampoViewModel model)
        {
            TaloLampo lampo = db.TaloLampo.Find(model.Huone_ID);
            lampo.Huone_ID = model.Huone_ID;
            lampo.Huone = model.Huone;
            lampo.LampoOn = true;
            lampo.LampoOff = false;
            //lampo.HuoneNykyLampo = model.HuoneNykyLampo;
            //lampo.HuoneTavoiteLampo = model.HuoneTavoiteLampo;
            lampo.LampoKirjattu = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TaloLampo/LampoOFF/5
        public ActionResult LampoOFF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampo talolampo = db.TaloLampo.Find(id);
            if (talolampo == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.Huone_ID = talolampo.Huone_ID;
            lampo.Huone = talolampo.Huone;
            //lampo.HuoneNykyLampo = talolampo.HuoneNykyLampo;
            //lampo.HuoneTavoiteLampo = talolampo.HuoneTavoiteLampo;
            lampo.LampoOn = false;
            lampo.LampoOff = true;
            //lampo.LampoKirjattu = talolampo.LampoKirjattu;

            return View(lampo);
        }

        // POST: TaloLampo/LampoOFF/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LampoOFF(LampoViewModel model)
        {
            TaloLampo lampo = db.TaloLampo.Find(model.Huone_ID);
            lampo.Huone_ID = model.Huone_ID;
            lampo.Huone = model.Huone;
            lampo.LampoOn = false;
            lampo.LampoOff = true;
            //lampo.HuoneNykyLampo = model.HuoneNykyLampo;
            //lampo.HuoneTavoiteLampo = model.HuoneTavoiteLampo;
            lampo.LampoKirjattu = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TaloLampo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampo talolampo = db.TaloLampo.Find(id);
            if (talolampo == null)
            {
                return HttpNotFound();
            }

            LampoViewModel lampo = new LampoViewModel();
            lampo.Huone_ID = talolampo.Huone_ID;
            lampo.Huone = talolampo.Huone;
            lampo.HuoneNykyLampo = talolampo.HuoneNykyLampo;
            lampo.HuoneTavoiteLampo = talolampo.HuoneTavoiteLampo;
            lampo.LampoKirjattu = talolampo.LampoKirjattu;
            lampo.LampoOn = talolampo.LampoOn;
            lampo.LampoOff = talolampo.LampoOff;

            return View(lampo);
        }

        // POST: TaloLampo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaloLampo talolampo = db.TaloLampo.Find(id);
            db.TaloLampo.Remove(talolampo);
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
