using System.Web.Mvc;
using MvcProject.Data.UnitOfWork;

namespace MvcProject.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _uow;

        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}