using Magic_UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Magic_UI.Views
{
    public class StudentController : Controller
    {

        string WebApiUrl = "http://localhost:53936";

        [HttpGet]
        public async Task<ActionResult> Index(string district)
        {
            BindDistrictDropDown();

            List<list_student> _studentlist = new List<list_student>();

            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(WebApiUrl);
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage _httpresponse = await _client.GetAsync("/api/student");
                if (district != "" && district != null)
                {
                    _httpresponse = await _client.GetAsync("/api/student/" + district);
                }
                if (_httpresponse.IsSuccessStatusCode)
                {
                    var _response = _httpresponse.Content.ReadAsStringAsync().Result;
                    _studentlist = JsonConvert.DeserializeObject<List<list_student>>(_response);
                }
            }

            return View(_studentlist);
        }



        [NonAction]
        public async void BindDistrictDropDown()
        {
            List<SelectListItem> _districtlist = new List<SelectListItem>();
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(WebApiUrl);
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage _httpresponse = await _client.GetAsync("/api/district");

                if (_httpresponse.IsSuccessStatusCode)
                {
                    var _response = _httpresponse.Content.ReadAsStringAsync().Result;
                    _districtlist = JsonConvert.DeserializeObject<List<SelectListItem>>(_response);
                    ViewBag.District = _districtlist;
                }
            }
        }
    }
}