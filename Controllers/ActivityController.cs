using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Database;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        
        //Create : POST
        //Read : GET
        //Update : PUT
        //Delete : DELETE


        // GET: api/activity
        [HttpGet]
        public IEnumerable<Activity> Get() 
        {
            GetActivity myActivitys = new GetActivity();
            return myActivitys.GetAllActivities();
        }

        // GET: api/activity/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            return "value";
        }

        // POST: api/activity
        [HttpPost]
        public void Post([FromBody] Activity value)
        {
            SaveActivity myActivity = new SaveActivity();
            Console.WriteLine(value);
            myActivity.CreateActivity(value);
        }

        // PUT: api/activity
        [HttpPut("{id}")]
       public IActionResult Put([FromBody] Activity value)
        {
            if (!ModelState.IsValid)
            {
                // Log each error in the ModelState
                foreach (var modelStateKey in ModelState.Keys)
                {
                    var modelStateVal = ModelState[modelStateKey];
                    foreach (var error in modelStateVal.Errors)
                    {
                        Console.WriteLine($"Error in field {modelStateKey}: {error.ErrorMessage}");
                    }
                }

                // Return a BadRequest response with the ModelState errors
                return BadRequest(ModelState);
            }

            // If model state is valid, proceed with the update
            EditActivity myActivitys = new EditActivity();
            myActivitys.Edit(value);

            // You might want to return some sort of response here
            // For example, a success message or the updated object
            return Ok();
        }


        // DELETE: api/activity
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            DeleteActivity myActivitys = new DeleteActivity();
            myActivitys.Delete(id);
        }
    }
}