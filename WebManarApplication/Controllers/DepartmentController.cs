using CompanyG02.BLL.Interfaces;
using CompanyG02.BLL.Repositios;
using CompanyG02.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebManarApplication.Controllers
{
    public class DepartmentController : Controller
    {
        //private IdepartmentRepository departmentRepository;

        public IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            //this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var department = unitOfWork.DepartmentRepository.GetAll();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create( Deaprtment deaprtment)
        {
            if (ModelState.IsValid)
            {
                            unitOfWork.DepartmentRepository.Add(deaprtment);
                var resut = unitOfWork.Complelete();
                if (resut > 0)
                {
                    TempData["Message"] = "created department";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deaprtment);
        }
        public IActionResult Details(int? id,string viewname = "Details")
        {
            if (id is null)
            {
                BadRequest();
            }
            var department = unitOfWork.DepartmentRepository.Get(id.Value);
            if (department is null)
                return NotFound();
            return View(viewname, department);
        }

        [HttpGet]
        public IActionResult Edit (int? id)
        {
            return Details(id, "edit");
            //if (id is null)
            //{
            //    BadRequest();
            //}
            //var department = departmentRepository.Get(id.Value);
            //if (department is null)
            //    return NotFound();
            //return View(department);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id,Deaprtment deaprtment)
        {
            if (id != deaprtment.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.DepartmentRepository.Update(deaprtment);
                    unitOfWork.Complelete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                
            }
            return View(deaprtment);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int? id,Deaprtment deaprtment)
        {
            if (id != deaprtment.Id)
                return BadRequest();
            try
            {
                unitOfWork.DepartmentRepository.Delete(deaprtment);
                unitOfWork.Complelete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                return View(deaprtment);
            }
          
        }

    }
}
