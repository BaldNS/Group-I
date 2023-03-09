using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LectureNotesProject.Pages.Practice
{
    public class ControlsAndFormsModel : PageModel
    {

        // Properties for Single Select Dropdown
        [BindProperty] public int SelectedNumber { get; set; }
        public String SelectMessage { get; set; }

        // Properties for Multiple Select Dropdown
        [BindProperty] public int[] SelectedToppings { get; set; }
        public String MultiSelectMessage { get; set; }

        // Properties for Checkboxes
        [BindProperty] public bool LargePizzaCheck { get; set; }
        [BindProperty] public bool DiscountCheck { get; set; }
        public String CheckBoxMessage { get; set; }


        // Properties for Radio Buttons
        [BindProperty] public int SelectedRadioValue { get; set; }
        public String RadioButtonMessage { get; set; }

        // Properties for Handling Dates and Times
        [BindProperty] public DateTime FullDateAndTime { get; set; }
        [BindProperty] public DateTime JustTheDate { get; set; }
        [BindProperty] public DateTime JustTheTime { get; set; }
        public String DateTimeMessage { get; set; }

        public void OnGet()
        {
        }

        public void OnPostSingleSelect()
        {
            SelectMessage = "Selection Choice was Value: " + SelectedNumber;
        }

        public void OnPostMultiSelect()
        {
            MultiSelectMessage = "Selected Toppings: ";
            foreach (var item in SelectedToppings)
            {
                MultiSelectMessage+= item + ",";  
            }
        }

        public void OnPostCheckboxes()
        {
            CheckBoxMessage = "You Chose:";
            if (LargePizzaCheck)
            {
                CheckBoxMessage += "Large Pizza!";
            }
            if (DiscountCheck)
            {
                CheckBoxMessage += "You Want a Discount!";
            }


        }

        public void OnPostRadioButtons()
        {
            RadioButtonMessage = "You Chose Radio Button Value: " + SelectedRadioValue;
        }

        public void OnPostDateAndTime()
        {
            DateTimeMessage = "Full Timestamp: " + FullDateAndTime.ToString("MM/dd/yy hh:mm:ss tt");
            DateTimeMessage += ", The Date: " + JustTheDate.ToString("MM/dd/yy");
            DateTimeMessage += ", The Time: " + JustTheTime.ToString("hh:mm:ss tt");

        }
    }
}
