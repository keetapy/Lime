using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Entities
{
    public class DealType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public DealType()
        {
            Apartments = new List<Apartment>();
        }
    }
}
