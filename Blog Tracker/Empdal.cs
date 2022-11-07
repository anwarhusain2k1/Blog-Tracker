using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Tracker
{
    public class Empdal
    {
        public List<EmpInfo> getemplist()
        {
            blogEntities context = new blogEntities();
            List<EmpInfo> emplist = context.EmpInfoes.ToList();
            return emplist;
        }
        public void addemp(EmpInfo emp)
        {
            blogEntities context = new blogEntities();
            context.EmpInfoes.Add(emp);
            context.SaveChanges();
        }
        public void deleteemp(string email)
        {
            blogEntities context = new blogEntities();
            List<EmpInfo> emplist = context.EmpInfoes.ToList();
            EmpInfo emp = emplist.Find(x => x.EmailId == email);
            context.EmpInfoes.Remove(emp);
            context.SaveChanges();
        }
        public void edit(string email, EmpInfo emp)
        {
            deleteemp(email);
            addemp(emp);
        }
        public EmpInfo find(string email)
        {
            blogEntities context = new blogEntities();
            List<EmpInfo> emplist = context.EmpInfoes.ToList();
            EmpInfo emp = emplist.Find(x => x.EmailId == email);
            return emp;
        }
    }
}

