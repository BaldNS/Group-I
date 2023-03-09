using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab3.Pages
{
    public class ViewNotificationsModel : PageModel
    {

        [BindProperty]
        public int queueID { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string sqlQuery = "UPDATE Queue SET Status = 0 WHERE QueueID = @QueueID";
            SqlCommand command = new SqlCommand(sqlQuery, DBClass.Lab1DBConnection);
            command.Parameters.AddWithValue("@QueueID", queueID);
            DBClass.Lab1DBConnection.Open();
            int result = command.ExecuteNonQuery();
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("/ViewNotifications");
        }
    }
}
