using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using EdgarAparicio.FondaCatiuxca.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FondaCatiuxca.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMenu menuReposito;
        public IEnumerable<Menu> Menus { get; set; }

        public IndexModel(IMenu menu)
        {
            this.menuReposito = menu;
        }

        public void OnGet()
        {
            Menus = menuReposito.ObtenerListaMenus();
        }
    }
}