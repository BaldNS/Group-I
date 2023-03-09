using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty] public int PersonType { get; set; }
        [BindProperty]
        public String Username { get; set; }

        [BindProperty]
        public String Password { get; set; }

        public String LoginMessage { get; set; }


        public void OnGet(String logout)
        {
            if (logout != null)
            {
                HttpContext.Session.Clear();
                DBClass.Lab1DBConnection.Close();
                LoginMessage = "Logged Out Successfully";
            }
        }


        public IActionResult OnPost()
        {
                if (DBClass.HashedParameterLogin(Username, Password, PersonType))
                {
                    HttpContext.Session.SetString("username", Username);
                    if (PersonType == 0)
                    {
                        HttpContext.Session.SetInt32("Person", 0);
                        DBClass.AuthDBConnection.Close();
                        return RedirectToPage("StudentHome");
                    }
                    else if (PersonType == 1)
                    {
                        HttpContext.Session.SetInt32("Person", 1);
                        DBClass.AuthDBConnection.Close();
                        return RedirectToPage("ViewQueue");
                    }
                }
                else
                {
                    ViewData["LoginMessage"] = "Username and/or Password Incorrect";
                }
            DBClass.AuthDBConnection.Close();
            return Page();
        }
    }
}