using JobPortal.DataAccessLayer.ViewModel.JobView;
using JobPortal.PresentationLayer.Models.HelperModel;

namespace JobPortal.PresentationLayer.Models.HelperModel
{
    public class Pagination
    {
        public int page { get; set; }

        public int pageSize { get; set; } = 2;

        public int totalPage { get; set; }

        public List<JobViewModel>? listOfJobs { get; set; }

        public CatagoriesAndJobModel? catagoryandjob { get; set; }

        public Guid?  CatagoryId { get; set; }

        public Pagination(int page , List<JobViewModel>? jobs , CatagoriesAndJobModel? catagoriesAndJob ,Guid? CatagoryId,int totalNumberOfPage)
        {
            this.page = page;
            this.listOfJobs = jobs;
            this.catagoryandjob = catagoriesAndJob;
            this.CatagoryId = CatagoryId;
            this.totalPage  = totalNumberOfPage;
        }
    }
}
