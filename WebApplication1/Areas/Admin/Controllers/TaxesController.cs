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
    public class TaxesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Taxes
        public async Task<ActionResult> Index()
        {
            return View(await db.Taxes.ToListAsync());
        }

        // GET: Admin/Taxes/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tax tax = await db.Taxes.FindAsync(id);
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // GET: Admin/Taxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Taxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Percentage")] Tax tax)
        {
            if (ModelState.IsValid)
            {
                tax.ID = Guid.NewGuid();
                db.Taxes.Add(tax);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tax);
        }

        // GET: Admin/Taxes/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tax tax = await db.Taxes.FindAsync(id);
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // POST: Admin/Taxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Percentage")] Tax tax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tax).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tax);
        }

        // GET: Admin/Taxes/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tax tax = await db.Taxes.FindAsync(id);
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // POST: Admin/Taxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Tax tax = await db.Taxes.FindAsync(id);
            db.Taxes.Remove(tax);
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
