using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PassangerManagmentServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassangerController : ControllerBase
    {

        List<PassangerModel> psglist = new List<PassangerModel>();
        // GET: api/<PassangerController>
        [HttpGet]


        public IEnumerable<PassangerModel> Get()
        {
            PassangerModel psg1 = new PassangerModel();
            PassangerModel psg2 = new PassangerModel();

            psg1.PassangerId = 101;
            psg1.PassangerName = "Tushar";


            psg1.PassangerId = 102;
            psg1.PassangerName = "Akash";

            psglist.Add(psg1);
            psglist.Add(psg2);

            return psglist;
        }


        // GET api/<PassangerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PassangerController>
        [HttpPost]
        public void Post([FromBody] PassangerModel drobj)
        {
            //List<DriverModel> drlist = new List<DriverModel>();

            psglist.Add(drobj);
        }
        // PUT api/<PassangerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PassangerModel drobj)
        {
            var data = psglist.FirstOrDefault(x => x.PassangerId == id);
            if (data != null)
            {
                data.PassangerId = drobj.PassangerId;
                data.PassangerName = drobj.PassangerName;
            }
        }

        // DELETE api/<PassangerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = psglist.FirstOrDefault(x => x.PassangerId == id);
            psglist.Remove(data);
        }
    }
}