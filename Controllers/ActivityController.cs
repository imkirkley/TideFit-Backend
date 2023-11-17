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

       
        [HttpGet]
        public IEnumerable<Activity> Get() 
        {
            GetActivity myActivitys = new GetActivity();
            return myActivitys.GetAllActivities();
        }

        
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            return "value";
        }

        
        [HttpPost]
        public void Post([FromBody] Activity value)
        {
            SaveActivity myActivity = new SaveActivity();
            myActivity.CreateActivity(value);
        }

       
        [HttpPut("{id}")]
       public void Put([FromBody] Activity value)
        {
           
            EditActivity myActivitys = new EditActivity();
            myActivitys.Edit(value);
        }


       
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            DeleteActivity myActivitys = new DeleteActivity();
            myActivitys.Delete(id);
        }
    }
}