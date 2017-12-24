using DAL.Context;
using DAL.Infrastructure;
using DAL.Repositories;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using System.Data.Entity;

namespace DAL
{
    public class DefaultDalNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<ChartContext>();
            ConfigureRepositoryFactory();
        }

        protected virtual void ConfigureRepositoryFactory()
        {
            Bind<IParamRepository>()
                .To<ParamRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetParamRepository());
            Bind<ICacheDataRepository>()
                .To<CacheDataRepository>()
                .NamedLikeFactoryMethod((IRepositoryFactory f) => f.GetCacheDataRepository());


        }
    }
}
