using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab2.Pages
{
    public class ViewQueueModel : PageModel
    {
        public int queueID { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public IActionResult OnPost(int queueID)
        {
            string sqlQuery = "UPDATE Queue SET Status = 1 WHERE QueueID = @QueueID";
            SqlCommand command = new SqlCommand(sqlQuery, DBClass.Lab1DBConnection);
            command.Parameters.AddWithValue("@QueueID", queueID);
            DBClass.Lab1DBConnection.Open();
            int result = command.ExecuteNonQuery();
            DBClass.Lab1DBConnection.Close();
            TempData["Success"] = "Student Notified!";
            return RedirectToPage("/ViewQueue");
        }

    }
}
