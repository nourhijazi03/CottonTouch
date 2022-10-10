using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.ViewModels
{
    public class ItemServiceRequestViewModel
    {
        public int ItemServiceRequestID { get; set; }
        public Nullable<int> ServiceRequestID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<int> QtnSentToLaundry { get; set; }
        public Nullable<int> QtnRecievedAtLaundry { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<double> VATPercent { get; set; }
        public Nullable<double> VATAmount { get; set; }
        public Nullable<double> DiscAmount { get; set; }
        public Nullable<double> NetAmount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public virtual Item Item { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}