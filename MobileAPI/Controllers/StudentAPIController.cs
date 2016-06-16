using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileAPI.DBA;
using MobileAPI.Models;

namespace MobileAPI.Controllers
{
    
    public class StudentAPIController : ApiController
    {
        ApiDbContext dbContext = null;

        public StudentAPIController()
        {
            dbContext = new ApiDbContext();
        }
        [HttpPost]
        public IHttpActionResult InsertStudent(Student student)
        {

            dbContext.Students.Add(student);
            dbContext.SaveChangesAsync();

            return Ok(student.Id);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            var list = dbContext.Students.ToList();

            return list;
        }

        [HttpGet]
        public IHttpActionResult DeleteStudent(int id)
        {
            var student = dbContext.Students.Find(id);

            dbContext.Students.Remove(student);

            dbContext.SaveChangesAsync();

            return Ok(student.FirstName + " " + student.LastName + " is deleted successfully.");

        }

        [HttpGet]
        public IHttpActionResult ViewStudent(int id)
        {
            var student = dbContext.Students.Find(id);
            return Ok(student);
        }
        [HttpPost]
        public IHttpActionResult UpdateStudent(Student student)
        {

            var std = dbContext.Students.Find(student.Id);

            std.FirstName = student.FirstName;
            std.LastName = student.LastName;
            std.BirthDay = student.BirthDay;
            std.Gender = student.Gender;
            std.Address = student.Address;

            dbContext.Entry(std).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChangesAsync();

            return Ok();
        }






    }
}
