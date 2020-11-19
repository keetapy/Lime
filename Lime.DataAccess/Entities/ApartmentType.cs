using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Entities
{
    public class ApartmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public ApartmentType()
        {
            Apartments = new List<Apartment>();
        }
    }
}
