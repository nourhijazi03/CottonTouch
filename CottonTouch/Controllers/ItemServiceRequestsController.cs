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
    public class ItemServiceRequestsController : Controller
    {
        private CottonTouchDbEntities db = new CottonTouchDbEntities();

        // GET: ItemServiceRequests
        public ActionResult Index()
        {
            var itemServiceRequests = db.ItemServiceRequests.Include(i => i.Item).Include(i => i.ServiceRequest);
            return View(itemServiceRequests.ToList());
        }

        // GET: ItemServiceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemServiceRequest itemServiceRequest = db.ItemServiceRequests.Find(id);
            if (itemServiceRequest == null)
            {
                return HttpNotFound();
            }
            return View(itemServiceRequest);
        }

        // GET: ItemServiceRequests/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "DocumentAttached");
            return View();
        }

        // POST: ItemServiceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemServiceRequestID,ServiceRequestID,ItemID,QtnSentToLaundry,QtnRecievedAtLaundry,UnitPrice,VATPercent,VATAmount,DiscAmount,NetAmount,Date")] ItemServiceRequest itemServiceRequest)
        {
            if (ModelState.IsValid)
            {
                db.ItemServiceRequests.Add(itemServiceRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", itemServiceRequest.ItemID);
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "DocumentAttached", itemServiceRequest.ServiceRequestID);
            return View(itemServiceRequest);
        }

        // GET: ItemServiceRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemServiceRequest itemServiceRequest = db.ItemServiceRequests.Find(id);
            if (itemServiceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", itemServiceRequest.ItemID);
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "DocumentAttached", itemServiceRequest.ServiceRequestID);
            return View(itemServiceRequest);
        }

        // POST: ItemServiceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemServiceRequestID,ServiceRequestID,ItemID,QtnSentToLaundry,QtnRecievedAtLaundry,UnitPrice,VATPercent,VATAmount,DiscAmount,NetAmount,Date")] ItemServiceRequest itemServiceRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemServiceRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", itemServiceRequest.ItemID);
            ViewBag.ServiceRequestID = new SelectList(db.ServiceRequests, "ServiceRequestID", "DocumentAttached", itemServiceRequest.ServiceRequestID);
            return View(itemServiceRequest);
        }

        // GET: ItemServiceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemServiceRequest itemServiceRequest = db.ItemServiceRequests.Find(id);
            if (itemServiceRequest == null)
            {
                return HttpNotFound();
            }
            return View(itemServiceRequest);
        }

        // POST: ItemServiceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemServiceRequest itemServiceRequest = db.ItemServiceRequests.Find(id);
            db.ItemServiceRequests.Remove(itemServiceRequest);
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
