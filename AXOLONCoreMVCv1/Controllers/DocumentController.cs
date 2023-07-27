using AXOLONCoreMVCv1.Managers;

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

        MessageBox _messageObj;
        private AXOLON_DBContext _context;

        public DocumentController(IDocumentRepository docRepo,AXOLON_DBContext context,MessageBox messageBox)
        {
            _empRepo = docRepo;
            _context = context;
            _messageObj = messageBox;

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

                return RedirectToAction("DocumentIndex", TempData["Message"] = _messageObj.insertError);

            }

        }
        public async Task<ActionResult> DocumentDelete(string docid)
        {

            return RedirectToAction("DocumentIndex", TempData["Message"] = await _empRepo.DeleteDocument(docid));
        }

       
    }
}
