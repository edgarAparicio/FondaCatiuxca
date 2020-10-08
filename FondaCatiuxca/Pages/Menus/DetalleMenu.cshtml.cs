using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using EdgarAparicio.FondaCatiuxca.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FondaCatiuxca.Pages.Menus
{
    public class DetalleMenuModel : PageModel
    {
        private readonly IMenu menuRepositorio;

        public Menu Menu { get; set; }

        public DetalleMenuModel(IMenu menu)
        {
            this.menuRepositorio = menu;
        }

        public ActionResult OnGet(int? idMenu)
        {
            if (idMenu.HasValue)
            {
                Menu = menuRepositorio.ObtenerMenuPorId(idMenu.Value);
            }
            else
            {
                Menu = new Menu();
            }
            if (Menu == null)
            {
                return RedirectToPage("./NoSeEncontro");
            }
            return Page();
        }
    }
}