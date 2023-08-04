using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Entities
{
    public class Catagory : BaseEntity
    {
       [Required(ErrorMessage ="Enter Catagory Name")]
       [Display(Name ="CatagoryName")]
       public string? Name { get; set; }
       
       List<Job> jobs { get; set; }

    }
}
