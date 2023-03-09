using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab3.Pages
{
    public class SearchProfessorModel : PageModel
    {

        [BindProperty]
        public string ProfessorName { get; set; }

        public void OnGet()
        {
        }
    }
}
