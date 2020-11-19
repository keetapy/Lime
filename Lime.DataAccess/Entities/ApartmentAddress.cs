using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lime.DataAccess.Entities
{
    public class ApartmentAddress
    {
        [Key]
        [ForeignKey("Apartment")]
        public int Id { get; set; }
        public virtual Apartment Apartment { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
    }
}
