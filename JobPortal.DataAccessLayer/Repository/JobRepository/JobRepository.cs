using AutoMapper;
using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.JobView;
using Microsoft.EntityFrameworkCore;


namespace JobPortal.DataAccessLayer.Repository.JobRepository
{
   

    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly IMapper mapper;


        public JobRepository(ApplicationDbContext dbContext, IMapper _mapper)
        {
            _dbcontext = dbContext;
            mapper = _mapper;
        }
        public async Task CreateJob(JobViewModel job)
        {
            var newJob = mapper.Map<Job>(job);
            await _dbcontext.jobs.AddAsync(newJob);
            await _dbcontext.SaveChangesAsync();
        }

        public Task DeleteJob(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetAllJob()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Job>> GetAllJobByCatagory(Guid id,int page)
        {
            var listOfJob = await _dbcontext.jobs.AsNoTracking().Where(x=> x.CatagoryId == id).Skip((page-1)*2).Take(2).ToListAsync();

            return listOfJob;

        }

        public async Task<List<Job>> GetAllJobByTitle(string title)
        {
            var listOfJob = await _dbcontext.jobs.AsNoTracking().Where(x=> x.JobTitle.Contains(title)).ToListAsync();

            return listOfJob;
        }

        public async Task<List<Job>> GetAllJobByUserId(Guid userId)
        {
            var listOfJob = await _dbcontext.jobs.AsNoTracking().Where(x => x.UserId == userId).ToListAsync();
            return listOfJob;
        }

        public async Task<Job> GetJobById(Guid id)
        {
            var job = await _dbcontext.jobs.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);

            return job;
        }

        public async Task<long> JobCountByCatagory(Guid id)
        {
            return await _dbcontext.jobs.AsNoTracking().Where(x=> x.CatagoryId == id).CountAsync();
            
        }

        public Task<Job> UpdateJob(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
