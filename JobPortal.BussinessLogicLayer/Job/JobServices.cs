using AutoMapper;
using JobPortal.DataAccessLayer.Repository.JobRepository;
using JobPortal.DataAccessLayer.ViewModel.JobView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.Job
{
    public class JobServices : IJobServices
    {
        private readonly IJobRepository _jobrepo;
        private readonly IMapper mapper;
        public JobServices(IJobRepository repo , IMapper _mapper)
        {
            _jobrepo = repo;
            mapper = _mapper;
        }
        public async Task CreateJobAsync(JobViewModel job)
        {
            

            await _jobrepo.CreateJob(job);
        }

        public Task DeleteJobAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobViewModel>> GetAllJobAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<JobViewModel>> GetAllJobByCatagoryAsync(Guid id , int page)
        {
            var result = await _jobrepo.GetAllJobByCatagory(id ,page);

            var jobList = mapper.Map<List<JobViewModel>>(result);

            return jobList;
        }

        public async Task<List<JobViewModel>> GetAllJobByTitleAsync(string title)
        {
            var result = await _jobrepo.GetAllJobByTitle(title);

            var jobList = mapper.Map<List<JobViewModel>>(result);

            return jobList;
        }

        public async Task<List<JobViewModel>> GetAllJobByUserId(Guid userId)
        {
            var Jobs = await _jobrepo.GetAllJobByUserId(userId);

            var jobList = mapper.Map<List<JobViewModel>>(Jobs);

            return jobList;
        }

        public async Task<JobViewModel> GetJobByIdAsync(Guid id)
        {
            var result = await _jobrepo.GetJobById(id);

            var job = mapper.Map<JobViewModel>(result);
            return job;
        }

        public async Task<long> JobCountByCatagoryAsync(Guid id)
        {
            return await _jobrepo.JobCountByCatagory(id);
        }

        public Task<JobViewModel> UpdateJobAsync(JobViewModel job)
        {
            throw new NotImplementedException();
        }
    }
}
