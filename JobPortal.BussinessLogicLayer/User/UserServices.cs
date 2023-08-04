using JobPortal.BussinessLogicLayer.SeekerProfileService;
using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.Repository.UserRepository;
using JobPortal.DataAccessLayer.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.User
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepo;
        private readonly ISeekerProfileServices seekerProfileServices;
        public UserServices(IUserRepository _userRepo, ISeekerProfileServices _seekerProfileServices)
        {
            userRepo = _userRepo;
            seekerProfileServices = _seekerProfileServices;
        }

        public async Task<string> GetUserId(string email)
        {
            var userId = await userRepo.GetUserId(email);

            return userId;
        }

        public async Task<string> GetUserName(string email)
        {
           return await userRepo.GetUserName(email);
        }

        public async Task<IList<string>> GetUserRoleByEmailAsync(string email)
        {
            var roles = await userRepo.GetUserRoleByEmailAsync(email);

            return roles;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            bool isExist = await userRepo.IsEmailExist(email);

            return isExist;
        }

        public async Task<SignInResult> SignIn(SignInViewModel user)
        {
           var result = await userRepo.SignIn(user);

            return result;
        }

        public async Task SignOutAsync()
        {
            await userRepo.SignOutAsync();
        }

        public async Task<IdentityResult> SignUp(SignUpViewModel user)
        {
            var result = await userRepo.SignUp(user);
            if(result.Succeeded)
            {
                if(user.Role == "jobseeker")
                {
                    var newSeekerProfile = new SeekerProfile();

                    newSeekerProfile.UserId = new Guid(await GetUserId(user.Email));

                    await seekerProfileServices.CreateProfile(newSeekerProfile);
                }
            }
            return result;
        }
    }
}
