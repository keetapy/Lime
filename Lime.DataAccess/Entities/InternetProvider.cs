using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Entities
{
    public class InternetProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }
        public InternetProvider()
        {
            Apartments = new List<Apartment>();
        }
    }
}
