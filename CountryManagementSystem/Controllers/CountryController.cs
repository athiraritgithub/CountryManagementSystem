using CountryManagementSystem.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CountryManagementSystem.Controllers
{
    public class CountryController : Controller
    {
        public ActionResult AllCountryDetails(CountryRequestModel countryViewRequest)
        {
            string countryJsonData = ApiCall(countryViewRequest.CallingCode);
            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(countryJsonData);
            List<CountryViewModel> model = new List<CountryViewModel>();
            CountryViewModel countryViewModel1;
            foreach (var country in countries)
            {
                countryViewModel1 = new CountryViewModel();
                countryViewModel1.Name = country.name;
                countryViewModel1.Subregion = country.subregion;
                countryViewModel1.Population = country.population;
                countryViewModel1.Borders = country.borders;
                countryViewModel1.Currencies = country.currencies;
                model.Add(countryViewModel1);
            }
            return View(model);
        }
        public static string ApiCall(string callingCode)
        {
            WebRequest request = WebRequest.Create($"https://restcountries.com/v2/all{callingCode}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}