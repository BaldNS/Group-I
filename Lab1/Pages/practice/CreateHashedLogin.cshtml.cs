using GroceryInventory.Pages.DB;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GroceryInventory.Pages.Practice
{
    public class CreateHashedLoginModel : PageModel
    {
        [BindProperty] public int PersonType { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

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

 

            DBClass.CreateHashedUser(Username, Password, PersonType);
            DBClass.AuthDBConnection.Close();

            // Perform actual logic to check if user was successfully
            //  added in your projects but for demo purposes we can say:

            ViewData["UserCreate"] = "User Successfully Created!";

            return RedirectToPage("HashedLogin");
        }
    }
}
