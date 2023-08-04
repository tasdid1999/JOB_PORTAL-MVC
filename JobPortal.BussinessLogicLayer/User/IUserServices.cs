using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.ViewModel.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer.User
{
    public interface IUserServices
    {
        Task<IdentityResult> SignUp(SignUpViewModel user);
        Task<bool> IsEmailExist(string email);

        Task<SignInResult> SignIn(SignInViewModel user);

        Task<IList<string>> GetUserRoleByEmailAsync(string email);

        Task<string> GetUserId(string email);
        Task<string> GetUserName(string email);

        Task SignOutAsync();


    }
}
