using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace TelegramSupportSendMsg.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Name")]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Branch")]
            public string Branch { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber, ErrorMessage = "Not a number")]
            [Display(Name = "Phone Number")]
            public string PhoneNum { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Department")]
            public string Department { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Machine Type")]
            public string MacType { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Machine ID")]
            public string MacId { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Issue")]
            public string Issue { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Telegram Bot ID")]
            public string BotId { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Telegram Chat ID")]
            public string ChatId { get; set; }

        }

        public string Message
        {
            get;
            set;
        }

        public IActionResult OnPostSubmit(InputModel Input)

        {
            if (ModelState.IsValid)
            {
                var user = User.Identity.Name;
                string strUser = user.Substring(0, 3);
                var Customer = "";

                if (strUser == "Sys")
                {
                    Customer = "SYSADMIN";
                }
                

                Message = "-------// New Issue //------- \n"
                          + "Customer : " + Customer + " \n"
                          + "User ID : " + user + " \n"
                          + "Name : " + Input.Name + " \n"
                          + "Branch : " + Input.Branch + " \n"
                          + "Phone Number : " + Input.PhoneNum + " \n"
                          + "Department : " + Input.Department + " \n"
                          + "Machine Type : " + Input.MacType + " \n"
                          + "Machine ID : " + Input.MacId + " \n"
                          + "Issue : " + Input.Issue + " \n"
                          + "-------//    End    //-------";

                //
                WebRequest req = WebRequest.Create("https://api.telegram.org/bot" + Input.BotId + "/sendMessage?chat_id=@" + Input.ChatId + "&text=" + HttpUtility.UrlEncode(Message));
                req.UseDefaultCredentials = true;
                var result = req.GetResponse();
                req.Abort();

                return RedirectToPage("/Success");
            }

            return Page();
        }

    }

}
