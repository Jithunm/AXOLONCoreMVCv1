using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AXOLONCoreMVCv1.Models
{
    [Table("TBL_Document_Details")]
    public partial class TblDocumentDetail
    {
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [Column("Document_Type")]
        [StringLength(10)]
        public string DocumentType { get; set; }
        [Key]
        [Column("Document_Number")]
        [StringLength(10)]
        public string DocumentNumber { get; set; }
        [Column("Issue Date", TypeName = "datetime")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? IssueDate { get; set; }
        [Column("Issue Place")]
        [StringLength(10)]
        public string IssuePlace { get; set; }
        [Column("Expiry Date", TypeName = "datetime")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }
        [StringLength(10)]
        public string Remarks { get; set; }
        [StringLength(10)]
        public string Attachment { get; set; }
    }
}
