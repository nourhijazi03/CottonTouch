using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CottonTouch.Controllers
{
    public class HomeController : Controller
    {
        CottonTouchDbEntities db = null;
        public ActionResult Index()
        {
            double totalcomingcash = 0;
            int hotelsnumber = 0;

            List<ServiceRequest> listofsr = null;
            using (db = new CottonTouchDbEntities()) {
                var xtotalcomingcash = db.ServiceRequests.ToList();
                if (xtotalcomingcash.Count != 0)
                {
                    totalcomingcash = xtotalcomingcash.Sum(d => d.TotalPrice).Value;
                }
                else {
                    totalcomingcash= 0;
                }
                var xhotelsnumber = db.Hotels.ToList();
                    if (xhotelsnumber.Count != 0) {
                    hotelsnumber = xhotelsnumber.Count();
                        } else {
                    hotelsnumber = 0;
                }
                    


                listofsr = new List<ServiceRequest>();
                var xlistofsr = db.ServiceRequests.ToList();
                if (xlistofsr.Count != 0) {
                    listofsr = xlistofsr.OrderByDescending(x => x.Date).Take(5).ToList();

                }
                else
                {
                    listofsr = null;

                }

            }

            ViewBag.totalcomingcash = totalcomingcash;
            ViewBag.hotelsnumber = hotelsnumber;
            ViewBag.listofsr = listofsr;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Invoice() {
            return View();
        }
    }
}