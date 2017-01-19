using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.HomeViewModels
{
    public class ContactViewModel
    {

        [Required(ErrorMessage ="Please supply a name")]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

    }
}