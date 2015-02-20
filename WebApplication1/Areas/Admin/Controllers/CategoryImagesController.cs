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
    public class CategoryImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CategoryImages
        public async Task<ActionResult> Index()
        {
            return View(await db.CategoryImages.ToListAsync());
        }

        // GET: Admin/CategoryImages/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryImage categoryImage = await db.CategoryImages.FindAsync(id);
            if (categoryImage == null)
            {
                return HttpNotFound();
            }
            return View(categoryImage);
        }

        // GET: Admin/CategoryImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CategoryImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,CategoryID,ImageManagerID")] CategoryImage categoryImage)
        {
            if (ModelState.IsValid)
            {
                categoryImage.ID = Guid.NewGuid();
                db.CategoryImages.Add(categoryImage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoryImage);
        }

        // GET: Admin/CategoryImages/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryImage categoryImage = await db.CategoryImages.FindAsync(id);
            if (categoryImage == null)
            {
                return HttpNotFound();
            }
            return View(categoryImage);
        }

        // POST: Admin/CategoryImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,CategoryID,ImageManagerID")] CategoryImage categoryImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoryImage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoryImage);
        }

        // GET: Admin/CategoryImages/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryImage categoryImage = await db.CategoryImages.FindAsync(id);
            if (categoryImage == null)
            {
                return HttpNotFound();
            }
            return View(categoryImage);
        }

        // POST: Admin/CategoryImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            CategoryImage categoryImage = await db.CategoryImages.FindAsync(id);
            db.CategoryImages.Remove(categoryImage);
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
