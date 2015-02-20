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
    public class ShippingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Shippings
        public async Task<ActionResult> Index()
        {
            return View(await db.Shippings.ToListAsync());
        }

        // GET: Admin/Shippings/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // GET: Admin/Shippings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Shippings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ShippingMethodID,ShippingPickupDate,isShipped,isArrived,ActualArrivalDate,EstimatedArrivalDate")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                shipping.ID = Guid.NewGuid();
                db.Shippings.Add(shipping);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(shipping);
        }

        // GET: Admin/Shippings/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // POST: Admin/Shippings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ShippingMethodID,ShippingPickupDate,isShipped,isArrived,ActualArrivalDate,EstimatedArrivalDate")] Shipping shipping)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipping).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shipping);
        }

        // GET: Admin/Shippings/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipping shipping = await db.Shippings.FindAsync(id);
            if (shipping == null)
            {
                return HttpNotFound();
            }
            return View(shipping);
        }

        // POST: Admin/Shippings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Shipping shipping = await db.Shippings.FindAsync(id);
            db.Shippings.Remove(shipping);
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
