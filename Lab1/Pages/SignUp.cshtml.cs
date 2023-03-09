using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace Lab2.Pages
{
    public class SignUpModel : PageModel
    {
       
        [BindProperty] 
        public Meetings NewMeeting { get; set; }

        [BindProperty]
        public String FirstName { get; set; }

        [BindProperty]
        public String LastName { get; set; }

        public List<SelectListItem> Professors { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }            
            SqlDataReader ProfessorReader = DBClass.ProfessorReader();

            Professors = new List<SelectListItem>();

            while (ProfessorReader.Read())
            {
                Professors.Add(
                    new SelectListItem(
                        ProfessorReader["Professor"].ToString(),
                        ProfessorReader["ProfessorID"].ToString()));
            }

            DBClass.Lab1DBConnection.Close();

            return Page();
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            NewMeeting.FirstName = "First";
            NewMeeting.LastName = "Last";
            NewMeeting.Professor = "Michel Mitri";
            NewMeeting.Purpose = "Discuss Grade";
            return Page();
            
        }

        public IActionResult OnPostClearHandler()
        {
            
            NewMeeting = new Meetings();
            return RedirectToPage("Index");
        }

        public IActionResult OnPost()
        {
            string sqlQuery = "SELECT FacultyCredentials.FacultyCredID " +
                "FROM Faculty JOIN FacultyCredentials ON Faculty.CredentialID = FacultyCredentials.FacultyCredID " +
                "WHERE Faculty.Professor = '" + NewMeeting.Professor + "';";

            SqlDataReader ProfessorCredIdRead = DBClass.GeneralReaderQuery(sqlQuery);

            if (ProfessorCredIdRead.Read())
            {
                NewMeeting.FacultyCredID = ProfessorCredIdRead.GetInt32(0);
            }
            DBClass.Lab1DBConnection.Close();

            string sqlQ = "SELECT StudentCredID FROM StudentCredentials WHERE Username = '" + HttpContext.Session.GetString("username") + "';";

            SqlDataReader StudentCredIdRead = DBClass.GeneralReaderQuery(sqlQ);

            if (StudentCredIdRead.Read())
            {
                NewMeeting.StudentCredID = StudentCredIdRead.GetInt32(0);
            }
            DBClass.Lab1DBConnection.Close();

            DBClass.InsertMeeting(NewMeeting);
            DBClass.Lab1DBConnection.Close();

            return RedirectToPage("StudentHome");

        }
    }
}
