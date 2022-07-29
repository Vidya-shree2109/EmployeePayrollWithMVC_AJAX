using System;
using System.ComponentModel.DataAnnotations;

namespace AjaxEmployeePayrollMVC.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public string Profile_Image { get; set; }
        public DateTime StartDate { get; set; }
        public double Salary { get; set; }
        public string Notes { get; set; }
    }
}