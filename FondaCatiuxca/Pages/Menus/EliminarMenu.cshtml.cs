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
    public class EliminarMenuModel : PageModel
    {
        private readonly IMenu menuRepositorio;

        [BindProperty]
        public Menu Menu { get; set; }

        public EliminarMenuModel(IMenu menu)
        {
            this.menuRepositorio = menu;
        }

        public ActionResult OnGet(int idMenu)
        {
            Menu = menuRepositorio.ObtenerMenuPorId(idMenu);
            if (Menu == null)
            {
                return RedirectToPage("./NoSeEncontro");
            }
            return Page();
        }

        public ActionResult OnPost(int idMenu)
        {
            Menu = menuRepositorio.ElimnarMenu(idMenu);
            menuRepositorio.Commit();
            if(Menu== null)
            {
                return RedirectToPage("./NoSeEncontro");
            }
            return RedirectToPage("/Index");
        }
    }
}