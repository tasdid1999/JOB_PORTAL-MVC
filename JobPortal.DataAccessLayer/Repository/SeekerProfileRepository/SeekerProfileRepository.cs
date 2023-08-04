using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Repository.SeekerProfileRepository
{
    public class SeekerProfileRepository : ISeekerProfileRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public SeekerProfileRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task CreateProfile(SeekerProfile profile)
        {
            await _dbcontext.AddAsync(profile);

            await _dbcontext.SaveChangesAsync();
        }

        public async Task<SeekerProfile> GetProfile(Guid id)
        {
            var profile =  await _dbcontext.seekerprofile.FirstOrDefaultAsync(x => x.UserId == id);

            return profile;
        }

        public async Task<bool> UpdateProfile(SeekerProfile profile)
        {
            var getProfile = await _dbcontext.seekerprofile.FirstOrDefaultAsync(x =>x.UserId == profile.UserId);    

            if(getProfile is not null)
            {
                getProfile.Name = profile.Name;
                getProfile.Education = profile.Education;
                getProfile.PortfolioLink = profile.PortfolioLink;
                getProfile.Achievements = profile.Achievements;
                getProfile.skills = profile.skills;
                getProfile.GitHubLink = profile.GitHubLink;
                getProfile.ImageUrl = profile.ImageUrl;

                await _dbcontext.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
