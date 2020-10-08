using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using EdgarAparicio.FondaCatiuxca.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FondaCatiuxca.Pages.Menus
{
    public class EditarMenuModel : PageModel
    {
        private readonly IMenu menuRepositorio;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty] //Permite almacenar valores de entrada y de salida
        public Menu Menu { get; set; }

        public IEnumerable<SelectListItem> TipoComidaSelectList { get; set; }

        public EditarMenuModel(IMenu menu, IHtmlHelper htmlH)
        {
            this.menuRepositorio = menu;
            this.htmlHelper = htmlH;
        }

        public ActionResult OnGet(int? idMenu)
        {
            TipoComidaSelectList = htmlHelper.GetEnumSelectList<TipoComida>();
            if (idMenu.HasValue)
            {
                Menu = menuRepositorio.ObtenerMenuPorId(idMenu.Value);
            }
            else
            {
                Menu = new Menu();
            }
            if(Menu == null)
            {
                return RedirectToAction("./NoSeEncontro");
            }
            return Page();
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TipoComidaSelectList = htmlHelper.GetEnumSelectList<TipoComida>();
                return Page();
            }
            if(Menu.Id > 0)
            {
                menuRepositorio.EditarMenu(Menu);
            }
            else
            {
                menuRepositorio.AgregarMenu(Menu);
            }
            menuRepositorio.Commit();
            return RedirectToPage("/Index");
        }
    }
}