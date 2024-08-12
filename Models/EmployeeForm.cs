using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeForm
    {
        [Required]
        [Display(Name = "รหัสบัตรประชาชน")]
        public string CitizenId { get; set; }

        [Required]
        [Display(Name = "รหัสพนักงาน")]
        public string EmployeeId { get; set; }

        [Required]
        [Display(Name = "ชื่อจริง")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "นามสกุล")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "เพศ")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "วันเดือนปีเกิด")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
