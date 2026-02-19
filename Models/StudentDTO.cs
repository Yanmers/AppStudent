using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppStudent.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]

        public string Name { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Email is Required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; } = string.Empty;

        public DateTime DBO { get; set; }
    }
}
