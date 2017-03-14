using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

    }
}