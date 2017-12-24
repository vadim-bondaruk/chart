using BLL.Infrastructure;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chart.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IRepositoryFactory RepositoryFactory;
        protected readonly IParabolicFunctionService ParabolicFunctionService;

        public BaseController(IRepositoryFactory repositoryFactory, IParabolicFunctionService service)
        {
            RepositoryFactory = repositoryFactory;
            ParabolicFunctionService = service;
        }
    }
}