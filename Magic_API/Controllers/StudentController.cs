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
        public IHttpActionResult Get(string DistrictId)
        {
            List<list_student> lstData = new List<list_student>();


            if (DistrictId != null)
            {

                cls_Student obj_StudentDetail = new cls_Student();
                DataTable vDT = obj_StudentDetail.GetStudentList(DistrictId);

                if (vDT != null)
                {
                    if (vDT.Rows.Count > 0)
                    {
                        int i;

                        for (i = 0; i < vDT.Rows.Count; i++)
                        {
                            lstData.Add(new list_student
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
                                Text = vDT.Rows[i]["FirstName"].ToString() + " " + vDT.Rows[i]["LastName"].ToString()
                                ,
                                Value = Convert.ToInt16(vDT.Rows[i]["StudentID"])
                            });
                        }
                    }
                }

            }
            return Ok(lstData);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_student> lstData = new List<list_student>();

            cls_Student obj_StudentDetail = new cls_Student();
            DataTable vDT = obj_StudentDetail.GetStudentList("0");

            if (vDT != null)
            {
                if (vDT.Rows.Count > 0)
                {
                    int i;

                    for (i = 0; i < vDT.Rows.Count; i++)
                    {
                        lstData.Add(new list_student
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
                            Text = vDT.Rows[i]["FirstName"].ToString() + " " + vDT.Rows[i]["LastName"].ToString()
                            ,
                            Value = Convert.ToInt16(vDT.Rows[i]["StudentID"])
                        });
                    }
                }


            }
            return Ok(lstData);
        }
	}
}