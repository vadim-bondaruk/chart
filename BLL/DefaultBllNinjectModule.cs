using BLL.Infrastructure;
using BLL.Services;
using DAL;
using Ninject;
using Ninject.Modules;
using System;

namespace BLL
{
    public class DefaultBllNinjectModule : NinjectModule
    {
        public override void Load()
        {
            if (Kernel != null)
            {
                Kernel.Load(new DefaultDalNinjectModule());
            }

            Bind<IParabolicFunctionService>().To<ParabolicFunctionService>();
        }
    }
}
