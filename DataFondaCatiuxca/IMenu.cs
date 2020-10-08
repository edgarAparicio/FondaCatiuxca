using EdgarAparicio.FondaCatiuxca.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.FondaCatiuxca.Data
{
    public interface IMenu
    {
        IEnumerable<Menu> ObtenerListaMenus();
        Menu ObtenerMenuPorId(int idMenu);
        Menu EditarMenu(Menu menuEditado);
        int Commit();
        Menu ElimnarMenu(int idMenu);
        Menu AgregarMenu(Menu menuNuevo);
        IEnumerable<Menu> BuscarMenuPorNombre(string nombreMenu);
    }
}
