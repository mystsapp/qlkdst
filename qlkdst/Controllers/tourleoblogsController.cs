using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using qlkdstDB.EF;
using qlkdstDB.DAO;

namespace qlkdst.Controllers
{
    public class tourleoblogsController : Controller
    {
        private qlkdtrEntities db = new qlkdtrEntities();

        // GET: tourleoblogs
        //public ActionResult Index()
        //{
        //    return View(db.tourleoblog.ToList());
        //}
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var session = Session["username"];
            var dao = new tourleoblogDAO();

            var model = dao.ListAllPageList(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        // GET: tourleoblogs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourleoblog tourleoblog = db.tourleoblog.Find(id);
            if (tourleoblog == null)
            {
                return HttpNotFound();
            }
            return View(tourleoblog);
        }

        // GET: tourleoblogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tourleoblogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idlog,sgtcode,makh,chudetour,batdau,ketthuc,tuyentq,diemtq,chuongtrinhtour,sokhachdk,thongbaoloi")] tourleoblog tourleoblog)
        {
            if (ModelState.IsValid)
            {
                db.tourleoblog.Add(tourleoblog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tourleoblog);
        }

        // GET: tourleoblogs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourleoblog tourleoblog = db.tourleoblog.Find(id);
            if (tourleoblog == null)
            {
                return HttpNotFound();
            }
            return View(tourleoblog);
        }

        // POST: tourleoblogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlog,sgtcode,makh,chudetour,batdau,ketthuc,tuyentq,diemtq,chuongtrinhtour,sokhachdk,thongbaoloi")] tourleoblog tourleoblog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourleoblog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tourleoblog);
        }

        // GET: tourleoblogs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tourleoblog tourleoblog = db.tourleoblog.Find(id);
            if (tourleoblog == null)
            {
                return HttpNotFound();
            }
            return View(tourleoblog);
        }

        // POST: tourleoblogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tourleoblog tourleoblog = db.tourleoblog.Find(id);
            db.tourleoblog.Remove(tourleoblog);
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
