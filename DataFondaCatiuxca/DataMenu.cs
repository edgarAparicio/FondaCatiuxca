using System;
using System.Collections.Generic;
using System.Text;
using EdgarAparicio.FondaCatiuxca.Business.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

        public Menu EditarMenu(Menu menuEditado)
        {
            var menu = db.Menu.Attach(menuEditado);
            menu.State = EntityState.Modified;
            return menuEditado;
        }

        public Menu ObtenerMenuPorId(int idMenu)
        {
            var menu = db.Menu.Find(idMenu);
            return menu;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
