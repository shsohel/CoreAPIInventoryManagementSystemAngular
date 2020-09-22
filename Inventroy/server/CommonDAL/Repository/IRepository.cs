using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonDAL.Repository
{
    public interface IRepository<EntityType> where EntityType: class
    {
        Task<IEnumerable<EntityType>> GetAsync();
        Task<EntityType> GetAsync(Object id);
        Task<EntityType> AddAsync(EntityType model);
        Task<List<EntityType>> AddRangeAsync(List<EntityType> model);
        Task<EntityType> UpdateAsync(EntityType model);
        Task<List<EntityType>> UpdateRangeAsync(List<EntityType> model);
        Task<EntityType> DeleteAsync(Object id);
        Task<List<EntityType>> DeleteRangeAsync(List<EntityType> models);
        Task<EntityType> DeleteAsync(EntityType model);
    }
}
