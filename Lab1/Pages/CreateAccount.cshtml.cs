using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab3.Pages
{
    public class CreateAccountModel : PageModel
    {
        [BindProperty] 
        public int PersonType { get; set; }

        [BindProperty]
        public String Username { get; set; }

        [BindProperty]
        public String Password { get; set; }

        [BindProperty]
        public string FirstName { get; set; }

        [BindProperty]  
        public string LastName { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (DBClass.userExists(Username))
            {
                TempData["Error"] = "User already exists.";
                return RedirectToPage("CreateAccount");
            }
            else
            {
                DBClass.CreateHashedUser(Username, Password, PersonType);
                DBClass.AuthDBConnection.Close();

                
                if (PersonType == 0)
                {
                    int count;
                    string tempQuery = "SELECT COUNT(*) FROM StudentCredentials;";
                    count = DBClass.GeneralScalarQuery(tempQuery);
                    count = count + 1;
                    DBClass.AddStudent(FirstName, LastName, count, Username);
                }
                else if (PersonType == 1)
                {
                    int count;
                    string tempQuery = "SELECT COUNT(*) FROM FacultyCredentials;";
                    count = DBClass.GeneralScalarQuery(tempQuery);
                    count = count + 1;
                    DBClass.AddFaculty(FirstName, LastName, count, Username);
                }
            }
            DBClass.Lab1DBConnection.Close();
            DBClass.AuthDBConnection.Close();

            TempData["Success"] = "User Successfully Created!";

            return RedirectToPage("CreateAccount");
        }
    }
}
