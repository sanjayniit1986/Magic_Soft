using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Magic_API.Models
{

    public class list_student
    {        
        public int StudentID { get; set; }
        public int DistrictId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Ssn { get; set; }
        public string Text { get; set; }
        public int Value { get; set; }    

    }


    public class list_studentenrollment : list_student
    {
        public string SchoolYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }        
    }


    public class list_service : list_studentenrollment
    {
        public string ServiceName { get; set; }
    }

    public class list_selectedlist
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }


    public class cls_Student
    {

        public DataTable GetDistrict()
        {
            DataTable vDT = null;
            DB objDB = new DB();
            vDT = objDB.ExecStoredProc("PROC_Get_District", new string[] { }, new string[] { });
            return vDT;
        }

        public DataTable GetStudentList(string vDistrictID)
        {            
            DataTable vDT = null;
            DB objDB = new DB();
            vDT = objDB.ExecStoredProc("PROC_GetStudentDetail", new string[] { "DistrictID" }, new string[] { vDistrictID });
            return vDT;
        }


        public DataTable GetSchoolYearList()
        {
            DataTable vDT = null;
            DB objDB = new DB();
            vDT = objDB.ExecStoredProc("PROC_Get_SchoolYear", new string[] {  }, new string[] {  });
            return vDT;
        }


        public DataTable GetStudentEnrollmentList(string vStudentID, string vSchoolYearID)
        {
            DataTable vDT = null;
            DB objDB = new DB();
            vDT = objDB.ExecStoredProc("PROC_GetStudentEnrollmentDetail", new string[] { "StudentID", "SchoolYearID" }, new string[] { vStudentID, vSchoolYearID });
            return vDT;
        }


        public DataTable GetStudentServicesList(string vStudentID, string vSchoolYearID)
        {
            DataTable vDT = null;
            DB objDB = new DB();
            vDT = objDB.ExecStoredProc("PROC_GetStudentServiceDetail", new string[] { "StudentID", "SchoolYearID" }, new string[] { vStudentID, vSchoolYearID });
            return vDT;
        }
    }




    

}