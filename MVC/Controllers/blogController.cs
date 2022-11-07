using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_Tracker;
using MVC.Models;

namespace MVC.Controllers
{
    public class blogController : Controller
    {
        // GET: blog
        public ActionResult Index()
        {
            BlogDal bdal = new BlogDal();
            List<BlogInfo> list = bdal.getblog();
            List<Blog> l = new List<Blog>();
            foreach (BlogInfo b in list)
            {
                Blog blog = new Blog();
                blog.Title = b.Title;
                blog.BlogId = b.BlogId;
                blog.Subject = b.Subject;
                blog.DateOfCreation=b.DateOfCreation;
                blog.EmpEmailId = b.EmpEmailId;
                blog.BlogUrl=   b.BlogUrl;
                l.Add(blog);
            }
            return View(l);
        }
        public ActionResult Admin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin(Admin admin)
        {
            return RedirectToAction("employees"); 
        }
        public ActionResult employees()
        {
            List<Emp> list = new List<Emp>();
            Empdal edal = new Empdal();
            List<EmpInfo> l = edal.getemplist();
            foreach (EmpInfo emp in l)
            {
                Emp emp1 = new Emp();
                emp1.EmailId = emp.EmailId;
                emp1.Name = emp.Name;
                emp1.PassCode = emp.PassCode;
                emp1.DateOfJoining = emp.DateOfJoining;
                list.Add(emp1);
            }
            return View(list);
        }
        // GET: blog/Details/5
        public ActionResult Details(string id)
        {
            Empdal edal = new Empdal();
            EmpInfo emp = edal.find(id);
            Emp emp1 = new Emp();
            emp1.EmailId= emp.EmailId;
            emp1.Name= emp.Name;
            emp1.DateOfJoining=emp.DateOfJoining;
            emp1.PassCode= emp.PassCode;
            return View(emp1);
        }

        // GET: blog/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: blog/Create
        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            try
            {
                
                EmpInfo emp1 = new EmpInfo();
                emp1.EmailId = emp.EmailId;
                emp1.Name = emp.Name;
                emp1.DateOfJoining = emp.DateOfJoining;
                emp1.PassCode = emp.PassCode;
                Empdal edal = new Empdal();
                edal.addemp(emp1);
                return RedirectToAction("employees");
            }
            catch
            {
                return View();
            }
        }

        // GET: blog/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: blog/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Emp emp)
        {
            try
            {
                // TODO: Add update logic here
                EmpInfo emp1 = new EmpInfo();
                emp1.EmailId = emp.EmailId;
                emp1.Name = emp.Name;
                emp1.DateOfJoining = emp.DateOfJoining;
                emp1.PassCode = emp.PassCode;
                Empdal edal = new Empdal();
                edal.edit(id, emp1);
                return RedirectToAction("employees");
            }
            catch
            {
                return View();
            }
        }

        // GET: blog/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: blog/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Emp emp)
        {
            try
            {
                // TODO: Add delete logic here
                
                Empdal edal = new Empdal();
                edal.deleteemp(id);
                return RedirectToAction("employees");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult employeelogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult employeelogin(Emp emp)
        {
            return RedirectToAction("blog");
        }
        public ActionResult blog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult blog(Blog blog)
        {
            BlogInfo bl = new BlogInfo();
            bl.Title= blog.Title;   
            bl.Subject= blog.Subject;
            bl.DateOfCreation=blog.DateOfCreation;
            bl.BlogId=blog.BlogId;
            bl.BlogUrl=blog.BlogUrl;
            bl.EmpEmailId=blog.EmpEmailId;
            BlogDal bdal = new BlogDal();
            bdal.addblog(bl);
            return View("Index");
        }
    }
}
