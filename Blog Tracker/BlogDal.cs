using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Tracker
{
    public class BlogDal
    {
        public List<BlogInfo> getblog()
        {
            blogEntities context = new blogEntities();
            List<BlogInfo> blogs = context.BlogInfoes.ToList();
            return blogs;
        }
        public void addblog(BlogInfo blog)
        {
            blogEntities context = new blogEntities();
            context.BlogInfoes.Add(blog);
            context.SaveChanges();
        }
        public void delete(int id)
        {
            blogEntities context = new blogEntities();
            List<BlogInfo> blogs = context.BlogInfoes.ToList();
            BlogInfo blog = blogs.Find(x => x.BlogId == id);
            context.BlogInfoes.Remove(blog);
            context.SaveChanges();

        }
        public void update(int id, BlogInfo blog)
        {
            delete(id);
            addblog(blog);
        }
        public BlogInfo find(int id)
        {
            blogEntities context = new blogEntities();
            List<BlogInfo> blogs = context.BlogInfoes.ToList();
            BlogInfo blog = blogs.Find(x => x.BlogId == id);
            return blog;
        }
    }
}
