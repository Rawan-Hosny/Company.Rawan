using System.ComponentModel.DataAnnotations;
namespace Company.Rawan.PL.DTOS
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Create Date is required")]
        public DateTime CreateAt { get; set; }
    }
}
