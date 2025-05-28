using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper.Result;

namespace ServiceHelper.Abstract
{
    public interface IService<T, DTO>where T : class where DTO : class
    {
        Task<Result<List<DTO>>> List();
        Task<Result<DTO>> GetById(int id);
        Task<Result<bool>> Insert(DTO entity);
        Task<Result<bool>> Update(DTO entity);
        Task<Result<bool>> Delete(int id);
        Task<Result<bool>> status(int id);
    }
}
