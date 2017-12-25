using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (ModelState.IsValid)
            {
                ICollection<CacheDataView> data = null;

                if (ParabolicFunctionService.CheckIfStored(model, out data))
                {
                    return Json(data);
                }
                data = ParabolicFunctionService.CalculateChart(model);
                return Json(new { data, IsError = false });
            }

            else
            {
                var errors = ModelState.Values.Select(v => v.Errors.Select(e => e.ErrorMessage));
                return Json(new { errors, IsError = true });
            }
        }




    }
}