using IMO_MDS_Sample_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMO_MDS_Sample_Web_API.Controllers
{
    public class PatientController : ApiController
    {
        List<Patient> patients = new List<Patient>
        (
            new Patient[]
            {
                new Patient(1, "Mike", 18, "Male", "1234567896"),
                new Patient(2, "Sarah", 20, "Female", "3126547986"),
                new Patient(3, "John", 30, "Male", "9874563652"),
                new Patient(4, "Michelle", 60, "Female", "4561257894")
            }
        );

        /* patients[0].addMedication(new Medication());
        patients[0].addAllergy("Egg");
        patients[0].addProblem("Cough");
​
        patients[1].addMedication("Viagra");
        patients[1].addAllergy("Nuts");
        patients[1].addProblem("Flu");
​
        patients[2].addMedication("Pygeum");
        patients[2].addAllergy("Corn");
        patients[2].addProblem("headache");
​
        patients[3].addMedication("Prevacid");
        patients[3].addAllergy("Sugar");
        patients[3].addProblem("Stomach"); */

        [HttpGet]
        // GET api/patient
        public IEnumerable<Patient> GetAllPatients()
        {
            return patients;
        }

        [HttpGet]
        // GET api/patient/1
        public IHttpActionResult GetPatient(string _name)
        {
            var patient = patients.FirstOrDefault((p) => p.Name.Equals(_name));
            if (patient == null)
            {
                return NotFound();
            }
            return Ok<Patient>(patient);
        }

        [HttpPost]
        // POST api/patient
        public IHttpActionResult PostPatient([FromBody]string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            int newId = patients.Count() + 1;
            patients.Add(new Patient(newId, name, 0, null, null));
            return Ok("SUCCESS:  Added " + name + " (id " + newId + ")");
        }

        [HttpPut]
        // PUT api/patient/5
        public IHttpActionResult PutAllergy(int id, [FromBody]string name)
        {
            int maxValidId = patients.Count();
            if (id <= 0 || name == null)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string oldName = patients[id].Name;
            patients[id].Name = name;
            return Ok("SUCCESS:  Updated '" + oldName + "' to '" + name + "' (id " + id + ")");
        }

        [HttpDelete]
        // DELETE api/medication/1
        public IHttpActionResult DeleteAllergy(int id)
        {
            int maxValidId = patients.Count();
            if (id <= 0)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string patientName = patients[id].Name;
            patients.RemoveAt(id);
            return Ok("SUCCESS:  Deleted '" + patientName + "' (id " + id + ")");
        }
    }
}
