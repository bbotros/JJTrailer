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
    public class ShippingMethodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ShippingMethods
        public async Task<ActionResult> Index()
        {
            return View(await db.ShippingMethods.ToListAsync());
        }

        // GET: Admin/ShippingMethods/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = await db.ShippingMethods.FindAsync(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ShippingMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                shippingMethod.ID = Guid.NewGuid();
                db.ShippingMethods.Add(shippingMethod);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = await db.ShippingMethods.FindAsync(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: Admin/ShippingMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] ShippingMethod shippingMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingMethod).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shippingMethod);
        }

        // GET: Admin/ShippingMethods/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingMethod shippingMethod = await db.ShippingMethods.FindAsync(id);
            if (shippingMethod == null)
            {
                return HttpNotFound();
            }
            return View(shippingMethod);
        }

        // POST: Admin/ShippingMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ShippingMethod shippingMethod = await db.ShippingMethods.FindAsync(id);
            db.ShippingMethods.Remove(shippingMethod);
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
