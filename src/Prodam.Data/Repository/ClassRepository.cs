
using Microsoft.EntityFrameworkCore;
using Prodam.Core.Entities;
using Prodam.Core.Interfaces;
using Prodam.Data.Context;

namespace Prodam.Data.Repository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public ClassRepository(EntitiesContext context) : base(context) 
        {
            this._entitiesContext = context;
        }

        public async Task<IEnumerable<Class>> GetClassesWithProfessor()
        {
            IQueryable<Class> query = this._entitiesContext.Classes.Include(s => s.Professor);
            return await query.ToListAsync();
        }
    }
}
