using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public DateTime SubscribeDate { get; set; }

    }
}