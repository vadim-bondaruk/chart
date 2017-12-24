using Common.Models;
using DAL.Infrastructure;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class CacheDataRepository : BaseRepository<CaheData>, ICacheDataRepository
    {
        public CacheDataRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
