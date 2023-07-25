using AXOLONCoreMVC.Managers;

using AXOLONCoreMVCv1.Repository;
using AXOLONCoreMVCv1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Dynamic;
using AXOLONCoreMVCv1.Data;
using System.Linq;
using System.IO;
using Grpc.Core;

namespace AXOLONCoreMVCv1.Controllers
{
    public class DocumentController : Controller
    {

        private readonly IDocumentRepository _empRepo;

        MessageBox messageObj = new MessageBox();
        private AXOLON_DBContext _context = new AXOLON_DBContext();

        public DocumentController(IDocumentRepository docRepo)
        {
            _empRepo = docRepo;
        }
        [HttpGet]
        public IActionResult DocumentIndex()
        {

            List<TblDocumentDetail> documentData= _empRepo.GetDocuments();
            ViewBag.employeeData = _context.TblEmployees.ToList();
            return View(documentData);

        }
        [HttpPost]
        public IActionResult DocumentIndex(int EmployeeId)
            {

            List<TblDocumentDetail> documentData = _empRepo.GetDocumentsByFilter(EmployeeId);

            ViewBag.employeeData = _context.TblEmployees.ToList();
            return View(documentData);
        }

        [HttpGet]

        public ActionResult DocumentInsert()
        {
            ViewBag.employeeData = _context.TblEmployees.ToList();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> DocumentInsert(TblDocumentDetail model, int tempid)
        {
            try
            {
                if (ModelState.IsValid)
                {



                    return RedirectToAction("DocumentIndex", TempData["Message"] = await _empRepo.InsertDocument(model));
                }
                else
                {

                    return View();
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("DocumentIndex", TempData["Message"] = messageObj.insertError);

            }

        }
        public async Task<ActionResult> DocumentDelete(string docid)
        {

            return RedirectToAction("DocumentIndex", TempData["Message"] = await _empRepo.DeleteDocument(docid));
        }

       
    }
}
