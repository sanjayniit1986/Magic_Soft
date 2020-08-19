using Magic_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Linq;

namespace Magic_API.Controllers
{
    public class StudentEnrollmentController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_studentenrollment> _StudentEnrollmentList = null;
            using (var dbobj = new DB_Magic_StudentEntities())
            {

                _StudentEnrollmentList = dbobj.PROC_GetStudentEnrollmentDetail(0, 0).Select(
                    Student => new list_studentenrollment()
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
                        }
                    ).ToList<list_studentenrollment>();
            }

            if (_StudentEnrollmentList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_StudentEnrollmentList);

        }

        [HttpGet]
        public IHttpActionResult Get(decimal SchoolYearID, decimal StudentID)
        {


            List<list_studentenrollment> _StudentEnrollmentList = null;
            using (var dbobj = new DB_Magic_StudentEntities())
            {
                if (SchoolYearID != null && SchoolYearID != 0)
                {
                    _StudentEnrollmentList = dbobj.PROC_GetStudentEnrollmentDetail(0, SchoolYearID).Select(
                        Student => new list_studentenrollment()
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
                        }
                        ).ToList<list_studentenrollment>();
                }
                else if (StudentID != null && StudentID != 0)
                {
                    _StudentEnrollmentList = dbobj.PROC_GetStudentEnrollmentDetail(StudentID, 0).Select(
                       Student => new list_studentenrollment()
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
                       }
                       ).ToList<list_studentenrollment>();
                }

            }

            if (_StudentEnrollmentList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_StudentEnrollmentList);



        }


    }
}