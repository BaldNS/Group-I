//get and set method for officehours

namespace Lab1.Pages.DataClasses
{
    public class OfficeHour {

        public int OfficeHourID { get; set; }
        public int ProfessorID { get; set; }
        public String? OfficeRoom { get; set; }
        public String? OfficeDate { get; set; }
        public String? OfficeTime { get; set; }
    }
}
