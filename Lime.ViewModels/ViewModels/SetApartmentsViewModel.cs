using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.ViewModels.ViewModels
{
    public class SetApartmentsViewModel
    {
        public int Id { get; set; }
        public string FlatNumber { get; set; }
        public int ApartmentTypeId { get; set; }
        public double Price { get; set; }
        public int ApartmentSquare { get; set; }
        public int InternetProviderId { get; set; }
        public int DealTypeId { get; set; }
        public string Photo { get; set; }
    }
}
