using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.ViewModels
{
    public class InvoiceViewModel
    {
        public int InvoiceID { get; set; }
        public Nullable<int> HotelID { get; set; }
        public Nullable<int> ServiceRequestID { get; set; }
        public Nullable<double> TotalDiscount { get; set; }
        public Nullable<double> TotalNetAmount { get; set; }
        public Nullable<double> CarriageNet { get; set; }
        public Nullable<double> TotalTaxAmount { get; set; }
        public Nullable<double> InvoiceTotal { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<System.DateTime> Date { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }

    }
}