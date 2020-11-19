using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Entities
{
    public class RentalDeal
    {
        public int Id { get; set; }
        public DateTime TermFrom { get; set; }
        public DateTime? TermTo { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
