using Magic_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Linq;

namespace Magic_API.Controllers
{
    public class StudentServicesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_studentservice> _StudentServiceList = null;
            using (var dbobj = new DB_Magic_StudentEntities())
            {

                _StudentServiceList = dbobj.PROC_GetStudentServiceDetail(0, 0).Select(
                    Student => new list_studentservice()
                    {

                        StudentID = Student.StudentID
                            ,
                        FirstName = Student.FirstName
                            ,
                        LastName = Student.LastName
                            ,
                        DateOfBirth = Student.DateOfBirth
                            ,
                        Ssn = Student.Ssn
                            ,
                        SchoolYear = Student.SchoolYear
                            ,
                        StartDate = Student.StartDate.Value
                            ,
                        EndDate = Student.EndDate.Value
                        ,
                        ServiceName = Student.ServiceName
                    }
                    ).ToList<list_studentservice>();
            }

            if (_StudentServiceList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_StudentServiceList);




        }

        [HttpGet]
        public IHttpActionResult Get(decimal SchoolYearID, decimal StudentID)
        {

            List<list_studentservice> _StudentServiceList = null;
            using (var dbobj = new DB_Magic_StudentEntities())
            {
                if (SchoolYearID != null && SchoolYearID != 0)
                {
                    _StudentServiceList = dbobj.PROC_GetStudentServiceDetail(0, SchoolYearID).Select(
                     Student => new list_studentservice()
                     {

                         StudentID = Student.StudentID
                             ,
                         FirstName = Student.FirstName
                             ,
                         LastName = Student.LastName
                             ,
                         DateOfBirth = Student.DateOfBirth
                             ,
                         Ssn = Student.Ssn
                             ,
                         SchoolYear = Student.SchoolYear
                             ,
                         StartDate = Student.StartDate.Value
                             ,
                         EndDate = Student.EndDate.Value
                         ,
                         ServiceName = Student.ServiceName
                     }
                     ).ToList<list_studentservice>();
                }
                else if (StudentID != null && StudentID != 0)
                {

                    _StudentServiceList = dbobj.PROC_GetStudentServiceDetail(StudentID, 0).Select(
                        Student => new list_studentservice()
                        {

                            StudentID = Student.StudentID
                                ,
                            FirstName = Student.FirstName
                                ,
                            LastName = Student.LastName
                                ,
                            DateOfBirth = Student.DateOfBirth
                                ,
                            Ssn = Student.Ssn
                                ,
                            SchoolYear = Student.SchoolYear
                                ,
                            StartDate = Student.StartDate.Value
                                ,
                            EndDate = Student.EndDate.Value
                            ,
                            ServiceName = Student.ServiceName
                        }
                        ).ToList<list_studentservice>();
                }
            }

            if (_StudentServiceList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_StudentServiceList);





        }
    }
}