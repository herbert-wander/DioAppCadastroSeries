using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioAppCadastroSeries.Models
{
    class Movie : Cinema
    {
        public Movie(int idP, string tituloP, Genero generoP, string descricaoP, int anoP)
        {
            this.Id = idP;
            this.Titulo = tituloP;
            this.Genero = generoP;
            this.Descricao = descricaoP;
            this.Ano = anoP;
            this.isDeleted = false;

        }
    }
}
