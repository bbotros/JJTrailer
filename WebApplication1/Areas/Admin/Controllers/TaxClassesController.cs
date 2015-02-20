using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JJTrailerStore.Areas.Admin.Models;
using JJTrailerStore.Models;

namespace JJTrailerStore.Areas.Admin.Controllers
{
    public class TaxClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/TaxClasses
        public async Task<ActionResult> Index()
        {
            return View(await db.TaxClasses.ToListAsync());
        }

        // GET: Admin/TaxClasses/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxClass taxClass = await db.TaxClasses.FindAsync(id);
            if (taxClass == null)
            {
                return HttpNotFound();
            }
            return View(taxClass);
        }

        // GET: Admin/TaxClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TaxClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Percentage")] TaxClass taxClass)
        {
            if (ModelState.IsValid)
            {
                taxClass.ID = Guid.NewGuid();
                db.TaxClasses.Add(taxClass);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(taxClass);
        }

        // GET: Admin/TaxClasses/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxClass taxClass = await db.TaxClasses.FindAsync(id);
            if (taxClass == null)
            {
                return HttpNotFound();
            }
            return View(taxClass);
        }

        // POST: Admin/TaxClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Percentage")] TaxClass taxClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taxClass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(taxClass);
        }

        // GET: Admin/TaxClasses/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaxClass taxClass = await db.TaxClasses.FindAsync(id);
            if (taxClass == null)
            {
                return HttpNotFound();
            }
            return View(taxClass);
        }

        // POST: Admin/TaxClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            TaxClass taxClass = await db.TaxClasses.FindAsync(id);
            db.TaxClasses.Remove(taxClass);
            await db.SaveChangesAsync();
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
