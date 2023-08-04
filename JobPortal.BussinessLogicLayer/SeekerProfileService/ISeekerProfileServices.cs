using JobPortal.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.SeekerProfileService
{
    public interface ISeekerProfileServices
    {
        Task CreateProfile(SeekerProfile profile);

        Task<SeekerProfile> GetProfile(Guid id);

        Task<bool> UpdateProfile(SeekerProfile profile);

        string[] FormatedAchievement(string achievements);

        string[] FormatedSkills(string skills);
    }
}
