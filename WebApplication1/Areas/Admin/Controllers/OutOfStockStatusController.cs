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
    public class OutOfStockStatusController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/OutOfStockStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.OutOfStockStatus.ToListAsync());
        }

        // GET: Admin/OutOfStockStatus/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutOfStockStatus outOfStockStatus = await db.OutOfStockStatus.FindAsync(id);
            if (outOfStockStatus == null)
            {
                return HttpNotFound();
            }
            return View(outOfStockStatus);
        }

        // GET: Admin/OutOfStockStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OutOfStockStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] OutOfStockStatus outOfStockStatus)
        {
            if (ModelState.IsValid)
            {
                outOfStockStatus.ID = Guid.NewGuid();
                db.OutOfStockStatus.Add(outOfStockStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(outOfStockStatus);
        }

        // GET: Admin/OutOfStockStatus/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutOfStockStatus outOfStockStatus = await db.OutOfStockStatus.FindAsync(id);
            if (outOfStockStatus == null)
            {
                return HttpNotFound();
            }
            return View(outOfStockStatus);
        }

        // POST: Admin/OutOfStockStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] OutOfStockStatus outOfStockStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outOfStockStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(outOfStockStatus);
        }

        // GET: Admin/OutOfStockStatus/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutOfStockStatus outOfStockStatus = await db.OutOfStockStatus.FindAsync(id);
            if (outOfStockStatus == null)
            {
                return HttpNotFound();
            }
            return View(outOfStockStatus);
        }

        // POST: Admin/OutOfStockStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            OutOfStockStatus outOfStockStatus = await db.OutOfStockStatus.FindAsync(id);
            db.OutOfStockStatus.Remove(outOfStockStatus);
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
