using System;
using System.Collections.Generic;

#nullable disable

namespace EmpleoAPI
{
    public partial class City
    {
        public City()
        {
            Sellers = new HashSet<Seller>();
        }

        public int Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Seller> Sellers { get; set; }
    }
}
