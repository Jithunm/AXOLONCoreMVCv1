using AXOLONCoreMVCv1.Data;
using AXOLONCoreMVC.Managers;
using AXOLONCoreMVCv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXOLONCoreMVCv1.Repository
{
    public interface IDocumentRepository
    {
        List<TblDocumentDetail> GetDocuments();
        Task<string> InsertDocument(TblDocumentDetail model);
        Task<string> DeleteDocument(string empid);
        List<TblDocumentDetail> GetDocumentsByFilter(int filterId);
    }
    public class DocumentRepository : IDocumentRepository
    {
        AXOLON_DBContext context = new AXOLON_DBContext();
        MessageBox messageboxObj = new MessageBox();

        public List<TblDocumentDetail> GetDocumentsByFilter(int filterId)
        {
            var filterdeddata = context.TblDocumentDetails.Where(x => x.EmployeeId == filterId).ToList();
            return filterdeddata;
        }

        public List<TblDocumentDetail> GetDocuments()
        {
            var documentData = context.TblDocumentDetails.ToList();
            return documentData;
        }
        public async Task<string> InsertDocument(TblDocumentDetail model)
        {
            context.TblDocumentDetails.Add(model);
            await (context.SaveChangesAsync());
            return messageboxObj.successMessage1;
        }
        public async Task<string>DeleteDocument(string docid)
        {
            try
            {
                var dataset = context.TblDocumentDetails.Where(x => x.DocumentNumber == docid).FirstOrDefault();
                context.TblDocumentDetails.Remove(dataset);
                await (context.SaveChangesAsync());
            }
            catch (Exception)
            {
                return messageboxObj.deleteError;
            }
            return messageboxObj.deleteSuccess;
        }


    }
}
