using JobPortal.DataAccessLayer.Repository.ApplicationRepository;
using JobPortal.DataAccessLayer.ViewModel.Application;
using JobPortal.DataAccessLayer.ViewModel.JobView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.Application
{
    public class ApplicationServices : IApplicationServices
    {
        private readonly IApplicationRepository _repo;

        public ApplicationServices(IApplicationRepository repo)
        {
            _repo = repo;
        }
        public async Task CreateApplication(ApplyViewModel applicationForm)
        {
            await _repo.CreateApplication(applicationForm);
        }

        public async Task<List<ApplyViewModel>> GetAllApplicantsForAJob(Guid jobId)
        {
            var result = await _repo.GetAllApplicantsForAJob(jobId);
            var listOfApplicant = new List<ApplyViewModel>();

            foreach(var item in result)
            {
                listOfApplicant.Add(new ApplyViewModel
                {
                    JobId = jobId,
                    JobTitle = item.JobTitle,
                    UserId = item.UserId,
                    Name = item.Name,
                    UrlOfCV = item.UrlOfCV,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    LastDegree  = item.LastDegree,
                   
                });
            }
            return listOfApplicant;
        }

        public async Task<List<JobViewModel>> GetAllApplicationsById(Guid userId)
        {
            var listOfJob = await _repo.GetAllApplicationsById(userId);

            var listOfJobs = new List<JobViewModel>();

            foreach (var job in listOfJob)
            {
                listOfJobs.Add(new JobViewModel()
                {
                    Id = job.Id,
                    HREmail = job.HREmail,
                    CompanyName = job.CompanyName,
                    LastDateOfApplication = job.LastDateOfApplication,
                    Salary = job.Salary,    

                });


            }

            return listOfJobs;
        }

        public async Task<bool> IsApplcationExist(Guid userId, Guid jobId)
        {
            return await _repo.IsApplicationExist(userId, jobId);
        }
    }
}
