using IMO_MDS_Sample_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMO_MDS_Sample_Web_API.Controllers
{
    public class MedicationController : ApiController
    {
        List<Medication> medications = new List<Medication>
        (
            new Medication[]
            {
                new Medication(1, "Advil"),
                new Medication(2, "Penicillin"),
                new Medication(3, "Vicodin"),
                new Medication(4, "Viagra")
            }
        );
        
        [HttpGet]
        // GET api/medication
        public IEnumerable<Medication> GetAllMedications()
        {
            return medications;
        }

        [HttpGet]
        // GET api/medication/1
        public IHttpActionResult GetMedication(int id)
        {
            var medication = medications.FirstOrDefault((m) => m.Id == id);
            if (medication == null)
            {
                return NotFound();
            }
            return Ok<Medication>(medication);
        }

        [HttpPost]
        // POST api/medication
        public IHttpActionResult PostMedication([FromBody]string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            int newId = medications.Count() + 1;
            medications.Add(new Medication(newId, name));
            return Ok("SUCCESS:  Added " + name + " (id " + newId + ")");
        }

        [HttpPut]
        // PUT api/medication/5
        public IHttpActionResult PutMedication(int id, [FromBody]string name)
        {
            int maxValidId = medications.Count();
            if (id <= 0 || name == null)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string oldName = medications[id].Name;
            medications[id].Name = name;
            return Ok("SUCCESS:  Updated '" + oldName + "' to '" + name + "' (id " + id + ")");
        }

        [HttpDelete]
        // DELETE api/medication/1
        public IHttpActionResult DeleteMedication(int id)
        {
            int maxValidId = medications.Count();
            if (id <= 0)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string medicationName = medications[id].Name;
            medications.RemoveAt(id);
            return Ok("SUCCESS:  Deleted '" + medicationName + "' (id " + id + ")");
        }

    }
}
