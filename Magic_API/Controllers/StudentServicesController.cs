using Magic_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace Magic_API.Controllers
{
    public class StudentServicesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_service> lstData = new List<list_service>();

            cls_Student obj_StudentDetail = new cls_Student();
            DataTable vDT = obj_StudentDetail.GetStudentServicesList("0", "0");

            if (vDT != null)
            {
                if (vDT.Rows.Count > 0)
                {
                    int i;

                    for (i = 0; i < vDT.Rows.Count; i++)
                    {
                        lstData.Add(new list_service
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
                            ,
                            ServiceName = vDT.Rows[i]["ServiceName"].ToString()

                        });
                    }
                }


            }
            return Ok(lstData);
        }

        [HttpGet]
        public IHttpActionResult Get(string SchoolYearID, string StudentID)
        {
            List<list_service> lstData = new List<list_service>();

            cls_Student obj_StudentDetail = new cls_Student();
            DataTable vDT = new DataTable();

            if (SchoolYearID != null && SchoolYearID != "0")
            {
                vDT = obj_StudentDetail.GetStudentServicesList("0", SchoolYearID);
            }
            else if (StudentID != null && StudentID != "0")
            {
                vDT = obj_StudentDetail.GetStudentServicesList(StudentID, "0");
            }

            if (vDT != null)
            {
                if (vDT.Rows.Count > 0)
                {
                    int i;

                    for (i = 0; i < vDT.Rows.Count; i++)
                    {
                        lstData.Add(new list_service
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
                             ,
                            ServiceName = vDT.Rows[i]["ServiceName"].ToString()

                        });
                    }
                }


            }
            return Ok(lstData);
        }
    }
}