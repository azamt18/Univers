using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace WebApplicationSwagger.Controllers
{
    public class UniversityController : ApiController
    {
        // GET: api/University
        // Test commit
        [HttpGet]
        [Route("Api/University/GetUniversities")]
        public IHttpActionResult Get()
        {
            string allText = System.IO.File.ReadAllText(@"f:\IT\CSharp\WebApplicationSwagger\universities.json");

            var jsonObject = JsonConvert.DeserializeObject(allText) as JArray;

            return Json(jsonObject.Select(x =>
            {
                return new
                {
                    regionName = x["G1"].Value<string>(),
                    departmentalSubordinationUzb = x["G2"].Value<string>(),
                    filialType = x["G3"].Value<string>(),
                    filialName = x["G4"].Value<string>(),
                    fullNameRu = x["G5"].Value<string>(),
                    abbreviateName = x["G6"].Value<string>(),
                    address = x["G7"].Value<string>(),
                    telephoneCode = x["G8"].Value<string>(),
                    telephoneNumber = x["G9"].Value<string>(),
                    mail = x["G10"].Value<string>(),
                    website = x["G11"].Value<string>(),
                    director = x["G12"].Value<string>(),
                };
            }
            ));
        }

        // GET: api/University/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/University
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/University/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/University/5
        public void Delete(int id)
        {
        }

        public void LoadJson()
        {
            using (StreamReader reader = new StreamReader("universities.json"))
            {
                string json = reader.ReadToEnd();
                List<University> items = JsonConvert.DeserializeObject<List<University>>(json);
            }
        }

        public class University
        {
            public string regionName;
            public string departmentalSubordinationUzb;
            public string filialType;
            public string fullNameUzb;
            public string fullNameRu;
            public string abbreviatedName;
            public string address;
            public int telephoneCode;
            public int telephoneNumber;
            public string mail;
            public string website;
            public string director;
        }

    }
}
