using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryManagementSystem.Models
{
    public class CountryViewModel
    {
        public string Name { get; set; }
        public string Subregion { get; set; }
        public int Population { get; set; }
        public string[] Borders { get; set; }
        public List<Currency> Currencies { get; set; }
     }
    
}
