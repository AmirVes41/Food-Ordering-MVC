using firstProj.DataAccess.Repository.IRepository;
using firstProj.Models;
using firstProj.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using firstProj.Utility;
using Microsoft.AspNetCore.Hosting;


namespace firstProject.Areas.Admin.Controllers
{
    [Area("admin")]
    public class OrderController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int orderId)
        {
            OrderVM orderVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderHeaderId == orderId, includeProperties: "Product")
            };

            return View(orderVM);
        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            return Json(new { data = objOrderHeaders });
        }


        #endregion
    }
}