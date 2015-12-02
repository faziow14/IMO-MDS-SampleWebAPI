using IMO_MDS_Sample_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMO_MDS_Sample_Web_API.Controllers
{
    public class ProblemController : ApiController
    {
        List<Problem> problems = new List<Problem>
       (
           new Problem[]
           {
                new Problem(1,"Senioritis"),
                new Problem(2, "Diabetic"),
                new Problem(3, "Colon Cancer"),
                new Problem(4, "Migrane")
           }
       );
​
        [HttpGet]
        // GET api/problem
        public IEnumerable<Problem> GetAllProblems()
        {
            return problems;
        }
​
        [HttpGet]
        // GET api/problem/1
        public IHttpActionResult GetProbem(int id)
        {
            var problem = problems.FirstOrDefault((p) => p.Id == id);
            if (problem == null)
            {
                return NotFound();
            }
            return Ok<Problem>(problem);
        }
​
        [HttpPost]
        // POST api/problem
        public IHttpActionResult PostProblem([FromBody]string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            int newId = problems.Count() + 1;
            problems.Add(new Problem(newId, name));
            return Ok("SUCCESS:  Added " + name + " (id " + newId + ")");
        }
​
        [HttpPut]
        // PUT api/problem/5
        public IHttpActionResult PutProblem(int id, [FromBody]string name)
        {
            int maxValidId = problems.Count();
            if (id <= 0 || name == null)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string oldName = problems[id].Name;
            problems[id].Name = name;
            return Ok("SUCCESS:  Updated '" + oldName + "' to '" + name + "' (id " + id + ")");
        }
​
        [HttpDelete]
        // DELETE api/problem/1
        public IHttpActionResult DeleteProblem(int id)
        {
            int maxValidId = problems.Count();
            if (id <= 0)
            {
                return BadRequest();
            }
            if (id > maxValidId)
            {
                return NotFound();
            }
            string problemName = problems[id].Name;
            problems.RemoveAt(id);
            return Ok("SUCCESS:  Deleted '" + problemName + "' (id " + id + ")");
        }
    }
}
