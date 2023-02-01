using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryManagementSystem.Models
{
    public class Country
    {
        public string name { get; set; }
        public string subregion { get; set; }
        public int population { get; set; }
        public string[] borders { get; set; }
        public List<Currency> currencies { get; set; }
    }
    public class Currency
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }
}