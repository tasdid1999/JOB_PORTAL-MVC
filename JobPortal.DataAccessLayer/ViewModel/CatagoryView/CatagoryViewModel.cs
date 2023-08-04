using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.DataAccessLayer.Entities;


namespace JobPortal.DataAccessLayer.ViewModel.CatagoryView
{
    public class CatagoryViewModel
    {
        public Guid CatagoryId { get; set; }
        [Required]
        [MaxLength(150)]
        public string? CatagoryName { get; set; }    

      
    }
}
