using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioAppCadastroSeries.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetSerieList();

        T GetSerieById(int idP);
        void Insert(T newEntityP);
        void DeleteById(int idP);
        void UpdateById(int idP, T newEntityP);
        int GetNextID();
    }
}
