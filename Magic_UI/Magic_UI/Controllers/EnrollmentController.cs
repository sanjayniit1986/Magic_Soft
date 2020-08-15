using Magic_UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Magic_UI.Controllers
{
    public class EnrollmentController : Controller
    {
        string WebApiUrl = "http://localhost:53936";

        public async Task<ActionResult> Index(string SchoolYearID, string StudentID)
        {

            BindStudentDropDown();

            BindSchoolYearDropDown();


            List<list_studentenrollment> _studentlist = new List<list_studentenrollment>();
            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(WebApiUrl);
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage _httpresponse = await _client.GetAsync("/api/studentenrollment");

                if (SchoolYearID != "" && SchoolYearID != null)
                {
                    _httpresponse = await _client.GetAsync("api/studentenrollment/" + SchoolYearID + "/0");
                }
                else if (StudentID != "" && StudentID != null)
                {
                    _httpresponse = await _client.GetAsync("api/studentenrollment/0/" + StudentID);
                }
                if (_httpresponse.IsSuccessStatusCode)
                {
                    var _response = _httpresponse.Content.ReadAsStringAsync().Result;
                    _studentlist = JsonConvert.DeserializeObject<List<list_studentenrollment>>(_response);
                }
            }
            return View(_studentlist);

        }

        [NonAction]
        public async void BindStudentDropDown()
        {
            List<SelectListItem> _dropdownlist = new List<SelectListItem>();


            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(WebApiUrl);
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage _httpresponse = await _client.GetAsync("/api/student");

                if (_httpresponse.IsSuccessStatusCode)
                {
                    var _response = _httpresponse.Content.ReadAsStringAsync().Result;
                    _dropdownlist = JsonConvert.DeserializeObject<List<SelectListItem>>(_response);
                    
                }
            }
            ViewBag.StudentDetail = _dropdownlist;

        }



        [NonAction]
        public async void BindSchoolYearDropDown()
        {
            List<SelectListItem> _dropdownlist = new List<SelectListItem>();


            using (var _client = new HttpClient())
            {
                _client.BaseAddress = new Uri(WebApiUrl);
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage _httpresponse = await _client.GetAsync("/api/schoolyear");

                if (_httpresponse.IsSuccessStatusCode)
                {
                    var _response = _httpresponse.Content.ReadAsStringAsync().Result;
                    _dropdownlist = JsonConvert.DeserializeObject<List<SelectListItem>>(_response);
                    
                }
            }
            ViewBag.SchoolYear = _dropdownlist;


        }
    }
}