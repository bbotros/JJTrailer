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
    public class ImageManagersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ImageManagers
        public async Task<ActionResult> Index()
        {
            return View(await db.ImageManagers.ToListAsync());
        }

        // GET: Admin/ImageManagers/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageManager imageManager = await db.ImageManagers.FindAsync(id);
            if (imageManager == null)
            {
                return HttpNotFound();
            }
            return View(imageManager);
        }

        // GET: Admin/ImageManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ImageManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Path,MetaTagDescription")] ImageManager imageManager)
        {
            if (ModelState.IsValid)
            {
                imageManager.ID = Guid.NewGuid();
                db.ImageManagers.Add(imageManager);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(imageManager);
        }

        // GET: Admin/ImageManagers/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageManager imageManager = await db.ImageManagers.FindAsync(id);
            if (imageManager == null)
            {
                return HttpNotFound();
            }
            return View(imageManager);
        }

        // POST: Admin/ImageManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Path,MetaTagDescription")] ImageManager imageManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imageManager).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(imageManager);
        }

        // GET: Admin/ImageManagers/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImageManager imageManager = await db.ImageManagers.FindAsync(id);
            if (imageManager == null)
            {
                return HttpNotFound();
            }
            return View(imageManager);
        }

        // POST: Admin/ImageManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ImageManager imageManager = await db.ImageManagers.FindAsync(id);
            db.ImageManagers.Remove(imageManager);
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
