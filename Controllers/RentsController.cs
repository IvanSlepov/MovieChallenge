using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RentsController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Rents
        public async Task<ActionResult> Index()
        {
            var rents = await db.Rents.ToListAsync();
            return View(rents);
        }

        // GET: Rents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = await db.Rents.FindAsync(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // GET: Rents/Create
        public async Task<ActionResult> Create()
        {
            var users = await db.Users.ToListAsync();
            ViewBag.Users = users;

            var movies = await db.Movies.ToListAsync();
            ViewBag.Movies = movies;

            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RentID,UserID,MovieID,From,To")] Rent rent)
        {
            DateTime today = DateTime.Today;
            bool isActiveRent = await db.Rents.AnyAsync(r => r.To > DateTime.Now);
  
            //This block is responsible for checking whether a User has an active rent also it's putting a restriction to make a rent for other user
            //in case that movie is still in usage

            if (isActiveRent)
            {
                return ActionResult();
            }

            //This block is responsible for not letting make a rent in the past
            if (rent.From < today || rent.To < today)
            {
                return ActionResult();
            }

            //This block is responsible for checking a "To" date is not less than "From" date
            if (rent.To < rent.From)
            {
                return ActionResult();
            }

            if (ModelState.IsValid)
            {
                db.Rents.Add(rent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            var users = await db.Users.ToListAsync();
            ViewBag.Users = users;

            var movies = await db.Movies.ToListAsync();
            ViewBag.Movies = movies;

            return View(rent);
        }

        private ActionResult ActionResult()
        {
            throw new NotImplementedException();
        }

        // GET: Rents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = await db.Rents.FindAsync(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RentID,UserID,MovieID,From,To")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rent);
        }

        // GET: Rents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = await db.Rents.FindAsync(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rent rent = await db.Rents.FindAsync(id);
            db.Rents.Remove(rent);
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
