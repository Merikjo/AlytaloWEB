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
   
    public class TaloIlmaController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: TaloIlma
        public ActionResult Index()
        {
            List<IlmaViewModel> model = new List<IlmaViewModel>();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            try
            {
                List<TaloIlma> taloilmat = entities.TaloIlma.OrderByDescending(TaloIlma => TaloIlma.Huone).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (TaloIlma taloilma in taloilmat)
                {
                    IlmaViewModel ilma = new IlmaViewModel();
                    ilma.Ilma_ID = taloilma.Ilma_ID;
                    ilma.Huone = taloilma.Huone;     
                    ilma.IlmaTilaOff = taloilma.IlmaTilaOff;
                    ilma.Ilma1 = taloilma.Ilma1;
                    ilma.Ilma2 = taloilma.Ilma2;
                    ilma.Ilma3 = taloilma.Ilma3;
                    ilma.Ilma4 = taloilma.Ilma4;
                    ilma.IlmaOn1 = taloilma.IlmaOn1;
                    ilma.IlmaOn2 = taloilma.IlmaOn2;
                    ilma.IlmaOn3 = taloilma.IlmaOn3;
                    ilma.IlmaOn4 = taloilma.IlmaOn4;
                    ilma.IlmaOff = taloilma.IlmaOff;

                    model.Add(ilma);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);

        }

        CultureInfo fiFi = new CultureInfo("fi-FI");


        // GET: TaloIlma/Details/5
        public ActionResult Details(int? id)
        {
            IlmaViewModel model = new IlmaViewModel();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();
            try
            {
                TaloIlma taloilma = db.TaloIlma.Find(id);
                if (taloilma == null)

                {
                    return HttpNotFound();
                }

                TaloIlma ilmadetail = entities.TaloIlma.Find(taloilma.Ilma_ID);

                IlmaViewModel ilma = new IlmaViewModel();
                ilma.Ilma_ID = ilmadetail.Ilma_ID;
                ilma.Huone = ilmadetail.Huone;
                ilma.IlmaTilaOff = ilmadetail.IlmaTilaOff;
                ilma.Ilma1 = ilmadetail.Ilma1;
                ilma.Ilma2 = ilmadetail.Ilma2;
                ilma.Ilma3 = ilmadetail.Ilma3;
                ilma.Ilma4 = ilmadetail.Ilma4;
                ilma.IlmaOn1 = ilmadetail.IlmaOn1;
                ilma.IlmaOn2 = ilmadetail.IlmaOn2;
                ilma.IlmaOn3 = ilmadetail.IlmaOn3;
                ilma.IlmaOn4 = ilmadetail.IlmaOn4;
                ilma.IlmaOff = ilmadetail.IlmaOff;

                model = ilma;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: TaloIlma/Create 
        public ActionResult Create()
        {
            JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

            IlmaViewModel model = new IlmaViewModel();

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            return View(model);
        }

        // POST: TaloIlma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IlmaViewModel model)
        {
            TaloIlma ilma = new TaloIlma();
            ilma.Ilma_ID = model.Ilma_ID;
            ilma.Huone = model.Huone;
            //ilma.IlmaTilaOff = model.IlmaTilaOff;
            //ilma.Ilma1 = model.Ilma1;
            //ilma.Ilma2 = model.Ilma2;
            //ilma.Ilma3 = model.Ilma3;
            //ilma.Ilma4 = model.Ilma4;
            //ilma.IlmaOn1 = model.IlmaOn1;
            //ilma.IlmaOn2 = model.IlmaOn2;
            //ilma.IlmaOn3 = model.IlmaOn3;
            //ilma.IlmaOn4 = model.IlmaOn4;
            //ilma.IlmaOff = model.IlmaOff;

            db.TaloIlma.Add(ilma);

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }//create*/;


        // GET: TaloIlma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloIlma taloilma = db.TaloIlma.Find(id);
            if (taloilma == null)
            {
                return HttpNotFound();
            }

            IlmaViewModel ilma = new IlmaViewModel();
            ilma.Ilma_ID = taloilma.Ilma_ID;
            ilma.Huone = taloilma.Huone;
            //ilma.IlmaTilaOff = taloilma.IlmaTilaOff;
            //ilma.Ilma1 = taloilma.Ilma1;
            //ilma.Ilma2 = taloilma.Ilma2;
            //ilma.Ilma3 = taloilma.Ilma3;
            //ilma.Ilma4 = taloilma.Ilma4;
            //ilma.IlmaOn1 = taloilma.IlmaOn1;
            //ilma.IlmaOn2 = taloilma.IlmaOn2;
            //ilma.IlmaOn3 = taloilma.IlmaOn3;
            //ilma.IlmaOn4 = taloilma.IlmaOn4;
            //ilma.IlmaOff = taloilma.IlmaOff;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            return View(ilma);
        }

        // POST: TaloIlma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IlmaViewModel model)
        {
            TaloIlma ilma = db.TaloIlma.Find(model.Ilma_ID);
            ilma.Huone = model.Huone;
            //ilma.IlmaTilaOff = model.IlmaTilaOff;
            //ilma.Ilma1 = model.Ilma1;
            //ilma.Ilma2 = model.Ilma2;
            //ilma.Ilma3 = model.Ilma3;
            //ilma.Ilma4 = model.Ilma4;
            //ilma.IlmaOn1 = model.IlmaOn1;
            //ilma.IlmaOn2 = model.IlmaOn2;
            //ilma.IlmaOn3 = model.IlmaOn3;
            //ilma.IlmaOn4 = model.IlmaOn4;
            //ilma.IlmaOff = model.IlmaOff;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit

        // GET: TaloIlma/IlmaOn1/5
        public ActionResult IlmaOn1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloIlma taloilma = db.TaloIlma.Find(id);
            if (taloilma == null)
            {
                return HttpNotFound();
            }

            IlmaViewModel ilma = new IlmaViewModel();
            ilma.Ilma_ID = taloilma.Ilma_ID;
            ilma.Huone = taloilma.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = true;
            ilma.Ilma2 = false;
            ilma.Ilma3 = false;
            ilma.Ilma4 = false;
            ilma.IlmaOn1 = taloilma.IlmaOn1;
            //ilma.IlmaOn2 = taloilma.IlmaOn2;
            //ilma.IlmaOn3 = taloilma.IlmaOn3;
            //ilma.IlmaOn4 = taloilma.IlmaOn4;
            //ilma.IlmaOff = taloilma.IlmaOff;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            return View(ilma);
        }

        // POST: TaloIlma/IlmaOn1/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlmaOn1(IlmaViewModel model)
        {
            TaloIlma ilma = db.TaloIlma.Find(model.Ilma_ID);
            ilma.Huone = model.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = true;
            ilma.Ilma2 = false;
            ilma.Ilma3 = false;
            ilma.Ilma4 = false;
            ilma.IlmaOn1 = DateTime.Now;
            //ilma.IlmaOn2 = DateTime.Now;
            //ilma.IlmaOn3 = DateTime.Now;
            //ilma.IlmaOn4 = DateTime.Now;
            //ilma.IlmaOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloIlma/IlmaOn2/5
        public ActionResult IlmaOn2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloIlma taloilma = db.TaloIlma.Find(id);
            if (taloilma == null)
            {
                return HttpNotFound();
            }

            IlmaViewModel ilma = new IlmaViewModel();
            ilma.Ilma_ID = taloilma.Ilma_ID;
            ilma.Huone = taloilma.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = false;
            ilma.Ilma2 = true;
            ilma.Ilma3 = false;
            ilma.Ilma4 = false;
            //ilma.IlmaOn1 = taloilma.IlmaOn1;
            ilma.IlmaOn2 = taloilma.IlmaOn2;
            //ilma.IlmaOn3 = taloilma.IlmaOn3;
            //ilma.IlmaOn4 = taloilma.IlmaOn4;
            //ilma.IlmaOff = taloilma.IlmaOff;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            return View(ilma);
        }

        // POST: TaloIlma/IlmaOn2/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlmaOn2(IlmaViewModel model)
        {
            TaloIlma ilma = db.TaloIlma.Find(model.Ilma_ID);
            ilma.Huone = model.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = false;
            ilma.Ilma2 = true;
            ilma.Ilma3 = false;
            ilma.Ilma4 = false;
            //ilma.IlmaOn1 = DateTime.Now;
            ilma.IlmaOn2 = DateTime.Now;
            //ilma.IlmaOn3 = DateTime.Now;
            //ilma.IlmaOn4 = DateTime.Now;
            //ilma.IlmaOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloIlma/IlmaOn3/5
        public ActionResult IlmaOn3(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloIlma taloilma = db.TaloIlma.Find(id);
            if (taloilma == null)
            {
                return HttpNotFound();
            }

            IlmaViewModel ilma = new IlmaViewModel();
            ilma.Ilma_ID = taloilma.Ilma_ID;
            ilma.Huone = taloilma.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = false;
            ilma.Ilma2 = false;
            ilma.Ilma3 = true;
            ilma.Ilma4 = false;
            //ilma.IlmaOn1 = taloilma.IlmaOn1;
            //ilma.IlmaOn2 = taloilma.IlmaOn2;
            ilma.IlmaOn3 = taloilma.IlmaOn3;
            //ilma.IlmaOn4 = taloilma.IlmaOn4;
            //ilma.IlmaOff = taloilma.IlmaOff;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            return View(ilma);
        }

        // POST: TaloIlma/IlmaOn3/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlmaOn3(IlmaViewModel model)
        {
            TaloIlma ilma = db.TaloIlma.Find(model.Ilma_ID);
            ilma.Huone = model.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = false;
            ilma.Ilma2 = false;
            ilma.Ilma3 = true;
            ilma.Ilma4 = false;
            //ilma.IlmaOn1 = DateTime.Now;
            //ilma.IlmaOn2 = DateTime.Now;
            ilma.IlmaOn3 = DateTime.Now;
            //ilma.IlmaOn4 = DateTime.Now;
            //ilma.IlmaOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloIlma/IlmaOn4/5
        public ActionResult IlmaOn4(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloIlma taloilma = db.TaloIlma.Find(id);
            if (taloilma == null)
            {
                return HttpNotFound();
            }

            IlmaViewModel ilma = new IlmaViewModel();
            ilma.Ilma_ID = taloilma.Ilma_ID;
            ilma.Huone = taloilma.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = false;
            ilma.Ilma2 = false;
            ilma.Ilma3 = false;
            ilma.Ilma4 = true;
            //ilma.IlmaOn1 = taloilma.IlmaOn1;
            //ilma.IlmaOn2 = taloilma.IlmaOn2;
            //ilma.IlmaOn3 = taloilma.IlmaOn3;
            ilma.IlmaOn4 = taloilma.IlmaOn4;
            //ilma.IlmaOff = taloilma.IlmaOff;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            return View(ilma);
        }

        // POST: TaloIlma/IlmaOn4/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlmaOn4(IlmaViewModel model)
        {
            TaloIlma ilma = db.TaloIlma.Find(model.Ilma_ID);
            ilma.Huone = model.Huone;
            ilma.IlmaTilaOff = false;
            ilma.Ilma1 = false;
            ilma.Ilma2 = false;
            ilma.Ilma3 = false;
            ilma.Ilma4 = true;
            //ilma.IlmaOn1 = DateTime.Now;
            //ilma.IlmaOn2 = DateTime.Now;
            //ilma.IlmaOn3 = DateTime.Now;
            ilma.IlmaOn4 = DateTime.Now;
            //ilma.IlmaOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloIlma/IlmaOff/5
        public ActionResult IlmaOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloIlma taloilma = db.TaloIlma.Find(id);
            if (taloilma == null)
            {
                return HttpNotFound();
            }

            IlmaViewModel ilma = new IlmaViewModel();
            ilma.Ilma_ID = taloilma.Ilma_ID;
            ilma.Huone = taloilma.Huone;
            ilma.IlmaTilaOff = true;
            ilma.Ilma1 = false;
            ilma.Ilma2 = false;
            ilma.Ilma3 = false;
            ilma.Ilma4 = false;
            //ilma.IlmaOn1 = taloilma.IlmaOn1;
            //ilma.IlmaOn2 = taloilma.IlmaOn2;
            //ilma.IlmaOn3 = taloilma.IlmaOn3;
            //ilma.IlmaOn4 = taloilma.IlmaOn4;
            ilma.IlmaOff = taloilma.IlmaOff;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            return View(ilma);
        }

        // POST: TaloIlma/IlmaOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IlmaOff(IlmaViewModel model)
        {
            TaloIlma ilma = db.TaloIlma.Find(model.Ilma_ID);
            ilma.Huone = model.Huone;
            ilma.IlmaTilaOff = true;
            ilma.Ilma1 = false;
            ilma.Ilma2 = false;
            ilma.Ilma3 = false;
            ilma.Ilma4 = false;
            //ilma.IlmaOn1 = DateTime.Now;
            //ilma.IlmaOn2 = DateTime.Now;
            //ilma.IlmaOn3 = DateTime.Now;
            //ilma.IlmaOn4 = DateTime.Now;
            ilma.IlmaOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from ti in db.TaloIlma select new { Ilma_ID = ti.Ilma_ID, Huone = ti.Huone }), "Ilma_ID", "Huone", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloIlma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloIlma taloilma = db.TaloIlma.Find(id);
            if (taloilma == null)
            {
                return HttpNotFound();
            }

            IlmaViewModel ilma = new IlmaViewModel();
            ilma.Ilma_ID = taloilma.Ilma_ID;
            ilma.Huone = taloilma.Huone;
            ilma.IlmaTilaOff = taloilma.IlmaTilaOff;
            ilma.Ilma1 = taloilma.Ilma1;
            ilma.Ilma2 = taloilma.Ilma2;
            ilma.Ilma3 = taloilma.Ilma3;
            ilma.Ilma4 = taloilma.Ilma4;
            ilma.IlmaOn1 = taloilma.IlmaOn1;
            ilma.IlmaOn2 = taloilma.IlmaOn2;
            ilma.IlmaOn3 = taloilma.IlmaOn3;
            ilma.IlmaOn4 = taloilma.IlmaOn4;
            ilma.IlmaOff = taloilma.IlmaOff;

            return View(ilma);
        }

        // POST: TaloIlma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaloIlma taloilma = db.TaloIlma.Find(id);
            db.TaloIlma.Remove(taloilma);
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
