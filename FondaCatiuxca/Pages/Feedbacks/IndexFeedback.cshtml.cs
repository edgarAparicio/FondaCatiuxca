using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using EdgarAparicio.FondaCatiuxca.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FondaCatiuxca.Pages.Feedbacks
{
    public class IndexFeedbackModel : PageModel
    {
        private readonly IFeedback feedbackRepositorio;

        [BindProperty]
        public Feedback Feedback { get; set; }

        public IndexFeedbackModel(IFeedback feedback)
        {
            this.feedbackRepositorio = feedback;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            feedbackRepositorio.EnviarFeedback(Feedback);
            return RedirectToPage("./ComentariosEnviados");
        }
    }
}