using Magic_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;

namespace Magic_API.Controllers
{
    public class SchoolYearController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_selectedlist> lstData = new List<list_selectedlist>();

            cls_Student obj_StudentDetail = new cls_Student();
            DataTable vDT = obj_StudentDetail.GetSchoolYearList();

            if (vDT != null)
            {
                if (vDT.Rows.Count > 0)
                {
                    int i;

                    for (i = 0; i < vDT.Rows.Count; i++)
                    {
                        lstData.Add(new list_selectedlist
                        {
                            Value = Convert.ToInt16(vDT.Rows[i]["SchoolYearId"])
                            ,
                            Text = vDT.Rows[i]["SchoolYear"].ToString()
                        });
                    }
                }
            }
            return Ok(lstData);
        }
    }
}