using DioAppCadastroSeries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioAppCadastroSeries
{
    public class Serie : BaseEntity
    {
        private string titulo;
        private Genero genero;
        private string descricao;
        private int ano;
        private bool isDeleted;

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
        public void DeleteSerie()
        {
            isDeleted = true;
        }
        public void RestoreSerie()
        {
            isDeleted = false;
        }
        public string Titulo
        {
            get => titulo;
            set => titulo = value;
        }
        public Genero Genero
        {
            get => genero;
            set => genero = value;
        }
        public string Descricao
        {
            get => descricao;
            set => descricao = value;
        }
        public int Ano
        {
            get => ano;
            set
            {
                if (Ano > 1900)
                {
                    ano = value;
                }

            }
        }
        public int GetSerieId()
        {
            return id;
        }
    }
}
