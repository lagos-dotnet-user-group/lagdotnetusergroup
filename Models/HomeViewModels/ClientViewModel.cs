using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.HomeViewModels
{
    public class ClientViewModel
    {

        [Required(ErrorMessage ="Please supply a name")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Compare("Email", ErrorMessage = "your email address and confirmation email address do not match.")]
        public string ConfirmEmail { get; set; }

        public string Subject { get; set; }

        public string Budget { get; set; }

        [Required]
        public string ProjectDescription { get; set; }

    }
}