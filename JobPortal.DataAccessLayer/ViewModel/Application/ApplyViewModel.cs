using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.ViewModel.Application
{
    public class ApplyViewModel
    {
        public string JobTitle { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="should be a email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Length Must Be 11")]
        [MaxLength(11), MinLength(11)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Location Required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Degree Required")]
        public string LastDegree { get; set; }

        [Required(ErrorMessage = "Minimum length should be 50")]
        [MinLength(50)]
        public string SelfSummary { get; set; }

        public Guid JobId { get; set; }

        public Guid UserId  { get; set; }

        [Required]
        public IFormFile CV { get; set; }

        public string? UrlOfCV { get; set; }
    }
}
