using JobPortal.DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;

namespace JobPortal.DataAccessLayer.ViewModel.JobView
{
    public  class JobViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title Required")]
        [MinLength(5)]
        [MaxLength(250)]
        public String JobTitle { get; set; } = String.Empty;

        [Required(ErrorMessage = "Number Of Vacency Required")]
        public int NumberOfVacency { get; set; }

        [Required(ErrorMessage = "Company Name Required")]
        public string CompanyName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Email Not in Valid Format")]
        public string HREmail { get; set; } = String.Empty;

        [Required(ErrorMessage = "description Required")]
        [MinLength(20)]
        public string JobResponsibilities { get; set; } = String.Empty;

        [Required(ErrorMessage = "Employee Status Required")]
        public string EmployeeStatus { get; set; }
        [Required(ErrorMessage = "description Required")]
        public string EducationalRequirements { get; set; }
        [Required(ErrorMessage = "description Required")]
        public string ExperienceRequirement { get; set; }
        [Required(ErrorMessage = "description Required")]
        public string AdditionalRequirements { get; set; }
        [Required(ErrorMessage = "description Required")]
        public string JobLocation { get; set; }
        [Required(ErrorMessage = "description Required")]
        public string Salary { get; set; }
        [Required(ErrorMessage = "description Required")]
        public string OthersBenefit { get; set; }

        [Required(ErrorMessage = "Due Date Required")]
        public DateTime LastDateOfApplication { get; set; }

        public Guid CatagoryId { get; set; }

        public Guid UserId { get; set; }

        public List<SelectListItem>? catagories { get; set; }   
        

        

       
    }
}
