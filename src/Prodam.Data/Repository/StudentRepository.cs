using Prodam.Core.Entities;
using Prodam.Core.Interfaces;
using Prodam.Data.Context;

namespace Prodam.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        public StudentRepository(EntitiesContext context) : base(context)
        {
        }

    }
}
