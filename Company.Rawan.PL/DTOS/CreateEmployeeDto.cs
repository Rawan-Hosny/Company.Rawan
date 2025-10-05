using System.ComponentModel.DataAnnotations;
namespace Company.Rawan.PL.DTOS
   
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]

        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "Salary is required")]

        public decimal Salary { get; set; }
        [Required(ErrorMessage = "IsActive is required")]

        public bool IsActive { get; set; }
        [Required(ErrorMessage = "IsDeleted is required")]

        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "Hiring Date is required")]

        public DateTime HiringDate { get; set; }
        [Required(ErrorMessage = "Create Date is required")]

        public DateTime CreateAt { get; set; }
    }
}
