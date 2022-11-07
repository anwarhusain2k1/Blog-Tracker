using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blog_Tracker;
namespace WEB.Controllers
{
    public class blogController : ApiController
    {
        // GET api/<controller>
        public List<BlogInfo> Get()
        {
            
            BlogDal bdal = new BlogDal();

            return bdal.getblog();
        }

        // GET api/<controller>/5
        public BlogInfo Get(int id)
        {
            BlogDal bdal = new BlogDal();
            return bdal.find(id);
        }

        // POST api/<controller>
        public string Post([FromBody] BlogInfo blog)
        {
            BlogDal bdal = new BlogDal();
            bdal.addblog(blog);
            return "blog added...";
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] BlogInfo blog)
        {
            BlogDal bdal = new BlogDal();
            bdal.update(id, blog);
            return "blog updated...";
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            BlogDal bdal = new BlogDal();
            bdal.delete(id);
            return "blog deleted...";
        }
    }
}