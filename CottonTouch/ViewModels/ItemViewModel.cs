using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.ViewModels
{
    public class ItemViewModel
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
    }
}