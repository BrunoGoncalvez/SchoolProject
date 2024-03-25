using Microsoft.EntityFrameworkCore;
using Prodam.Core.Entities;
using Prodam.Core.Interfaces;
using Prodam.Data.Context;

namespace Prodam.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {

        private readonly EntitiesContext _entitiesContext;

        public StudentRepository(EntitiesContext context) : base(context)
        {
            _entitiesContext = context;
        }


        public async Task<IEnumerable<Student>> GetStudentsWithClass()
        {
            IQueryable<Student> query = this._entitiesContext.Students.Include(s => s.Class);
            return await query.ToListAsync();
        }


    }
}
