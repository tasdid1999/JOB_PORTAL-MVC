using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.JobView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Repository.JobRepository
{
    public interface IJobRepository
    {
        Task  CreateJob(JobViewModel job);
        Task<List<Job>> GetAllJob();

        Task<Job> GetJobById(Guid id);

        Task DeleteJob(Guid id);

        Task<Job> UpdateJob(Job job);

        Task<List<Job>> GetAllJobByCatagory(Guid id , int page);

        Task<List<Job>> GetAllJobByTitle(string title);

        Task<List<Job>> GetAllJobByUserId(Guid userId);

        Task<long> JobCountByCatagory(Guid id);


    }
}
