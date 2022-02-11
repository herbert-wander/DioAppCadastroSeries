using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioAppCadastroSeries.Models
{
    public abstract class Cinema : BaseEntity
    {
        protected string titulo;
        protected Genero genero;
        protected string descricao;
        protected int ano;
        protected bool isDeleted;
        public void DeleteCinemaContent()
        {
            isDeleted = true;
        }
        public void RestoreCinemaContent()
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

        public bool IsDeleted
        {
            get => isDeleted;
            set => isDeleted = value;
        }

        public int GetCinemaContentId()
        {
            return id;
        }
    }
}
