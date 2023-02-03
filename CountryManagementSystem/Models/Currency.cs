using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryManagementSystem.Models
{
    public class Currency
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        //public override string ToString()
        //{
        //    return code + " - " + name + " - " + symbol;
        //}
    }
}