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
    public class TaloSaunaController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: TaloSauna
        public ActionResult Index()
        {
            List<SaunaViewModel> model = new List<SaunaViewModel>();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            try
            {
                List<TaloSauna> talosaunat = entities.TaloSauna.OrderByDescending(TaloSauna => TaloSauna.SaunaNro).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (TaloSauna talosauna in talosaunat)
                {
                    SaunaViewModel sauna = new SaunaViewModel();
                    sauna.Sauna_ID = talosauna.Sauna_ID;
                    sauna.SaunaNro = talosauna.SaunaNro;
                    sauna.SaunanNimi = talosauna.SaunanNimi;
                    sauna.SaunaTavoiteLampotila = talosauna.SaunaTavoiteLampotila;
                    sauna.SaunaNykyLampotila = talosauna.SaunaNykyLampotila;
                    sauna.SaunaStart = talosauna?.SaunaStart;
                    sauna.SaunaStop = talosauna?.SaunaStop;
                    sauna.SaunanTila = talosauna.SaunanTila;
                   
                    //sauna.Time = DateTime.Now;

                    //if (talosauna != null)
                    //{
                        sauna.TotalHours = (talosauna.SaunaStop.GetValueOrDefault() - talosauna.SaunaStart.GetValueOrDefault()).TotalHours;
                    //}
                    //else
                    //{
                    //    sauna = new SaunaViewModel()
                    //    {
                    //        Sauna_ID = talosauna.Sauna_ID,
                    //        SaunaNro = talosauna.SaunaNro,
                    //        SaunanNimi = talosauna.SaunanNimi,
                    //        SaunaTavoiteLampotila = talosauna.SaunaTavoiteLampotila,
                    //        SaunaNykyLampotila = talosauna.SaunaNykyLampotila,
                    //        SaunaStart = talosauna?.SaunaStart,
                    //        SaunaStop = talosauna?.SaunaStop,
                    //        SaunanTila = talosauna.SaunanTila,
                    //    TotalHours = (talosauna.SaunaStop.GetValueOrDefault() - talosauna.SaunaStart.GetValueOrDefault()).TotalHours
                    //    };

                        //DateTime SaunaStart = new DateTime(2001, 1, 1);

                        ////long elapsedTicks = talosauna.SaunaStart.Ticks - talosauna.SaunaStop.Ticks;
                        ////TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);

                        //if (Session["EndDate"] == null)
                        //{
                        //    Session["EndDate"] = DateTime.Now.AddMinutes(1).ToString("dd-MM-yyy h:mm:ss tt");
                        //}

                        //ViewBag.Message = "Muokkaa timer -tietoa";
                        //ViewBag.EndDate = Session["EndDate"];

                        model.Add(sauna);
                    }
                
                return View(model);
            }
            finally
            {
                entities.Dispose();
            }
        }

        CultureInfo fiFi = new CultureInfo("fi-FI");

        // GET: TaloSauna/Details/5
        public ActionResult Details(int? id)
        { 
            SaunaViewModel model = new SaunaViewModel();
            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            try
            {
                TaloSauna taloSauna = db.TaloSauna.Find(id);
                if (taloSauna == null)
           
                {
                return HttpNotFound();
                }

                TaloSauna saunadetail = entities.TaloSauna.Find(taloSauna.Sauna_ID);

                SaunaViewModel sauna = new SaunaViewModel();
                sauna.Sauna_ID = saunadetail.Sauna_ID;
                sauna.SaunaNro = saunadetail.SaunaNro;
                sauna.SaunanNimi = saunadetail.SaunanNimi;
                sauna.SaunaTavoiteLampotila = saunadetail.SaunaTavoiteLampotila;
                sauna.SaunaNykyLampotila = saunadetail.SaunaNykyLampotila;
                sauna.SaunaStart = saunadetail.SaunaStart.GetValueOrDefault();
                sauna.SaunaStop = saunadetail.SaunaStop.GetValueOrDefault();
                sauna.SaunanTila = saunadetail.SaunanTila;

                model = sauna;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: TaloSauna/Create
        public ActionResult Create()
        {
            JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

            SaunaViewModel model = new SaunaViewModel();

            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", null);

            return View(model);
        }

        // POST: TaloSauna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaunaViewModel model)
        {
            TaloSauna sauna = new TaloSauna();
            sauna.Sauna_ID = model.Sauna_ID;
            sauna.SaunaNro = model.SaunaNro;
            sauna.SaunanNimi = model.SaunanNimi;       
            //sauna.SaunaStart = model.SaunaStart;
            //sauna.SaunaStop = model.SaunaStop;                    
            sauna.SaunaTavoiteLampotila = model.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = model.SaunaNykyLampotila;   
            //sauna.SaunanTila = model.SaunanTila;

            db.TaloSauna.Add(sauna);

            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }//create*/;

        // GET: TaloSauna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.Sauna_ID = taloSauna.Sauna_ID;
            sauna.SaunaNro = taloSauna.SaunaNro;
            sauna.SaunanNimi = taloSauna.SaunanNimi;
            sauna.SaunaTavoiteLampotila = taloSauna.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = taloSauna.SaunaNykyLampotila;
            //sauna.SaunaStart = taloSauna.SaunaStart.GetValueOrDefault();
            //sauna.SaunaStop = taloSauna.SaunaStop.GetValueOrDefault();
            //sauna.SaunanTila = taloSauna.SaunanTila;

            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", sauna.Sauna_ID);

            return View(sauna);
        }

        // POST: TaloSauna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaunaViewModel model)
        {
            TaloSauna sauna = db.TaloSauna.Find(model.Sauna_ID);
            sauna.SaunaNro = model.SaunaNro;
            sauna.SaunanNimi = model.SaunanNimi;
            sauna.SaunaTavoiteLampotila = model.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = model.SaunaNykyLampotila;
            //sauna.SaunaStart = DateTime.Now;
            //sauna.SaunaStop = DateTime.Now;
            //sauna.SaunanTila = model.SaunanTila;

            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", sauna.Sauna_ID);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit


        // GET: TaloSauna/SaunaOn/5
        public ActionResult SaunaOn(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.Sauna_ID = taloSauna.Sauna_ID;
            sauna.SaunaNro = taloSauna.SaunaNro;
            sauna.SaunanNimi = taloSauna.SaunanNimi;
            sauna.SaunaStart = taloSauna.SaunaStart;
            sauna.SaunanTila = true;

            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", sauna.Sauna_ID);

            return View(sauna);
        }

        // POST: TaloSauna/SaunaOn/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOn(SaunaViewModel model)
        {
            TaloSauna sauna = db.TaloSauna.Find(model.Sauna_ID);
            sauna.SaunaNro = model.SaunaNro;
            sauna.SaunanNimi = model.SaunanNimi;
            sauna.SaunaStart = DateTime.Now;        
            sauna.SaunanTila = true;
            
            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", sauna.Sauna_ID);

            db.SaveChanges();
            return RedirectToAction("Index");
        }//

        // GET: TaloSauna/SaunaOff/5
        public ActionResult SaunaOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.Sauna_ID = taloSauna.Sauna_ID;
            sauna.SaunaNro = taloSauna.SaunaNro;
            sauna.SaunanNimi = taloSauna.SaunanNimi;
            sauna.SaunaStop = taloSauna.SaunaStop;
            sauna.SaunanTila = false;

            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", sauna.Sauna_ID);

            return View(sauna);
        }

        // POST: TaloSauna/SaunaOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaunaOff(SaunaViewModel model)
        {
            TaloSauna sauna = db.TaloSauna.Find(model.Sauna_ID);
            sauna.SaunaNro = model.SaunaNro;
            sauna.SaunanNimi = model.SaunanNimi;
            sauna.SaunaStop = DateTime.Now;
            sauna.SaunanTila = false;

            ViewBag.SaunanNimi = new SelectList((from ts in db.TaloSauna select new { Sauna_ID = ts.Sauna_ID, SaunanNimi = ts.SaunanNimi }), "Sauna_ID", "SaunanNimi", sauna.Sauna_ID);

            db.SaveChanges();
            return RedirectToAction("Index");
        }//


        // GET: TaloSauna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            if (taloSauna == null)
            {
                return HttpNotFound();
            }

            SaunaViewModel sauna = new SaunaViewModel();
            sauna.Sauna_ID = taloSauna.Sauna_ID;
            sauna.SaunaNro = taloSauna.SaunaNro;
            sauna.SaunanNimi = taloSauna.SaunanNimi;
            sauna.SaunaTavoiteLampotila = taloSauna.SaunaTavoiteLampotila;
            sauna.SaunaNykyLampotila = taloSauna.SaunaNykyLampotila;
            sauna.SaunaStart = taloSauna.SaunaStart.GetValueOrDefault();
            sauna.SaunaStop = taloSauna.SaunaStop.GetValueOrDefault();
            sauna.SaunanTila = taloSauna.SaunanTila;

            return View(sauna);
        }

        // POST: TaloSauna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaloSauna taloSauna = db.TaloSauna.Find(id);
            db.TaloSauna.Remove(taloSauna);
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
