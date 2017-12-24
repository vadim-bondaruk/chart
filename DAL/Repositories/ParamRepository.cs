using Common.Models;
using DAL.Infrastructure;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ParamRepository : BaseRepository<Param>, IParamRepository
    {
        public ParamRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
