
using Microsoft.EntityFrameworkCore;
using Prodam.Core.Interfaces;
using Prodam.Data.Context;

namespace Prodam.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly EntitiesContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(EntitiesContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> FindById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task Delete(Guid id)
        {
            var model = await DbSet.FindAsync(id);
            DbSet.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Salvar as alterações no contexto
            int rowsAffected = await _context.SaveChangesAsync();

            // Verificar se houve alguma entidade afetada pelas alterações
            bool success = rowsAffected > 0;

            return success;
        }

    }
}
