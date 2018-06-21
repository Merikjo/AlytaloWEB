using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ÄlytaloWEB.Models;
using System.Globalization;
using ÄlytaloWEB.ViewModels;

namespace ÄlytaloWEB.Controllers
{
    public class TaloValoController : Controller
    {
        private JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

        // GET: TaloValo
        public ActionResult Index()
        {
            List<LightsViewModel> model = new List<LightsViewModel>();
            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();

            try
            {
                List<TaloValo> talovalot = entities.TaloValo.OrderByDescending(TaloValo => TaloValo.ValaisinType).ToList();

                // muodostetaan näkymämalli tietokannan rivien pohjalta
                foreach (TaloValo talovalo in talovalot)
                {
                    LightsViewModel valo = new LightsViewModel();
                    valo.Valo_ID = talovalo.Valo_ID;
                    valo.Huone = talovalo.Huone;
                    valo.ValaisinType = talovalo.ValaisinType;
                    valo.Lamppu_ID = talovalo.Lamppu_ID;
                    valo.ValoTilaOff = talovalo.ValoTilaOff;
                    valo.Valo33 = talovalo.Valo33;
                    valo.Valo66 = talovalo.Valo66;
                    valo.Valo100 = talovalo.Valo100;
                    valo.ValoOn33 = talovalo.ValoOn33;
                    valo.ValoOn66 = talovalo.ValoOn66;
                    valo.ValoOn100 = talovalo.ValoOn100;
                    valo.ValoOff = talovalo.ValoOff;

                    model.Add(valo);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);

        }

        CultureInfo fiFi = new CultureInfo("fi-FI");
    

        // GET: TaloValo/Details/5
        public ActionResult Details(int? id)
        {
            LightsViewModel model = new LightsViewModel();

            JohaMeriSQL2Entities entities = new JohaMeriSQL2Entities();
            try
            {
                TaloValo taloValo = db.TaloValo.Find(id);
                if (taloValo == null)
                {
                    return HttpNotFound();
                }

                TaloValo valodetail = entities.TaloValo.Find(taloValo.Valo_ID);

                LightsViewModel valo = new LightsViewModel();
                valo.Valo_ID = valodetail.Valo_ID;
                valo.Huone = valodetail.Huone;
                valo.ValaisinType = valodetail.ValaisinType;
                valo.Lamppu_ID = valodetail.Lamppu_ID;
                valo.ValoTilaOff = valodetail.ValoTilaOff;
                valo.Valo33 = valodetail.Valo33;
                valo.Valo66 = valodetail.Valo66;
                valo.Valo100 = valodetail.Valo100;
                valo.ValoOn33 = valodetail.ValoOn33;
                valo.ValoOn66 = valodetail.ValoOn66;
                valo.ValoOn100 = valodetail.ValoOn100;
                valo.ValoOff = valodetail.ValoOff;

                model = valo;

            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: TaloValo/Create
        public ActionResult Create()
        {
            JohaMeriSQL2Entities db = new JohaMeriSQL2Entities();

            LightsViewModel model = new LightsViewModel();

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinType = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            return View(model);
        }

        // POST: TaloValo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LightsViewModel model)
        {
            TaloValo valo = new TaloValo();
            valo.Valo_ID = model.Valo_ID;
            valo.Huone = model.Huone;
            valo.ValaisinType = model.ValaisinType;
            valo.Lamppu_ID = model.Lamppu_ID;
            //valo.ValoOn33 = DateTime.Now;
            //valo.ValoOn66 = DateTime.Now;
            //valo.ValoOn100 = DateTime.Now;
            //valo.ValoOff = DateTime.Now;

            db.TaloValo.Add(valo);

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            try
            {
                db.SaveChanges();
            }

            catch (Exception ex)
            {
            }

            return RedirectToAction("Index");
        }//create*/;

        // GET: TaloValo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo talovalo = db.TaloValo.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            LightsViewModel valo = new LightsViewModel();
            valo.Valo_ID = talovalo.Valo_ID;
            valo.Huone = talovalo.Huone;
            valo.ValaisinType = talovalo.ValaisinType;
            valo.Lamppu_ID = talovalo.Lamppu_ID;
            //valo.ValoOn33 = DateTime.Now;
            //valo.ValoOn66 = DateTime.Now;
            //valo.ValoOn100 = DateTime.Now;
            //valo.ValoOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            return View(valo);
        }

        // POST: TaloValo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LightsViewModel model)
        {
            TaloValo valo = db.TaloValo.Find(model.Valo_ID);
            //valo.Valo_ID = model.Valo_ID;
            valo.Huone = model.Huone;
            valo.ValaisinType = model.ValaisinType;
            valo.Lamppu_ID = model.Lamppu_ID;
            //valo.ValoOn33 = DateTime.Now;
            //valo.ValoOn66 = DateTime.Now;
            //valo.ValoOn100 = DateTime.Now;
            //valo.ValoOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//edit

        // GET: TaloValo/LightsOff/5
        public ActionResult LightsOff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo talovalo = db.TaloValo.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            LightsViewModel valo = new LightsViewModel();
            valo.Valo_ID = talovalo.Valo_ID;
            valo.Huone = talovalo.Huone;
            valo.ValaisinType = talovalo.ValaisinType;
            valo.Lamppu_ID = talovalo.Lamppu_ID;
            valo.Valo33 = false;   
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = true;
            //valo.ValoOn33 = DateTime.Now;
            //valo.ValoOn66 = DateTime.Now;
            //valo.ValoOn100 = DateTime.Now;

            return View(valo);
        }

        // POST: TaloValo/LightsOff/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LightsOff(LightsViewModel model)
        {
            TaloValo valo = db.TaloValo.Find(model.Valo_ID);
            valo.Huone = model.Huone;
            valo.ValaisinType = model.ValaisinType;
            valo.Lamppu_ID = model.Lamppu_ID;
            valo.Valo33 = false;
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = true;
            //valo.ValoOn33 = DateTime.Now;
            //valo.ValoOn66 = DateTime.Now;
            //valo.ValoOn100 = DateTime.Now;
            valo.ValoOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloValo/Light33/5
        public ActionResult Light33(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo talovalo = db.TaloValo.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            LightsViewModel valo = new LightsViewModel();
            valo.Valo_ID = talovalo.Valo_ID;
            valo.Huone = talovalo.Huone;
            valo.ValaisinType = talovalo.ValaisinType;
            valo.Lamppu_ID = talovalo.Lamppu_ID;
            valo.Valo33 = true;
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            valo.ValoOn33 = talovalo.ValoOn33;
            //valo.ValoOn66 = talovalo.ValoOn66;
            //valo.ValoOn100 = talovalo.ValoOn100;
            //valo.ValoOff = talovalo.ValoOff;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            return View(valo);
        }

        // POST: TaloValo/Light33/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light33(LightsViewModel model)
        {
            TaloValo valo = db.TaloValo.Find(model.Valo_ID);
            valo.Huone = model.Huone;
            valo.ValaisinType = model.ValaisinType;
            valo.Lamppu_ID = model.Lamppu_ID;
            valo.Valo33 = true;
            valo.Valo66 = false;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            valo.ValoOn33 = DateTime.Now;
            //valo.ValoOn66 = DateTime.Now;
            //valo.ValoOn100 = DateTime.Now;
            //valo.ValoOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinType = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloValo/Light66/5
        public ActionResult Light66(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo talovalo = db.TaloValo.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            LightsViewModel valo = new LightsViewModel();
            valo.Valo_ID = talovalo.Valo_ID;
            valo.Huone = talovalo.Huone;
            valo.ValaisinType = talovalo.ValaisinType;
            valo.Lamppu_ID = talovalo.Lamppu_ID;
            valo.Valo33 = false;
            valo.Valo66 = true;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            //valo.ValoOn33 = talovalo.ValoOn33;
            valo.ValoOn66 = talovalo.ValoOn66;
            //valo.ValoOn100 = talovalo.ValoOn100;
            //valo.ValoOff = talovalo.ValoOff;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            return View(valo);
        }

        // POST: TaloValo/Light66/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light66(LightsViewModel model)
        {
            TaloValo valo = db.TaloValo.Find(model.Valo_ID);
            valo.Huone = model.Huone;
            valo.ValaisinType = model.ValaisinType;
            valo.Lamppu_ID = model.Lamppu_ID;
            valo.Valo33 = false;
            valo.Valo66 = true;
            valo.Valo100 = false;
            valo.ValoTilaOff = false;
            //valo.ValoOn33 = DateTime.Now;
            valo.ValoOn66 = DateTime.Now;
            //valo.ValoOn100 = DateTime.Now;
            //valo.ValoOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//

        // GET: TaloValo/Light100/5
        public ActionResult Light100(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo talovalo = db.TaloValo.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            LightsViewModel valo = new LightsViewModel();
            valo.Valo_ID = talovalo.Valo_ID;
            valo.Huone = talovalo.Huone;
            valo.ValaisinType = talovalo.ValaisinType;
            valo.Lamppu_ID = talovalo.Lamppu_ID;
            valo.Valo33 = false;
            valo.Valo66 = false;
            valo.Valo100 = true;
            valo.ValoTilaOff = false;
            //valo.ValoOn33 = talovalo.ValoOn33;
            //valo.ValoOn66 = talovalo.ValoOn66;
            valo.ValoOn100 = talovalo.ValoOn100;
            //valo.ValoOff = talovalo.ValoOff;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            return View(valo);
        }

        // POST: TaloValo/Light66/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Light100(LightsViewModel model)
        {
            TaloValo valo = db.TaloValo.Find(model.Valo_ID);
            valo.Huone = model.Huone;
            valo.ValaisinType = model.ValaisinType;
            valo.Lamppu_ID = model.Lamppu_ID;
            valo.Valo33 = false;
            valo.Valo66 = false;
            valo.Valo100 = true;
            valo.ValoTilaOff = false;
            //valo.ValoOn33 = DateTime.Now;
            //valo.ValoOn66 = DateTime.Now;
            valo.ValoOn100 = DateTime.Now;
            //valo.ValoOff = DateTime.Now;

            ViewBag.Huone = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "Huone", null);
            ViewBag.ValaisinTYpe = new SelectList((from tv in db.TaloValo select new { Valo_ID = tv.Valo_ID, Huone = tv.Huone }), "Valo_ID", "ValaisinType", null);

            db.SaveChanges();

            return RedirectToAction("Index");
        }//


        // GET: TaloValo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloValo talovalo = db.TaloValo.Find(id);
            if (talovalo == null)
            {
                return HttpNotFound();
            }

            LightsViewModel valo = new LightsViewModel();
            valo.Valo_ID = talovalo.Valo_ID;
            valo.Huone = talovalo.Huone;
            valo.ValaisinType = talovalo.ValaisinType;
            valo.Lamppu_ID = talovalo.Lamppu_ID;
            valo.ValoTilaOff = talovalo.ValoTilaOff;
            valo.Valo33 = talovalo.Valo33;
            valo.Valo66 = talovalo.Valo66;
            valo.Valo100 = talovalo.Valo100;
            valo.ValoOn33 = talovalo.ValoOn33;
            valo.ValoOn66 = talovalo.ValoOn66;
            valo.ValoOn100 = talovalo.ValoOn100;
            valo.ValoOff = talovalo.ValoOff;

            return View(valo);
        }

        // POST: TaloValo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaloValo talovalo = db.TaloValo.Find(id);
            db.TaloValo.Remove(talovalo);
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
