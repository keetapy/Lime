using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lime.DataAccess.Entities
{
    public class Apartment
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual ApartmentAddress ApartmentAddress { get; set; }
        public int? ApartmentTypeId { get; set; }
        public virtual ApartmentType ApartmentType { get; set; }
        public string FlatNumber { get; set; }
        public double Price { get; set; }
        public int ApartmentSquare { get; set; }
        public string Photo { get; set; }
        public int? InternetProviderId { get; set; }
        public virtual InternetProvider InternetProvider { get; set; }
        public int? DealTypeId { get; set; }
        public virtual DealType DealType { get; set; }
        public virtual ICollection<Amenities> Amenities { get; set; }
        public virtual ICollection<RentalDeal> RentalDeals { get; set; }
        public Apartment()
        {
            Amenities = new List<Amenities>();
            RentalDeals = new List<RentalDeal>(); 

        }

    }
}
