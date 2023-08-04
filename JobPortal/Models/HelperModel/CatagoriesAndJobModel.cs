using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.CatagoryView;
using JobPortal.DataAccessLayer.ViewModel.JobView;

namespace JobPortal.PresentationLayer.Models.HelperModel
{
    public class CatagoriesAndJobModel
    {
        public List<CatagoryViewModel>? catagories { get; set; }

        public List<JobViewModel>? jobs { get; set; }

        public CatagoriesAndJobModel(List<CatagoryViewModel>? catagories , List<JobViewModel>? jobs)
        {
            this.catagories = catagories;
            this.jobs = jobs;
        }
    }
}
