using AXOLONCoreMVCv1.Data;
using AXOLONCoreMVCv1.Managers;
using AXOLONCoreMVCv1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AXOLONCoreMVCv1.Repository;
using System.Data.Entity.Infrastructure;

namespace AXOLONCoreMVC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository _empRepo;

        DateTime date = new DateTime();
        Guid obj = Guid.NewGuid();
        MessageBox messageObj = new MessageBox();

        public EmployeeController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        

        }

        [HttpGet]
        public ActionResult Index()
        {

            List<TblEmployee> employeeData =  _empRepo.GetEmployees();

            return View(employeeData);


         
        }
        [HttpGet]

        public ActionResult EmployeeInsert()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> EmployeeInsert(TblEmployee model, int tempid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index", TempData["Message"] = await _empRepo.InsertEmployee(model));
                }
                else
                {
                    
                    return View();
                }
            }
            catch (Exception ex)
            {
                
                return RedirectToAction("Index", TempData["Message"] = messageObj.insertError);

            }

        }
        public async Task<ActionResult> EmployeeDelete(int empid)
        {
            
            return RedirectToAction("Index", TempData["Message"] = await _empRepo.DeleteEmployee(empid));
        }
    }
}
