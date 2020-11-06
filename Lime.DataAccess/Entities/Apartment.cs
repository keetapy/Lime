using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lime.DataAccess.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int? ApartmentsAddressId { get; set; }
        public int? ApartmentTypeId { get; set; }
        public string FlatNumber { get; set; }
        public int ApartmentSquare { get; set; }
        public string Photo { get; set; }
        public int? InternetProviderId { get; set; }
        public int? DealTypeId { get; set; }

    }
}
