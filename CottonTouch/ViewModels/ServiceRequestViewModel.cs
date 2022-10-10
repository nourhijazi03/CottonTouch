using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.ViewModels
{
    public class ServiceRequestViewModel
    {
        public int ServiceRequestID { get; set; }
        public Nullable<int> HotelID { get; set; }
        public Nullable<int> TotalSentItems { get; set; }
        public Nullable<int> TotalRecievedItems { get; set; }
        public bool ClientSignature { get; set; }
        public bool LaundrySignature { get; set; }
        public string DocumentAttached { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public virtual Hotel Hotel { get; set; }



        // items service request



    }
}