//get and set method for meetings

using Microsoft.VisualBasic;

namespace Lab1.Pages.DataClasses
{
    public class Meetings { 

        public int MeetingID { get; set; }
    
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Professor { get; set; }
        
        public DateTime DateandTime { get; set; }

        public String Purpose { get; set; }

        public int StudentCredID { get; set; }

        public int FacultyCredID { get; set; }
    }
}
