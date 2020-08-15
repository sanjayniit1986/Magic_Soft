



namespace Magic_UI.Models
{
    public class list_student
    {
        public int StudentID { get; set; }
        public int DistrictId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Ssn { get; set; }
    }

    public class list_studentenrollment : list_student
    {
        public string SchoolYear { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }


    public class list_studentservice : list_studentenrollment
    {
        public string ServiceName { get; set; }
    }
}