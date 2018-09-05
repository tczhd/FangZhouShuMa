using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FangZhouShuMa.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FangZhouShuMa.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/StudentAPI")]
    public class StudentAPIController : Controller
    {
        // GET: api/GetAllStudents  
        [HttpGet]
        public IEnumerable<StudentDetail> GetAllStudents()
        {
            List<StudentDetail> students = new List<StudentDetail>
           {
           new StudentDetail{
                              RegNo = "2017-0001",
                              Name = "Nishan",
                              Address = "Kathmandu",
                              PhoneNo = "9849845061",
                              AdmissionDate = DateTime.Now
                              },
           new StudentDetail{
                              RegNo = "2017-0002",
                              Name = "Namrata Rai",
                              Address = "Bhaktapur",
                              PhoneNo = "9849845062",
                              AdmissionDate = DateTime.Now
                             },
           };
            return students;
        }
    }
}