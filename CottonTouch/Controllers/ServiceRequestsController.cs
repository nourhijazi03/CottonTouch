using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CottonTouch;

namespace CottonTouch.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private CottonTouchDbEntities db = new CottonTouchDbEntities();

        // GET: ServiceRequests
        public ActionResult Index()
        {
            var serviceRequests = db.ServiceRequests.Include(s => s.Hotel);
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name");
            return View(serviceRequests.ToList());
        }

        // GET: ServiceRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Create
        public ActionResult Create()
        {
            
              ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name");
            //ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name");
            
            ServiceRequest srlist = null;
            srlist = new ServiceRequest();
            //ViewBag.ItemID =   new SelectList(db.Items, "ItemID", "Name");
            ViewBag.ItemID = db.Items.ToList();

            List<ItemServiceRequest> IRSList = null;
            IRSList = new List<ItemServiceRequest>();

            using (db = new CottonTouchDbEntities())
            {
                srlist.IRSList = db.ItemServiceRequests.Where(y => y.ServiceRequestID == srlist.ServiceRequestID).ToList();
           
            return View(srlist);
            }
        }

        // POST: ServiceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "ServiceRequestID,HotelID,TotalSentItems,TotalRecievedItems,ClientSignature,LaundrySignature,DocumentAttached,TotalPrice,ItemQtnstring")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                ItemServiceRequest ISP = null;
                List<ItemServiceRequest> ISPlist = null;

                ISP = new ItemServiceRequest();
                ISPlist = new List<ItemServiceRequest>();


                using (db = new CottonTouchDbEntities())
                {

                    serviceRequest.Date = DateTime.Now;
                    db.ServiceRequests.Add(serviceRequest);
                    db.SaveChanges();
                    
                    ISPlist= StringToISRObject(serviceRequest.ItemQtnstring, serviceRequest);
                    double totalPrice = 0;
                    for (int i = 0; i< ISPlist.Count;i++) {
                        totalPrice += (double)ISPlist[i].NetAmount;
                        
                        db.ItemServiceRequests.Add(ISPlist[i]);
                        db.SaveChanges();
                    }

                    serviceRequest.TotalPrice = totalPrice;
                    db.Entry(serviceRequest).State = EntityState.Modified;
                    db.SaveChanges();
                }



                return RedirectToAction("Index");
            }

            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);
            return View(serviceRequest);
        }


        // GET: ServiceRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceRequestID,HotelID,TotalSentItems,TotalRecievedItems,ClientSignature,LaundrySignature,DocumentAttached,TotalPrice")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            List<ItemServiceRequest> isrlist = db.ItemServiceRequests.Where(k => k.ServiceRequestID == id).ToList();
            db.ItemServiceRequests.RemoveRange(isrlist);
            db.SaveChanges();
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            db.ServiceRequests.Remove(serviceRequest);
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


        // GET: ServiceRequests/Edit/5
        public ActionResult GenerateDeliveryNote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);
            return View(serviceRequest);
        }


        private List<ItemServiceRequest> StringToISRObject(string str, ServiceRequest serviceRequest)
        {
           
            List<string> ListofItemsQtn = null;
            ListofItemsQtn = new List<string>();
            ListofItemsQtn = str.Split(',').ToList<string>();

            ItemServiceRequest isr = null;
            List<ItemServiceRequest> isrlist = null;
            isrlist = new List<ItemServiceRequest>();

            for (int i = 0; i < ListofItemsQtn.Count; i++) {
                isr = new ItemServiceRequest();
                int itemid = int.Parse(ListofItemsQtn[i]);
                var item = db.Items.Where(s => s.ItemID == itemid).FirstOrDefault();
                var hotel = db.Hotels.Where(f => f.HotelID == serviceRequest.HotelID).FirstOrDefault();
                var hotelitemprice = db.HotelItemPrices.Where(f => f.ItemID== itemid && f.HotelID == serviceRequest.HotelID ).FirstOrDefault();
               
                isr.ItemID = (int?) item.ItemID;
                isr.ServiceRequestID = serviceRequest.ServiceRequestID;
                isr.QtnSentToLaundry = int.Parse(ListofItemsQtn[i + 1]);
                isr.QtnRecievedAtLaundry = int.Parse(ListofItemsQtn[i + 1]);

                if (hotelitemprice == null)
                {
                    isr.UnitPrice = item.UnitPrice; 
                }
                else
                {
                    isr.UnitPrice = hotelitemprice.PricePerItem;
                    isr.VATAmount = hotelitemprice.VATAmount;
                    isr.VATPercent = hotelitemprice.VATPercent;
                    isr.DiscAmount = hotelitemprice.DiscAmount;
                }
                isr.Date = DateTime.Now;
                isr.NetAmount = isr.UnitPrice * isr.QtnSentToLaundry;

                isrlist.Add(isr);
                i += 1;
            }
            return isrlist;
        }

        public ActionResult DeliveryNote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);
            return View(serviceRequest);
        }


        [HttpGet]
        public ActionResult DeliveryNoteInvoice(string hotelid = "", string from= "", string  to="")
        {
            ViewBag.hotelidstring = hotelid;
            ViewBag.fromstring    = from;
            ViewBag.tostring      = to;


            List<string> todatelst = to.Split(',').ToList<string>();
            List<string> fromdatelst = from.Split(',').ToList<string>();
            DateTime? todate = new DateTime(int.Parse(todatelst[2]), int.Parse(todatelst[0]), int.Parse(todatelst[1]));
            DateTime? fromdate = new DateTime(int.Parse(fromdatelst[2]), int.Parse(fromdatelst[0]), int.Parse(fromdatelst[1]));
            int? hotelids = int.Parse(hotelid);
            SqlDateTime? end = todate;
            SqlDateTime? start = fromdate;

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            List<ServiceRequest> srlist = null;
            srlist = new List<ServiceRequest>();
            List<ItemServiceRequest> _isrlist = null;
            _isrlist = new List<ItemServiceRequest>();
            srlist = db.ServiceRequests.Where(entry => entry.Date >= fromdate && entry.Date <= todate && entry.HotelID == hotelids).ToList();
            string srids = "";
            for (int i = 0; i < srlist.Count; i++) {
                List<ItemServiceRequest> _resultlist = null;
                _resultlist = new List<ItemServiceRequest>();
                srids += srlist[i].ServiceRequestID.ToString()+"-";

                _resultlist =     getDNInvoiceDetails(srlist[i].ServiceRequestID);
                _isrlist.AddRange(_resultlist);
            }
            srids= srids.TrimEnd('-');
            List<ItemServiceRequest> result = _isrlist.GroupBy(d => d.ItemID)
    .Select(
        g => new ItemServiceRequest
        { ServiceRequestID=g.Key,
            ItemID = g.First().ItemID,
            QtnRecievedAtLaundry= g.Sum(s => s.QtnRecievedAtLaundry),
            QtnSentToLaundry= g.Sum(s => s.QtnSentToLaundry),
            DiscAmount = g.First().DiscAmount,
            VATPercent = g.First().VATPercent,
            VATAmount = g.Sum(s => s.VATAmount),
            NetAmount = g.Sum(s => s.NetAmount),
            UnitPrice = g.First().UnitPrice,
            Date = g.First().Date,
        }).ToList();

            double? TotalNetAmount = 0;
            double? TotalTaxAmount = 0;
            double? InvoiceTotal   = 0;

            for (int i = 0; i < result.Count; i++) {
                TotalNetAmount += result[i].NetAmount;
                TotalTaxAmount += result[i].VATAmount * result[i].QtnSentToLaundry;
            }
            InvoiceTotal = TotalNetAmount + TotalTaxAmount;

            //if (serviceRequest == null)
            //{
            //    return HttpNotFound();
            //}
            Hotel _hotel = null;
            _hotel = new Hotel();
            _hotel = db.Hotels.Where(a => a.HotelID == hotelids).FirstOrDefault();

            ViewBag.FromDate = from.ToString();
            ViewBag.ToDate = to.ToString();
            ViewBag.IRSListInvoice = result;
            ViewBag.Hotel = _hotel;
            ViewBag.ListSRids = srids;
            ViewBag.TotalNetAmount = TotalNetAmount;
            ViewBag.TotalTaxAmount = TotalTaxAmount;
            ViewBag.InvoiceTotal   = InvoiceTotal;
            

            //ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);

            return View();
        }


        private List<ItemServiceRequest> getDNInvoiceDetails(int? id)
        {

            List<ItemServiceRequest> _ISRlist = null;
            ItemServiceRequest _ISR = null;

            _ISRlist = new List<ItemServiceRequest>();         
            _ISR = new  ItemServiceRequest();
            _ISRlist = db.ItemServiceRequests.Where(u => u.ServiceRequestID == id).ToList();


            return _ISRlist;

        }
        public ActionResult Print(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);
            return View(serviceRequest);
        }
        public ActionResult PrintInvoice(string hotelid = "", string from = "", string to = "")
        {
            List<string> todatelst = to.Split(',').ToList<string>();
            List<string> fromdatelst = from.Split(',').ToList<string>();
            DateTime? todate = new DateTime(int.Parse(todatelst[2]), int.Parse(todatelst[0]), int.Parse(todatelst[1]));
            DateTime? fromdate = new DateTime(int.Parse(fromdatelst[2]), int.Parse(fromdatelst[0]), int.Parse(fromdatelst[1]));
            int? hotelids = int.Parse(hotelid);
            SqlDateTime? end = todate;
            SqlDateTime? start = fromdate;

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            List<ServiceRequest> srlist = null;
            srlist = new List<ServiceRequest>();
            List<ItemServiceRequest> _isrlist = null;
            _isrlist = new List<ItemServiceRequest>();
            srlist = db.ServiceRequests.Where(entry => entry.Date >= fromdate && entry.Date <= todate && entry.HotelID == hotelids).ToList();
            string srids = "";
            for (int i = 0; i < srlist.Count; i++)
            {
                List<ItemServiceRequest> _resultlist = null;
                _resultlist = new List<ItemServiceRequest>();
                srids += srlist[i].ServiceRequestID.ToString() + "-";

                _resultlist = getDNInvoiceDetails(srlist[i].ServiceRequestID);
                _isrlist.AddRange(_resultlist);
            }
            srids = srids.TrimEnd('-');
            List<ItemServiceRequest> result = _isrlist.GroupBy(d => d.ItemID)
    .Select(
        g => new ItemServiceRequest
        {
            ServiceRequestID = g.Key,
            ItemID = g.First().ItemID,
            QtnRecievedAtLaundry = g.Sum(s => s.QtnRecievedAtLaundry),
            QtnSentToLaundry = g.Sum(s => s.QtnSentToLaundry),
            DiscAmount = g.First().DiscAmount,
            VATPercent = g.First().VATPercent,
            VATAmount = g.Sum(s => s.VATAmount),
            NetAmount = g.Sum(s => s.NetAmount),
            UnitPrice = g.First().UnitPrice,
            Date = g.First().Date,
        }).ToList();

            double? TotalNetAmount = 0;
            double? TotalTaxAmount = 0;
            double? InvoiceTotal = 0;

            for (int i = 0; i < result.Count; i++)
            {
                TotalNetAmount += result[i].NetAmount;
                TotalTaxAmount += result[i].VATAmount * result[i].QtnSentToLaundry;
            }
            InvoiceTotal = TotalNetAmount + TotalTaxAmount;

            //if (serviceRequest == null)
            //{
            //    return HttpNotFound();
            //}
            Hotel _hotel = null;
            _hotel = new Hotel();
            _hotel = db.Hotels.Where(a => a.HotelID == hotelids).FirstOrDefault();

            ViewBag.FromDate = from.ToString();
            ViewBag.ToDate = to.ToString();
            ViewBag.IRSListInvoice = result;
            ViewBag.Hotel = _hotel;
            ViewBag.ListSRids = srids;
            ViewBag.TotalNetAmount = TotalNetAmount;
            ViewBag.TotalTaxAmount = TotalTaxAmount;
            ViewBag.InvoiceTotal = InvoiceTotal;

            //ViewBag.HotelID = new SelectList(db.Hotels, "HotelID", "Name", serviceRequest.HotelID);

            return View();
        }

    }
}