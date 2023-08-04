using AutoMapper;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.JobView;

namespace JobPortal.PresentationLayer.Helper
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
            CreateMap<Job, JobViewModel>();
            CreateMap<JobViewModel, Job>();
        }
    }
}
