using Prodam.Core.Entities;

namespace Prodam.Core.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {

        Task<IEnumerable<Student>> GetStudentsWithClass();

    }
}
