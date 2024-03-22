using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodam.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> FindAll();

        Task<TEntity> FindById(Guid id);

        Task<bool> SaveChangesAsync();

    }
}
