using Magic_API.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;

namespace Magic_API.Controllers
{
    public class SchoolYearController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {

            List<list_selectedlist> _SchoolYearList = null;

            using (var dbobj = new DB_Magic_StudentEntities())
            {
                _SchoolYearList = dbobj.tbl_Master_SchoolYear.Select(
                    School => new list_selectedlist()
                    {
                        Value = School.SchoolYearId
                        ,
                        Text = School.SchoolYear
                    }
                    ).ToList<list_selectedlist>();
            }
            if (_SchoolYearList.Count == 0)
            {
                return NotFound();
            }
            return Ok(_SchoolYearList);
        }
    }
}