using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> List();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Status(int id);
    }
}
