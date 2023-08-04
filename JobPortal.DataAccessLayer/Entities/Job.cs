using JobPortal.DataAccessLayer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Entities
{
    public class Job : BaseEntity
    {

        [Required(ErrorMessage ="Title Required")]
        [MinLength(5)]
        [MaxLength(150)]
        public String JobTitle { get; set; }

        [Required(ErrorMessage ="Number Of Vacency Required")]
        public int NumberOfVacency { get; set; }

        [Required(ErrorMessage ="Company Name Required")]
        public string CompanyName { get; set; } = String.Empty;

        [Required(ErrorMessage ="Email Required")]
        [EmailAddress(ErrorMessage ="Email Not in Valid Format")]
        public string HREmail { get; set; } = String.Empty;

        [Required(ErrorMessage ="description Required")]
        [MinLength(20)]
        public string JobResponsibilities { get; set; } = String.Empty;

        public string EmployeeStatus { get; set; }

        public string EducationalRequirements { get; set; }

        public string ExperienceRequirement { get; set; }

        public string AdditionalRequirements { get; set; }

        public string JobLocation { get; set; }

        public string Salary { get; set; }

        public string OthersBenefit { get; set; }

        [Required(ErrorMessage ="Due Date Required")]
        public DateTime LastDateOfApplication { get; set; }

        public Guid CatagoryId { get; set; }

        public  Catagory? Catagory { get; set; }

        public Guid UserId { get; set; }

        public virtual ApplicationUser? User { get; set; }

        


    }
}
