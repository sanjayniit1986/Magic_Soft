using Magic_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace Magic_API.Controllers
{
    public class StudentEnrollmentController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_studentenrollment> lstData = new List<list_studentenrollment>();

            cls_Student obj_StudentDetail = new cls_Student();
            DataTable vDT = obj_StudentDetail.GetStudentEnrollmentList("0", "0");

            if (vDT != null)
            {
                if (vDT.Rows.Count > 0)
                {
                    int i;

                    for (i = 0; i < vDT.Rows.Count; i++)
                    {
                        lstData.Add(new list_studentenrollment
                        {
                            StudentID = Convert.ToInt16(vDT.Rows[i]["StudentID"])
                            ,
                            FirstName = vDT.Rows[i]["FirstName"].ToString()
                            ,
                            LastName = vDT.Rows[i]["LastName"].ToString()
                            ,
                            DateOfBirth = vDT.Rows[i]["DateOfBirth"].ToString()
                            ,
                            Ssn = vDT.Rows[i]["Ssn"].ToString()
                            ,
                            SchoolYear = vDT.Rows[i]["SchoolYear"].ToString()
                            ,
                            StartDate = vDT.Rows[i]["StartDate"].ToString()
                            ,
                            EndDate = vDT.Rows[i]["EndDate"].ToString()


                        });
                    }
                }


            }
            return Ok(lstData);
        }

        [HttpGet]
        public IHttpActionResult Get(string SchoolYearID, string StudentID)
        {
            List<list_studentenrollment> lstData = new List<list_studentenrollment>();

            cls_Student obj_StudentDetail = new cls_Student();
            DataTable vDT = new DataTable();

            if (SchoolYearID != null && SchoolYearID != "0")
            {
                vDT = obj_StudentDetail.GetStudentEnrollmentList("0", SchoolYearID);
            }
            else if (StudentID != null && StudentID != "0")
            {
                vDT = obj_StudentDetail.GetStudentEnrollmentList(StudentID, "0");
            }

            if (vDT != null)
            {
                if (vDT.Rows.Count > 0)
                {
                    int i;

                    for (i = 0; i < vDT.Rows.Count; i++)
                    {
                        lstData.Add(new list_studentenrollment
                        {
                            StudentID = Convert.ToInt16(vDT.Rows[i]["StudentID"])
                            ,
                            FirstName = vDT.Rows[i]["FirstName"].ToString()
                            ,
                            LastName = vDT.Rows[i]["LastName"].ToString()
                            ,
                            DateOfBirth = vDT.Rows[i]["DateOfBirth"].ToString()
                            ,
                            Ssn = vDT.Rows[i]["Ssn"].ToString()
                            ,
                            SchoolYear = vDT.Rows[i]["SchoolYear"].ToString()
                            ,
                            StartDate = vDT.Rows[i]["StartDate"].ToString()
                            ,
                            EndDate = vDT.Rows[i]["EndDate"].ToString()


                        });
                    }
                }


            }
            return Ok(lstData);
        }


    }
}