using System.Web.Mvc;
using MvcProject.Data.UnitOfWork;
 
namespace MvcProject.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork uow)
            : base(uow)
        {
 
        }
 
        public ActionResult Index()
        {
            return View();
        }
 
    }
}