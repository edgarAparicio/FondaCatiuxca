using System;
using System.Collections.Generic;
using System.Text;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using System.Linq;

namespace EdgarAparicio.FondaCatiuxca.Data
{
    public class DataMenu : IMenu
    {

        private readonly DbContextFondaCatiuxca db;

        public DataMenu(DbContextFondaCatiuxca dbContextFondaCatiuxca)
        {
            this.db = dbContextFondaCatiuxca;
        }

        public IEnumerable<Menu> ObtenerListaMenus()
        {
            return from menu in db.Menu
                   orderby menu.Nombre
                   select menu;
        }
    }
}
