using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CottonTouch;

namespace CottonTouch.Controllers
{
    public class HotelItemPricesController : Controller
    {
        private CottonTouchDbEntities db = new CottonTouchDbEntities();

        // GET: HotelItemPrices
        public ActionResult Index()
        {
            var hotelItemPrices = db.HotelItemPrices.Include(h => h.Hotel).Include(h => h.Item);
            return View(hotelItemPrices.ToList());
        }

        // GET: HotelItemPrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelItemPrice hotelItemPrice = db.HotelItemPrices.Find(id);
            if (hotelItemPrice == null)
            {
                return HttpNotFound();
            }
            return View(hotelItemPrice);
        }

        // GET: HotelItemPrices/Create
        public ActionResult Create()
        {
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            return View();
        }

        // POST: HotelItemPrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HIPID,HotelID,ItemID,PricePerItem,VATPercent,VATAmount,DiscAmount")] HotelItemPrice hotelItemPrice)
        {
            if (ModelState.IsValid)
            {
                db.HotelItemPrices.Add(hotelItemPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", hotelItemPrice.HotelID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", hotelItemPrice.ItemID);
            return View(hotelItemPrice);
        }

        // GET: HotelItemPrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelItemPrice hotelItemPrice = db.HotelItemPrices.Find(id);
            if (hotelItemPrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", hotelItemPrice.HotelID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", hotelItemPrice.ItemID);
            return View(hotelItemPrice);
        }

        // POST: HotelItemPrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HIPID,HotelID,ItemID,PricePerItem,VATPercent,VATAmount,DiscAmount")] HotelItemPrice hotelItemPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelItemPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", hotelItemPrice.HotelID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", hotelItemPrice.ItemID);
            return View(hotelItemPrice);
        }

        // GET: HotelItemPrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelItemPrice hotelItemPrice = db.HotelItemPrices.Find(id);
            if (hotelItemPrice == null)
            {
                return HttpNotFound();
            }
            return View(hotelItemPrice);
        }

        // POST: HotelItemPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HotelItemPrice hotelItemPrice = db.HotelItemPrices.Find(id);
            db.HotelItemPrices.Remove(hotelItemPrice);
            db.SaveChanges();
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
