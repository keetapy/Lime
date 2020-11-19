using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<RentalDeal> RentalDeals { get; set; }
        public Client()
        {
            RentalDeals = new List<RentalDeal>();
        }
    }
}
