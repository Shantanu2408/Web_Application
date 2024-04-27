using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assign._1.Models;

namespace Assign._1
{
    public class CountryController : ApiController
    {

        static List<Country> C_Data = new List<Country>()
        {
            new Country { Id = 1, Country_Name=  "China",  Capital = "Beejing" },
            new Country { Id = 2, Country_Name = "India", Capital= "Delhi" },
            new Country { Id = 3, Country_Name = "U.K",   Capital= "London" },
            new Country { Id = 4, Country_Name = "Japan", Capital= "Tokyo" }


        };

        //Get Operation
        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            return Ok(C_Data);
        }


        //Post Operation
        [HttpPost]
        public List<Country> PostCountry([FromBody] Country country)
        {
            C_Data.Add(country);
            return C_Data;

        }


        //PUT Operation
        [HttpPut]
        public IHttpActionResult PutCountry(int id, Country country)
        {
            var ExCountry= C_Data.FirstOrDefault(cd => cd.Id== id);
            if (ExCountry == null)
                return NotFound();

            ExCountry.Country_Name = country.Country_Name;
            ExCountry.Capital = country.Capital;
            return Ok(ExCountry);
        }

        //Delete Operation
        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var Del_Country = C_Data.FirstOrDefault(cd => cd.Id == id);
            if (Del_Country == null)
                return NotFound();

            C_Data.Remove(Del_Country);
            return Ok(Del_Country);
        }

    }
}
