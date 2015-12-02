using IMO_MDS_Sample_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMO_MDS_Sample_Web_API.Controllers
{
    public class AllergyController : ApiController
    {
        List<Allergy> allergies = new List<Allergy>
       (
           new Allergy[]
           {
                new Allergy(1,"penut"),
                new Allergy(2, "egg"),
                new Allergy(3, "fish"),
                new Allergy(4, "pollen")
           }
       );
​
        [HttpGet]
        // GET api/allergy
        public IEnumerable<Allergy> GetAllAllergies()
        {
            return allergies;
        }
​
        [HttpGet]
        // GET api/allergy/1
        public IHttpActionResult GetAllergy(int id)
        {
            var allergy = allergies.FirstOrDefault((a) => a.Id == id);
            if (allergy == null)
            {
                return NotFound();
            }
            return Ok<Allergy>(allergy);
        }
​
        [HttpPost]
        // POST api/allergy
        public IHttpActionResult PostAllergy([FromBody]string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            int newId = allergies.Count() + 1;
            allergies.Add(new Allergy(newId, name));
            return Ok("SUCCESS:  Added " + name + " (id " + newId + ")");
        }
​
        [HttpPut]
        // PUT api/medication/5
        public IHttpActionResult PutAllergy(int id, [FromBody]string name)
        {
            int maxValidId = allergies.Count();
            if (id <= 0 || name == null)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string oldName = allergies[id].Name;
            allergies[id].Name = name;
            return Ok("SUCCESS:  Updated '" + oldName + "' to '" + name + "' (id " + id + ")");
        }
​
        [HttpDelete]
        // DELETE api/medication/1
        public IHttpActionResult DeleteAllergy(int id)
        {
            int maxValidId = allergies.Count();
            if (id <= 0)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string allergyName = allergies[id].Name;
            allergies.RemoveAt(id);
            return Ok("SUCCESS:  Deleted '" + allergyName + "' (id " + id + ")");
        }
    }
}
