using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioAppCadastroSeries
{
    public abstract class BaseEntity
    {
        protected int id;

        protected int Id
        {
            get => id;
            set => id = value;
        }
    }
}
