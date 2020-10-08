using EdgarAparicio.FondaCatiuxca.Business.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgarAparicio.FondaCatiuxca.Data
{
    public interface IFeedback
    {
        void EnviarFeedback(Feedback feedback);
    }
}
