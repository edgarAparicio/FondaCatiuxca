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
        private readonly IMenu menuRepositorio;
        public IEnumerable<Menu> Menus { get; set; }

        [BindProperty(SupportsGet = true)] //Almacena los valores desde aqui para no recibirlos en el metodo 
        public string NombreMenu { get; set; }

        public IndexModel(IMenu menu)
        {
            this.menuRepositorio = menu;
        }

        public void OnGet()
        {
            Menus = menuRepositorio.ObtenerListaMenus();
            Menus = menuRepositorio.BuscarMenuPorNombre(NombreMenu);
        }
    }
}