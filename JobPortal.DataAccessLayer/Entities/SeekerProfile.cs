using JobPortal.DataAccessLayer.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Entities
{
    public class SeekerProfile : BaseEntity
    {
        public string? Name { get; set; }

        public string? Education { get; set; }

        public string? skills { get; set; }

        public string? Achievements { get; set; }

        public string? PortfolioLink { get; set; }

        public string? GitHubLink { get; set; }

        public ApplicationUser? User { get; set; }
        
        public Guid UserId { get; set; }

        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
