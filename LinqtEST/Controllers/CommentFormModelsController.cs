using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LinqtEST.Models;

namespace LinqtEST.Controllers
{
    public class CommentFormModelsController : Controller
    {
        private LinqtESTContext db = new LinqtESTContext();

        // GET: CommentFormModels
        public ActionResult Index()
        {
            return View(db.CommentFormModels.ToList());
        }

        public ActionResult Index(CommentFormSearchModel searchModel)
        {
            var business = new CommentFormLogic();
            var model = business.GetComments(searchModel);
            return View(model);
        }

        // GET: CommentFormModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            if (commentFormModel == null)
            {
                return HttpNotFound();
            }
            return View(commentFormModel);
        }

        // GET: CommentFormModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentFormModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Comment,Priority,Whatever")] CommentFormModel commentFormModel)
        {
            if (ModelState.IsValid)
            {
                db.CommentFormModels.Add(commentFormModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(commentFormModel);
        }

        // GET: CommentFormModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            if (commentFormModel == null)
            {
                return HttpNotFound();
            }
            return View(commentFormModel);
        }

        // POST: CommentFormModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Comment,Priority,Whatever")] CommentFormModel commentFormModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentFormModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(commentFormModel);
        }

        // GET: CommentFormModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            if (commentFormModel == null)
            {
                return HttpNotFound();
            }
            return View(commentFormModel);
        }

        // POST: CommentFormModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommentFormModel commentFormModel = db.CommentFormModels.Find(id);
            db.CommentFormModels.Remove(commentFormModel);
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
