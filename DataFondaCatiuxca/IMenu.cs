using EdgarAparicio.FondaCatiuxca.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.FondaCatiuxca.Data
{
    public interface IMenu
    {
        IEnumerable<Menu> ObtenerListaMenus();
    }
}
