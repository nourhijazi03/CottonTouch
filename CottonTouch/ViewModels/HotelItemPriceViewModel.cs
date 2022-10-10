using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.ViewModels
{
    public class HotelItemPriceViewModel
    {
        public int HIPID { get; set; }
        public Nullable<int> HotelID { get; set; }
        public Nullable<int> ItemID { get; set; }
        public Nullable<double> PricePerItem { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Item Item { get; set; }
    }
}