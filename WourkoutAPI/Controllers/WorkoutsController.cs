using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WourkoutAPI.Controllers
{
    [Route("api/User/{userId}/[controller]")]
    [ApiController]
    public class WorkoutsController : ControllerBase
    {
        // GET: api/User/Workouts/PredefinedWorkouts
        // Getting predefined workouts
        [Authorize]
        [HttpGet("[action]")]
        public IEnumerable<string> PredefinedWorkouts()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/1/Workouts
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/User/1/Workouts/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User/1/Workouts
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT: api/User/1/Workouts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/User/1/Workouts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
