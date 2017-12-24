using Common.Models;
using DAL.Infrastructure;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class CacheDataRepository : BaseRepository<CacheData>, ICacheDataRepository
    {
        public CacheDataRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
