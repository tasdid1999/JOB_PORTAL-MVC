using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.Repository.SeekerProfileRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.SeekerProfileService
{
    public class SeekerProfileServices : ISeekerProfileServices
    {
        private readonly ISeekerProfileRepository seekerRepo;

        public SeekerProfileServices(ISeekerProfileRepository _seekerRepo)
        {
            this.seekerRepo = _seekerRepo;
        }
        public async Task CreateProfile(SeekerProfile profile)
        {
            await seekerRepo.CreateProfile(profile);
        }

        public async Task<SeekerProfile> GetProfile(Guid id)
        {
           return await seekerRepo.GetProfile(id);
        }

        public async Task<bool> UpdateProfile(SeekerProfile profile)
        {
           return await seekerRepo.UpdateProfile(profile);
        }
        public string[] FormatedSkills(string skills)
        {
            var listOfSkills = skills.Split('|');

            return listOfSkills;
        }
        public string[] FormatedAchievement(string achievements)
        {
            var listOfAchievements = achievements.Split('|');

            return listOfAchievements;
        }
    }
}
