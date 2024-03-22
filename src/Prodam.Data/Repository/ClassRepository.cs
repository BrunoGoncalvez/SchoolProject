
using Prodam.Core.Entities;
using Prodam.Core.Interfaces;
using Prodam.Data.Context;

namespace Prodam.Data.Repository
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {

        public ClassRepository(EntitiesContext context) : base(context) { }

    }
}
