//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CottonTouch
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ServiceRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceRequest()
        {
            this.Invoices = new HashSet<Invoice>();
            this.ItemServiceRequests = new HashSet<ItemServiceRequest>();
        }
    
        public int ServiceRequestID { get; set; }
        public Nullable<int> HotelID { get; set; }
        public Nullable<int> TotalSentItems { get; set; }
        public Nullable<int> TotalRecievedItems { get; set; }
        public bool ClientSignature { get; set; }
        public bool LaundrySignature { get; set; }
        public string DocumentAttached { get; set; }
        public Nullable<double> TotalPrice { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemServiceRequest> ItemServiceRequests { get; set; }
        public virtual Hotel Hotel { get; set; }
        [NotMapped]
        public List<ItemServiceRequest> IRSList { get; set; }

        [NotMapped]
        public List<ItemServiceRequest> IRSListInvoice { get; set; }
        [NotMapped]

        public Nullable<int> ItemID { get; set; }
        [NotMapped]

        public virtual Item Item { get; set; }

        [NotMapped]
        public int ItemQtn { get; set; }

        [NotMapped]
        public string ItemQtnstring { get; set; }
    }
}
