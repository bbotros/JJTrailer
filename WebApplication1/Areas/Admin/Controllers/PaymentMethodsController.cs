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
    public class PaymentMethodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/PaymentMethods
        public async Task<ActionResult> Index()
        {
            return View(await db.PaymentMethods.ToListAsync());
        }

        // GET: Admin/PaymentMethods/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = await db.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // GET: Admin/PaymentMethods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PaymentMethods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                paymentMethod.ID = Guid.NewGuid();
                db.PaymentMethods.Add(paymentMethod);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(paymentMethod);
        }

        // GET: Admin/PaymentMethods/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = await db.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: Admin/PaymentMethods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name")] PaymentMethod paymentMethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentMethod).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paymentMethod);
        }

        // GET: Admin/PaymentMethods/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMethod paymentMethod = await db.PaymentMethods.FindAsync(id);
            if (paymentMethod == null)
            {
                return HttpNotFound();
            }
            return View(paymentMethod);
        }

        // POST: Admin/PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PaymentMethod paymentMethod = await db.PaymentMethods.FindAsync(id);
            db.PaymentMethods.Remove(paymentMethod);
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
