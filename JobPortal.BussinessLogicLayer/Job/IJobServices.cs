using JobPortal.DataAccessLayer.ViewModel.JobView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.Job
{
    public interface IJobServices
    {
        Task CreateJobAsync(JobViewModel job);
        Task<List<JobViewModel>> GetAllJobAsync();

        Task<JobViewModel> GetJobByIdAsync(Guid id);

        Task DeleteJobAsync(Guid id);

        Task<JobViewModel> UpdateJobAsync(JobViewModel job);

        Task<List<JobViewModel>> GetAllJobByCatagoryAsync(Guid id ,int page);

        Task<List<JobViewModel>> GetAllJobByTitleAsync(string title);

        Task<List<JobViewModel>> GetAllJobByUserId(Guid userId);

        Task<long> JobCountByCatagoryAsync(Guid id);
    }
}
