using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> cList = new List<Country>()
        {
            new Country{Id=01,CountryName="India",Capital="New Delhi"},
            new Country{Id=02,CountryName="Japan",Capital="Tokyo"},
        };
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(cList);
        }

        public IHttpActionResult Get(int id)
        {
            Country cobj = cList.Find(item => item.Id == id);
            if (cobj != null)
                return Ok(cobj);
            return NotFound();
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            Country cobj = cList.Find(item => item.Id == id);
            if(cobj!=null)
            {
                bool Isremoved = cList.Remove(cobj);
                if (Isremoved) return Ok(cobj);
            }
            return NotFound();

        }
      
       
        [HttpPut]

        public IHttpActionResult Put(int id, [FromBody] Country cobj)
        {
            if (cList[id - 1] != null)
            {
                cList[id - 1] = cobj;
                return Ok(cList);
            }
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Country cobj)
        {
            cList.Add(cobj);
            return Ok(cList);
        }
    }
}
