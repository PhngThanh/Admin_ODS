using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Admin_Page.Models;

namespace Admin_Page.Controllers
{
    public class AuthorizeCodesController : Controller
    {
        private DB_Entity db = new DB_Entity();

        // GET: AuthorizeCodes
        public ActionResult Index()
        {
            return View(db.AuthorizeCodes.ToList());
        }

        // GET: AuthorizeCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizeCode authorizeCode = db.AuthorizeCodes.Find(id);
            if (authorizeCode == null)
            {
                return HttpNotFound();
            }
            return View(authorizeCode);
        }

        // GET: AuthorizeCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorizeCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeId,code,createDate,expiredDate")] AuthorizeCode authorizeCode)
        {
            if (ModelState.IsValid)
            {
                db.AuthorizeCodes.Add(authorizeCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authorizeCode);
        }

        // GET: AuthorizeCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizeCode authorizeCode = db.AuthorizeCodes.Find(id);
            if (authorizeCode == null)
            {
                return HttpNotFound();
            }
            return View(authorizeCode);
        }

        // POST: AuthorizeCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeId,code,createDate,expiredDate")] AuthorizeCode authorizeCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authorizeCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(authorizeCode);
        }

        // GET: AuthorizeCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuthorizeCode authorizeCode = db.AuthorizeCodes.Find(id);
            if (authorizeCode == null)
            {
                return HttpNotFound();
            }
            return View(authorizeCode);
        }

        // POST: AuthorizeCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuthorizeCode authorizeCode = db.AuthorizeCodes.Find(id);
            db.AuthorizeCodes.Remove(authorizeCode);
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
