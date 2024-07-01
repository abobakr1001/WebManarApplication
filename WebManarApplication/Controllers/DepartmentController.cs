using CompanyG02.BLL.Interfaces;
using CompanyG02.BLL.Repositios;
using CompanyG02.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Threading.Tasks;

namespace WebManarApplication.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        //private IdepartmentRepository departmentRepository;

        public IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            //this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var department = await unitOfWork.DepartmentRepository.GetAll();
            return View(department);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create( Deaprtment deaprtment)
        {
            if (ModelState.IsValid)
            {
                          await  unitOfWork.DepartmentRepository.Add(deaprtment);
                var resut = await unitOfWork.Complelete();
                if (resut > 0)
                {
                    TempData["Message"] = "created department";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deaprtment);
        }
        public async Task<IActionResult> Details(int? id,string viewname = "Details")
        {
            if (id is null)
            {
                BadRequest();
            }
            var department = await unitOfWork.DepartmentRepository.Get(id.Value);
            if (department is null)
                return NotFound();
            return View(viewname, department);
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int? id)
        {
            return await Details(id, "edit");
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
        public async Task<IActionResult> Edit([FromRoute]int? id,Deaprtment deaprtment)
        {
            if (id != deaprtment.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.DepartmentRepository.Update(deaprtment);
                    await unitOfWork.Complelete();
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
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute]int? id,Deaprtment deaprtment)
        {
            if (id != deaprtment.Id)
                return BadRequest();
            try
            {
                unitOfWork.DepartmentRepository.Delete(deaprtment);
                await unitOfWork.Complelete();
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
