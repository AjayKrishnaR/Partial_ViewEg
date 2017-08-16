using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewEg.Models
{
    [Bind(Exclude ="name")]
    public class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
    }
}