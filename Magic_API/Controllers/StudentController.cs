using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Magic_API.Models;

namespace Magic_API.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(decimal DistrictId)
        {
            List<list_student> _StudentList = null;
            if (DistrictId != null)
            {
                using (var dbobj = new DB_Magic_StudentEntities())
                {
                    _StudentList = dbobj.tbl_Master_Student
                        .Where(Student => Student.IsActive == "Y")
                        .Where(Student => Student.IsDeleted == "N")
                        .Where(Student => Student.RefDistrictId == DistrictId)
                        .Select(
                        Student => new list_student()
                        {
                            StudentID = Student.StudentID
                                ,
                            FirstName = Student.FirstName
                                ,
                            LastName = Student.LastName
                                ,
                            DateOfBirth = Student.DateOfBirth.Value
                                ,
                            Ssn = Student.Ssn
                                ,
                            Text = Student.FirstName + " " + Student.LastName
                                ,
                            Value = Student.StudentID
                        }
                        ).ToList<list_student>();
                }                
            }
            if (_StudentList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_StudentList);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_student> _StudentList = null;
            using (var dbobj = new DB_Magic_StudentEntities())
            {
                _StudentList = dbobj.tbl_Master_Student
                    .Where(Student => Student.IsActive == "Y")
                    .Where(Student => Student.IsDeleted == "N")
                    .Select(
                    Student => new list_student()
                    {
                        StudentID = Student.StudentID
                            ,
                        FirstName = Student.FirstName
                            ,
                        LastName = Student.LastName
                            ,
                        DateOfBirth = Student.DateOfBirth.Value
                            ,
                        Ssn = Student.Ssn
                            ,
                        Text = Student.FirstName + " " + Student.LastName
                            ,
                        Value = Student.StudentID
                    }
                    ).ToList<list_student>();
            }
            if (_StudentList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_StudentList);
        }
    }
}