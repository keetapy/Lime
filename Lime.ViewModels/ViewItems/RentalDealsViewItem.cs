using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.ViewModels.ViewItems
{
    public class RentalDealsViewItem
    {
        public DateTime TermFrom { get; set; }
        public DateTime? TermTo { get; set; }
        public ClientViewItem Client { get; set; }
    }
}
