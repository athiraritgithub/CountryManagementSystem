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
        [HttpPost]
        public ActionResult AllCountryDetails(CountryRequestModel countryViewRequest)
        {
            string countryJsonData = ApiCall(countryViewRequest.CallingCode);
            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(countryJsonData);

            CountryViewModel countryViewModel= new CountryViewModel();
            countryViewModel.Name = countries[0].name;
            countryViewModel.Subregion= countries[0].subregion;
            countryViewModel.Population= countries[0].population;
            countryViewModel.Borders= countries[0].borders;
            countryViewModel.Currencies= countries[0].currencies;
            //countryViewModel.Currencies = countries[0].currencies;
            return View(countryViewModel);
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