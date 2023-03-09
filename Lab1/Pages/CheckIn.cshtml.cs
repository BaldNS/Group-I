using Lab1.Pages.DB;
using Lab2.Pages.DataClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Lab2.Pages
{
    public class CheckInModel : PageModel
    {
        [BindProperty]
        public int Professor { get; set; }

        public List<SelectListItem> Professors { get; set; }

        [BindProperty]
        public int Time { get; set; }

        public List<SelectListItem> OfficeHourTimes { get; set; }

        [BindProperty]
        public Queue AddQueue { get; set; }

        public int StudentID { get; set; }

        public IActionResult OnGet()
        {
            //Checks if user is logged in 
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            else
            {
                //Populates forms based on selection
                SqlDataReader ProfessorReader = DBClass.GeneralReaderQuery("SELECT * FROM Faculty");

                Professors = new List<SelectListItem>();

                while (ProfessorReader.Read())
                {
                    Professors.Add(new SelectListItem(
                        ProfessorReader["Professor"].ToString(),
                        ProfessorReader["ProfessorID"].ToString()));
                }

                DBClass.Lab1DBConnection.Close();

                return Page();
            }
        }


        public void OnPost()
        {
            SqlDataReader ProfessorReader = DBClass.GeneralReaderQuery("Select * FROM Faculty");

            Professors = new List<SelectListItem>();

            while (ProfessorReader.Read())
            {
                Professors.Add(new SelectListItem(
                    ProfessorReader["Professor"].ToString(),
                    ProfessorReader["ProfessorID"].ToString()));
            }
            DBClass.Lab1DBConnection.Close();

            if (Professor >= 0)
            {
                SqlDataReader TimeReader = DBClass.GeneralReaderQuery("Select OfficeDate, OfficeTime, OfficeHourID FROM OfficeHour Where ProfessorID = " + Professor);

                OfficeHourTimes = new List<SelectListItem>();

                while (TimeReader.Read())
                {
                    OfficeHourTimes.Add(
                        new SelectListItem(
                            TimeReader["OfficeDate"].ToString() + " " + TimeReader["OfficeTime"].ToString(),
                            TimeReader["OfficeHourID"].ToString()));
                }
                DBClass.Lab1DBConnection.Close();
            }


        }
        public IActionResult OnPostCheckIn()
        {
            string StudentIdQuery = "SELECT PersonID FROM Student WHERE CredentialID IN " +
                "(SELECT StudentCredID FROM StudentCredentials " +
                "WHERE Username ='" + HttpContext.Session.GetString("username") + "');";

            SqlDataReader StudentIDReader = DBClass.GeneralReaderQuery(StudentIdQuery);

            if (StudentIDReader.Read() && StudentIDReader != null)
            {
                AddQueue.StudentID = StudentIDReader.GetInt32(0);
            }
            DBClass.Lab1DBConnection.Close();

            AddQueue.OfficeHourID = Time;

            if (DBClass.CheckDuplicate(AddQueue.StudentID, AddQueue.OfficeHourID) == 0)
            {
                DBClass.InsertCheckIn(AddQueue);
                DBClass.Lab1DBConnection.Close();
                return RedirectToPage("ViewCheckedIn");
            }
            else
            {
                TempData["Error"] = "Error: You have already checked into this office hours.";
                return RedirectToPage("CheckIn");
            }
        }
    }
}

