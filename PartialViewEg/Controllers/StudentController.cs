using PartialViewEg.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViewEg.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
           
        }

        public ActionResult check()
        {
            List<Student> studlist = GetStudent();
            return PartialView("Student_Partial", studlist);

        }
        [HttpGet]
        public ActionResult create()
        {
            Student s = new Student();
            UpdateModel(s);

            return View();

        }
        [HttpPost]
        public ActionResult create(Student s)
        {
            //Student s = new Student();
            //UpdateModel(s);

            return View();

        }

        private List<Student> GetStudent()
        {
            SqlConnection con = new SqlConnection("Data Source=SUYPC223;Initial Catalog=DbDatabase;Integrated Security=True");
            con.Open();
            SqlDataAdapter ad = new SqlDataAdapter("select * from [dbo].[Student]", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            List<Student> studlist = new List<Student>();
            foreach(DataRow dr in dt.Rows)
            {
                Student model = new Student();
                model.id = Convert.ToInt32(dr["id"]);
                model.Name = Convert.ToString(dr["Name"]);
                model.Job = Convert.ToString(dr["Job"]);
                studlist.Add(model);
            }
            return studlist;
       }

        
    }
}