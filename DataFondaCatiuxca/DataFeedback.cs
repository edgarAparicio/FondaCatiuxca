using System;
using System.Collections.Generic;
using System.Text;
using EdgarAparicio.FondaCatiuxca.Business.Entity;

namespace EdgarAparicio.FondaCatiuxca.Data
{
    public class DataFeedback : IFeedback
    {
        private readonly DbContextFondaCatiuxca db;

        public DataFeedback(DbContextFondaCatiuxca dbContextFondaCatiuxca)
        {
            this.db = dbContextFondaCatiuxca;
        }

        public void EnviarFeedback(Feedback feedback)
        {
            db.Feedback.Add(feedback);
            db.SaveChanges();
        }
    }
}
