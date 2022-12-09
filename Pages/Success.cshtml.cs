using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TelegramSupportSendMsg.Pages
{
    public class SuccessModel : PageModel
    {
        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost()
        {
            return RedirectToPage("/Index");
        }
    }
}

