using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.ViewModel.User;
using Microsoft.AspNetCore.Identity;


namespace JobPortal.DataAccessLayer.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
       

        public UserRepository(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
           
        }
        public async Task<IdentityResult> SignUp(SignUpViewModel user)
        {
            
            var IdentityUser = new ApplicationUser 
            {
                Name = user.UserName,
                UserName = user.Email,
                Email = user.Email,
                DOB = user.DOB,
            };
            var result = await userManager.CreateAsync(IdentityUser,user.Password);
            var userByEmail = await GetUserByEmail(user.Email);

            if(result.Succeeded && userByEmail is not null)
            {
                 await userManager.AddToRoleAsync(userByEmail, user.Role);

            }
            return result;
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<bool> IsEmailExist(string email)
        {
            var isExist = await userManager.FindByEmailAsync(email);

            if(isExist == null)return false;

            return true;
        }

        public async Task<SignInResult> SignIn(SignInViewModel user)
        {
            var result = await signInManager.PasswordSignInAsync(user.Email,user.Password,false,false);

            return result;
            
           
        }
        
        public async Task<string> GetUserId(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            var id = await userManager.GetUserIdAsync(user);

            return id;

           
        }
        public async Task<string> GetUserName(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            var name = await userManager.GetUserNameAsync(user);

          

            return name;
        }

        public async Task<IList<string>> GetUserRoleByEmailAsync(string email)
        {
            var identityUser = await userManager.FindByEmailAsync(email);

            var roles = await userManager.GetRolesAsync(identityUser);

            return roles;
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
