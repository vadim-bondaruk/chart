using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Infrastructure;
using Common.ViewModels;
using DAL.Repositories;

namespace Chart.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IRepositoryFactory repositoryFactory, IParabolicFunctionService service) : base(repositoryFactory, service)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetData(ParamViewModel model)
        {
            ICollection<CacheDataView> data = null;

            if(ParabolicFunctionService.CheckIfStored(model, out data))
            {
                return Json(data);
            }

           return Json( ParabolicFunctionService.CalculateChart(model));
        }


    }
}