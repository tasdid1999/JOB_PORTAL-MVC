using AutoMapper;
using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Repository.ApplicationRepository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper mapper;
        public ApplicationRepository(ApplicationDbContext dbContext , IMapper _mapper)
        {
            _dbcontext = dbContext;
            mapper = _mapper;
        }
        public async Task CreateApplication(ApplyViewModel applicationForm)
        {
            var application = mapper.Map<Apply>(applicationForm);

            await _dbcontext.jobapplication.AddAsync(application);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Job>> GetAllApplicationsById(Guid userId)
        {
            var listOfJob = await _dbcontext.jobapplication.
                                   Where(ja => ja.UserId == userId).
                                   Include(ja => ja.Job).
                                   Select(ja => ja.Job).ToListAsync();

            return listOfJob;
                
        }

        public async Task<bool> IsApplicationExist(Guid userId, Guid JobId)
        {
            var isExist = await _dbcontext.jobapplication.AnyAsync(a => a.UserId == userId && a.JobId == JobId);
           
            return isExist;
        }
        public async Task<List<Apply>> GetAllApplicantsForAJob(Guid jobId)
        {
            var listOfApplicant = await _dbcontext.jobapplication.AsNoTracking().Where(a => a.JobId == jobId).ToListAsync();

            return listOfApplicant;
        }
    }
}
