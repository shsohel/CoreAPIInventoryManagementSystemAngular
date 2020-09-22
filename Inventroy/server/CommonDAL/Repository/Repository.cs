using CommonDAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDAL.Repository
{
    public class Repository<EntityName> : IRepository<EntityName> where EntityName : class
    {
        private readonly OnlineContextDb dbContext;

        public Repository(OnlineContextDb dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<EntityName> AddAsync(EntityName model)
        {
            await dbContext.Set<EntityName>().AddAsync(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<EntityName>> AddRangeAsync(List<EntityName> model)
        {
            await dbContext.AddRangeAsync(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<EntityName> DeleteAsync(Object id)
        {
            EntityName entity = await dbContext.Set<EntityName>().FindAsync(id);
            dbContext.Set<EntityName>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EntityName> DeleteAsync(EntityName model)
        {
            dbContext.Set<EntityName>().Remove(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<EntityName>> DeleteRangeAsync(List<EntityName> models)
        {
            dbContext.Set<EntityName>().RemoveRange(models);
            await dbContext.SaveChangesAsync();
            return models;
        }

        public async Task<IEnumerable<EntityName>> GetAsync()
        {
            return await dbContext.Set<EntityName>().AsNoTracking().ToListAsync();
        }

        public async Task<EntityName> GetAsync(Object id)
        {
            return await dbContext.Set<EntityName>().FindAsync(id);
        }

        public async Task<EntityName> UpdateAsync(EntityName model)
        {
            dbContext.Set<EntityName>().Update(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<EntityName>> UpdateRangeAsync(List<EntityName> model)
        {
            dbContext.Set<EntityName>().UpdateRange(model);
            await dbContext.SaveChangesAsync();
            return model;

        }
    }
}
