using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace AXOLONCoreMVCv1.Models
{
    [Table("TBL_Employee")]
    public partial class TblEmployee
    {
        [Key]
        [Column("EmployeeID")]
        public int EmployeeId { get; set; }
        [StringLength(20)]
        public string EmployeeName { get; set; }
        [Column(TypeName = "date")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime? Entrydate { get; set; }
    }
}
