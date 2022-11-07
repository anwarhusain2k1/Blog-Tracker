using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog_Tracker;

namespace WEB.Controllers
{
    public class empController : ApiController
    {
        // GET api/<controller>
        public List<EmpInfo> Get()
        {

            Empdal edal = new Empdal();

            return edal.getemplist();
        }

        // GET api/<controller>/5
        public EmpInfo Get(string id)
        {
            Empdal edal = new Empdal();
            return edal.find(id);
        }

        // POST api/<controller>
        public string Post([FromBody] EmpInfo emp)
        {
            Empdal edal = new Empdal();
            edal.addemp(emp);
            return "employee added...";
        }

        // PUT api/<controller>/5
        public string Put(string id, [FromBody] EmpInfo emp)
        {
            Empdal edal = new Empdal();
            edal.edit(id, emp);
            return "value updated...";
        }

        // DELETE api/<controller>/5
        public string Delete(string id)
        {
            Empdal edal = new Empdal();
            edal.deleteemp(id);
            return "employee removed...";
        }
    }
}