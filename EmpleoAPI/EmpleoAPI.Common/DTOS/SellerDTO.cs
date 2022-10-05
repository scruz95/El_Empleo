using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleoAPI.Common.DTOS
{
    public class SellerDTO
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public int CityId { get; set; }
    }
}
