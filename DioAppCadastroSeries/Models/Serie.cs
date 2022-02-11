using DioAppCadastroSeries;
using DioAppCadastroSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioAppCadastroSeries
{
    public class Serie : Cinema
    {
        private int episodes;
        private string channelOfExibition;
        public Serie(int idP, string tituloP, Genero generoP, string descricaoP, int anoP)
        {
            this.Id = idP;
            this.Titulo = tituloP;
            this.Genero = generoP;
            this.Descricao = descricaoP;
            this.Ano = anoP;
            this.isDeleted = false;

        }
        public override string ToString()
        {
            string newToString = "";

            newToString +="Gênero: "+genero+Environment.NewLine;
            newToString += "Título: "+titulo+Environment.NewLine;
            newToString += "Descrição: "+descricao+Environment.NewLine;
            newToString += "Ano de Inicio: "+ano+Environment.NewLine;

            return newToString;
        }
        
    }
}
