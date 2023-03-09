using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace Lab2.Pages
{
    public class EditSignUpModel : PageModel
    {

        [BindProperty]
        public Meetings MeetingToUpdate { get; set; }

        public EditSignUpModel() 
        { 
                MeetingToUpdate = new Meetings();
        }

        public void OnGet(int meetingID)
        {
            SqlDataReader singleMeeting = DBClass.SingleSignUpRead(meetingID);

            while (singleMeeting.Read()) 
            {
                MeetingToUpdate.MeetingID = meetingID;
                MeetingToUpdate.FirstName = singleMeeting["FirstName"].ToString();
                MeetingToUpdate.LastName = singleMeeting["LastName"].ToString();
                MeetingToUpdate.Professor = singleMeeting["Professor"].ToString();
                MeetingToUpdate.DateandTime = DateTime.Parse(singleMeeting["DateandTime"].ToString());
                MeetingToUpdate.Purpose = singleMeeting["Purpose"].ToString();
                MeetingToUpdate.StudentCredID = int.Parse(singleMeeting["StudentCredID"].ToString());
                MeetingToUpdate.FacultyCredID = int.Parse(singleMeeting["FacultyCredID"].ToString());
            }
            
            DBClass.Lab1DBConnection.Close();
        }

        public IActionResult OnPost()
        {

            string sqlQuery = "SELECT FacultyCredentials.FacultyCredID " +
    "FROM Faculty JOIN FacultyCredentials ON Faculty.CredentialID = FacultyCredentials.FacultyCredID " +
    "WHERE Faculty.Professor = '" + MeetingToUpdate.Professor + "';";

            SqlDataReader ProfessorCredIdRead = DBClass.GeneralReaderQuery(sqlQuery);

            if (ProfessorCredIdRead.Read())
            {
                MeetingToUpdate.FacultyCredID = ProfessorCredIdRead.GetInt32(0);
            }
            DBClass.Lab1DBConnection.Close();

            string sqlQ = "SELECT StudentCredID FROM StudentCredentials WHERE Username = '" + HttpContext.Session.GetString("username") + "';";

            SqlDataReader StudentCredIdRead = DBClass.GeneralReaderQuery(sqlQ);

            if (StudentCredIdRead.Read())
            {
                MeetingToUpdate.StudentCredID = StudentCredIdRead.GetInt32(0);
            }
            DBClass.Lab1DBConnection.Close();

            DBClass.UpdateSignUp(MeetingToUpdate);

            DBClass.Lab1DBConnection.Close();

            return RedirectToPage("StudentHome");
        }
    }
}
