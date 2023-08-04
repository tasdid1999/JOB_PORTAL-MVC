using JobPortal.DataAccessLayer.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Entities
{
    public class Apply : BaseEntity
    {
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(11),MinLength(11)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string LastDegree { get; set; }

        [Required]
        [MinLength(50)]
        public string SelfSummary { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser? User { get; set; }

        public Guid JobId { get; set; }

        public virtual Job? Job { get; set; }

       public string? UrlOfCV { get; set; }


    }
}
