using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using EdgarAparicio.FondaCatiuxca.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FondaCatiuxcaMVC.Controllers
{
    public class FeedbackCon : Controller
    {
        private readonly IFeedback feedbackRepositorio;

        public FeedbackCon(IFeedback feedback)
        {
            feedbackRepositorio = feedback;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Feedback feedback)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            feedbackRepositorio.EnviarFeedback(feedback);
            return RedirectToAction("ComentariosEnviados");
        }

        public ActionResult ComentariosEnviados()
        {
            return View();
        }
    }
}
