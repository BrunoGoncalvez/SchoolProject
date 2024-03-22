
using Prodam.Core.Entities;
using Prodam.Core.Interfaces;
using Prodam.Data.Context;

namespace Prodam.Data.Repository
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {

        public ProfessorRepository(EntitiesContext context) : base(context) { }

    }
}
