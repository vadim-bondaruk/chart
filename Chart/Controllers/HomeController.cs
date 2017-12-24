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

        public ActionResult GetData(ParamViewModel model)
        {
           return Json( ParabolicFunctionService.CalculateChart(model));
        }


    }
}