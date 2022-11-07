using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Emp
    {
        public string EmailId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateOfJoining { get; set; }
        public Nullable<int> PassCode { get; set; }
    }
}