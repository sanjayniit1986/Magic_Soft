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
    public class DistrictController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_selectedlist> lstData = new List<list_selectedlist>();

            cls_Student obj_StudentDetail = new cls_Student();
            DataTable vDT = obj_StudentDetail.GetDistrict();

            if (vDT != null)
            {
                if (vDT.Rows.Count > 0)
                {
                    int i;

                    for (i = 0; i < vDT.Rows.Count; i++)
                    {
                        lstData.Add(new list_selectedlist
                        {
                            Value = Convert.ToInt16(vDT.Rows[i]["DistrictID"])
                            ,
                            Text = vDT.Rows[i]["DistrictName"].ToString()
                        });
                    }
                }
            }
            return Ok(lstData);
        }
	}
}