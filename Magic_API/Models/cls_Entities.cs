using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Magic_API.Models
{

    public class list_student
    {        
        public decimal StudentID { get; set; }
        public int DistrictId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Ssn { get; set; }
        public string Text { get; set; }
        public decimal Value { get; set; }    

    }


    public class list_studentenrollment : list_student
    {
        public string SchoolYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public new string DateOfBirth { get; set; }
    }


    public class list_studentservice : list_studentenrollment
    {
        public string ServiceName { get; set; }
    }

    public class list_selectedlist
    {
        public decimal Value { get; set; }
        public string Text { get; set; }
    }

    
   




    

}