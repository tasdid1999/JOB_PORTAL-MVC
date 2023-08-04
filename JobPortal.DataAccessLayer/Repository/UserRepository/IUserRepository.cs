using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<SignInResult> SignIn(SignInViewModel user);
        Task<IdentityResult> SignUp(SignUpViewModel user);

        Task SignOutAsync();
        Task<ApplicationUser> GetUserByEmail(string email);

        Task<bool> IsEmailExist(string email);

        Task<string> GetUserId(string email);

        Task<string> GetUserName(string email);

        Task<IList<string>> GetUserRoleByEmailAsync(string email);
    }
}
