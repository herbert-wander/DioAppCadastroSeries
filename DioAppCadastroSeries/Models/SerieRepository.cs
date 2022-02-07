using DioAppCadastroSeries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioAppCadastroSeries
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> seriesList = new List<Serie>();
        public void DeleteById(int idP)
        {
            seriesList[idP].DeleteSerie();
        }

        public Serie GetSerieById(int idP)
        {
            return seriesList[idP];
        }

        public int GetNextID()
        {
            return seriesList.Count;
        }

        public void Insert(Serie newEntityP)
        {
            seriesList.Add(newEntityP);
        }

        public List<Serie> GetSerieList()
        {
            return seriesList;
        }

        public void UpdateById(int idP, Serie newEntityP)
        {
            seriesList[idP] = newEntityP;
        }

        public void PrintListAllGenres()
        {
            foreach (var item in Enum.GetNames(typeof(Genero)))
            {
                Console.WriteLine("Genero: {0}, Opção: {1}",item, (int)Enum.Parse(typeof(Genero),item));
            }
        }
    }
}
