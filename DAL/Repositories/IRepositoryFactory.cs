using DAL.Infrastructure;

namespace DAL.Repositories
{
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Returns the param repository.
        /// </summary>
        /// <returns>
        /// The param repository.
        /// </returns>
        IParamRepository GetParamRepository();

        /// <summary>
        /// Returns the cache data repository.
        /// </summary>
        /// <returns>
        /// The cache data repository.
        /// </returns>
        ICacheDataRepository GetCacheDataRepository();
    }
}
