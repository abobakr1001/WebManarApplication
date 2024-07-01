using AutoMapper;
using CompanyG02.BLL.Interfaces;
using CompanyG02.BLL.Repositios;
using CompanyG02.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebManarApplication.Helpers;
using WebManarApplication.Models;

namespace WebManarApplication.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {

        //private readonly IEmployeeRepository employeeRepository;
        //private readonly IdepartmentRepository departmentRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            //this.employeeRepository = employeeRepository;
            //this.departmentRepository = departmentRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult>  Index( string searchName)
        {
            IEnumerable<Employee> employees;
            if (string.IsNullOrEmpty(searchName))
             employees = await unitOfWork.EmployeeRepository.GetAll();
            else
                employees = unitOfWork.EmployeeRepository.GetEmployeesByName(searchName);
           
            var Mappedemp = mapper.Map<IEnumerable< Employee>,IEnumerable<EmployeeViewModel>>(employees);
            return View(Mappedemp);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>  Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                var Mappedemp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                if (employeeVM.ImageName is not null)
                {
                  Mappedemp.ImageName = DocumentSettings.UploadImage(employeeVM.Image, "Images");
                }

                await unitOfWork.EmployeeRepository.Add(Mappedemp);
                int result = await unitOfWork.Complelete();
                if (result > 0)
                {
                    TempData["Message"] = "employee is Craeted";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVM);
        }
        public async Task<IActionResult>  Details(int? id, string viewname = "Details")
        {
            if (id is null)
            {
                BadRequest();
            }
            var employee = await unitOfWork.EmployeeRepository.Get(id.Value);
            if (employee is null)
                return NotFound();
            var Mappedemp = mapper.Map<Employee,EmployeeViewModel>(employee);
            return View(viewname, Mappedemp);
        }

        [HttpGet]
        public async Task<IActionResult>  Edit(int? id)
        {
            ViewBag.Departments = unitOfWork.DepartmentRepository.GetAll();
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
        public async Task<IActionResult>  Edit([FromRoute] int? id, EmployeeViewModel employee )
        {
            if (id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var Mappedemp = mapper.Map<EmployeeViewModel, Employee>(employee);
                    unitOfWork.EmployeeRepository.Update(Mappedemp);
                   await unitOfWork.Complelete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(employee);
        }


        [HttpGet]
        public async Task<IActionResult>  Delete(int? id)
        {
            return await Details(id,  "Delete");
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
        public async Task<IActionResult>  Delete([FromRoute] int? id, EmployeeViewModel employeeVM)
        {
            if (id != employeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var Mappedemp = mapper.Map<EmployeeViewModel, Employee>(employeeVM);

                    if (employeeVM.ImageName is not null)
                    {
                        DocumentSettings.DeleteFile(Mappedemp.ImageName, "Images");
                    }
                    unitOfWork.EmployeeRepository.Delete(Mappedemp);
                   await  unitOfWork.Complelete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }
            return View(employeeVM);
        }
    }
}
