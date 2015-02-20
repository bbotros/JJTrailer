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
    public class WeightClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/WeightClasses
        public async Task<ActionResult> Index()
        {
            return View(await db.WeightClasses.ToListAsync());
        }

        // GET: Admin/WeightClasses/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightClass weightClass = await db.WeightClasses.FindAsync(id);
            if (weightClass == null)
            {
                return HttpNotFound();
            }
            return View(weightClass);
        }

        // GET: Admin/WeightClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/WeightClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] WeightClass weightClass)
        {
            if (ModelState.IsValid)
            {
                weightClass.ID = Guid.NewGuid();
                db.WeightClasses.Add(weightClass);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(weightClass);
        }

        // GET: Admin/WeightClasses/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightClass weightClass = await db.WeightClasses.FindAsync(id);
            if (weightClass == null)
            {
                return HttpNotFound();
            }
            return View(weightClass);
        }

        // POST: Admin/WeightClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] WeightClass weightClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weightClass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(weightClass);
        }

        // GET: Admin/WeightClasses/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeightClass weightClass = await db.WeightClasses.FindAsync(id);
            if (weightClass == null)
            {
                return HttpNotFound();
            }
            return View(weightClass);
        }

        // POST: Admin/WeightClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            WeightClass weightClass = await db.WeightClasses.FindAsync(id);
            db.WeightClasses.Remove(weightClass);
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
