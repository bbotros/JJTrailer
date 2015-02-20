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
    public class DimensionClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/DimensionClasses
        public async Task<ActionResult> Index()
        {
            return View(await db.DimensionClasses.ToListAsync());
        }

        // GET: Admin/DimensionClasses/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimensionClass dimensionClass = await db.DimensionClasses.FindAsync(id);
            if (dimensionClass == null)
            {
                return HttpNotFound();
            }
            return View(dimensionClass);
        }

        // GET: Admin/DimensionClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DimensionClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] DimensionClass dimensionClass)
        {
            if (ModelState.IsValid)
            {
                dimensionClass.ID = Guid.NewGuid();
                db.DimensionClasses.Add(dimensionClass);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dimensionClass);
        }

        // GET: Admin/DimensionClasses/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimensionClass dimensionClass = await db.DimensionClasses.FindAsync(id);
            if (dimensionClass == null)
            {
                return HttpNotFound();
            }
            return View(dimensionClass);
        }

        // POST: Admin/DimensionClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] DimensionClass dimensionClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimensionClass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dimensionClass);
        }

        // GET: Admin/DimensionClasses/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DimensionClass dimensionClass = await db.DimensionClasses.FindAsync(id);
            if (dimensionClass == null)
            {
                return HttpNotFound();
            }
            return View(dimensionClass);
        }

        // POST: Admin/DimensionClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            DimensionClass dimensionClass = await db.DimensionClasses.FindAsync(id);
            db.DimensionClasses.Remove(dimensionClass);
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
