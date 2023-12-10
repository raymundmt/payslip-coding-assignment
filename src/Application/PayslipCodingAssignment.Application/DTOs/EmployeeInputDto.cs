using System.ComponentModel.DataAnnotations;

namespace PayslipCodingAssignment.Application.DTOs
{
    public class EmployeeInputDto
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Annual salary must be a positive number.")]
        public decimal AnnualSalary { get; set; }

        [Range(0, 50, ErrorMessage = "Super rate must be between 0% and 50%.")]
        public decimal SuperRate { get; set; }

        [Required(ErrorMessage = "Pay period is required.")]
        public string PayPeriod { get; set; }
    }
}
