using firstProj.Models;
using firstProj.Models.ViewModels;
using firstProject.DataAccess.Data;
using firstProj.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using firstProj.Utility;


namespace firstProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {

        //dependensy injection
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            //_db = db;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // List<Category> objCategoryList = _db.Categories.ToList();
            // List<Category> objcategoryList = new List<Category> ();
            // objcategoryList = _db.MyProperty.ToList (); 
            //return View(objcategoryList);
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }


        // to add new item
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "هر دو مقدار نمیتواند یکسان باشد");
            }
            /*
            if (!(obj.Name == null))
            {
                ModelState.AddModelError("", "این فیلد نمیتواند خالی باشد.");
            }
            */
            if (ModelState.IsValid)
            {
                //_db.Categories.Add(obj);
                //_db.SaveChanges();
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "دسته بندی جدید با موفقیت ایجاد شد.";
                return RedirectToAction("Index");
            }
            return View();

        }
        // to edit item
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Category? categoryFromDb = _db.Categories.Find(id);
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id==id);
            //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]

        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "هر دو مقدار نمیتواند یکسان باشد");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "دسته بندی با موفقیت ویرایش شد.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //to delete
        //to select data
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);


            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //to do the delete action
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);

            if (obj == null) { return NotFound(); }

            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "دسته بندی باموفقیت حذف شد.";
            return RedirectToAction("Index");

        }
    }
}
