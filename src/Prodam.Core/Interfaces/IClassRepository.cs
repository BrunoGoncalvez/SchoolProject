using Prodam.Core.Entities;

namespace Prodam.Core.Interfaces
{
    public interface IClassRepository : IRepository<Class>
    {

        Task<IEnumerable<Class>> GetClassesWithProfessor();

    }
}
