using JobPortal.DataAccessLayer.ViewModel.Application;
using JobPortal.DataAccessLayer.ViewModel.JobView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.Application
{
    public interface IApplicationServices
    {
        Task CreateApplication(ApplyViewModel applicationForm);
        Task<bool> IsApplcationExist(Guid userId, Guid jobId);
        Task<List<JobViewModel>> GetAllApplicationsById(Guid userId);

        Task<List<ApplyViewModel>> GetAllApplicantsForAJob(Guid jobId);
    }
}
