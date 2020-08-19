using Magic_API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Magic_API.Controllers
{
    public class DistrictController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<list_selectedlist> _DistList = null;
            using (var dbobj = new DB_Magic_StudentEntities())
            {
                _DistList = dbobj.tbl_Master_District.Select(
                    Dis => new list_selectedlist()
                    {
                        Value = Dis.DistrictID
                        ,
                        Text = Dis.DistrictName
                    }
                    ).ToList<list_selectedlist>();
            }
            if (_DistList.Count == 0)
            {
                return NotFound();
            }

            return Ok(_DistList);
        }
    }
}