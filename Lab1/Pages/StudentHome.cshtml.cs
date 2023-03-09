using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace Lab2.Pages
{
    public class StudentHomeModel : PageModel
    {

        //public List<SelectListItem> Professors { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }

            //SqlDataReader ProfessorReader = DBClass.ProfessorReader();

            //Professors = new List<SelectListItem>();

            //while (ProfessorReader.Read())
            //{
            //    Professors.Add(
            //        new SelectListItem(
            //            ProfessorReader["Professor"].ToString(),
            //            ProfessorReader["ProfessorID"].ToString()));
            //}

            //DBClass.Lab1DBConnection.Close();
            return Page();
        }
    }
}
