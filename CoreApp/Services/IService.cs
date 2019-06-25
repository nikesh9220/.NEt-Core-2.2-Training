using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Services
{
    //Generic Interface
    //<TEntity> is Class Type
    //<TPK> Always Input Parameter
    public interface IService <TEntity,in TPK> where TEntity:class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TPK id,TEntity entity);
        Task<bool> DeleteAsync (TPK id);

    }
}
