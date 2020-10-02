using EdgarAparicio.FondaCatiuxca.Business.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.FondaCatiuxca.Data
{
    public class DbContextFondaCatiuxca : DbContext
    {
        public DbContextFondaCatiuxca(DbContextOptions<DbContextFondaCatiuxca> options) : base(options)
        {

        }

        public DbSet<Menu> Menu { get; set; }

    }
}
