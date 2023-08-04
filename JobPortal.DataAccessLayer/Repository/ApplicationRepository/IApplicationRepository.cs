using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Repository.ApplicationRepository
{
    public interface IApplicationRepository
    {
        Task CreateApplication(ApplyViewModel applicationForm);
        Task<bool> IsApplicationExist(Guid userId, Guid JobId);

        Task<List<Job>> GetAllApplicationsById(Guid userId);
        Task<List<Apply>> GetAllApplicantsForAJob(Guid jobId);
    }
}
