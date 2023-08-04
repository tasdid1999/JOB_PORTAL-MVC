using JobPortal.BussinessLogicLayer.Application;
using JobPortal.BussinessLogicLayer.SeekerProfileService;
using JobPortal.BussinessLogicLayer.User;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortal.PresentationLayer.Controllers
{
    [Authorize(Roles = "jobseeker")]
    public class SeekerController : Controller
    {
        private readonly IApplicationServices appService;
        private readonly IUserServices userService;
        private readonly IWebHostEnvironment webhostBuilder;
        private readonly ISeekerProfileServices seekerProfileServices;
        public SeekerController(IApplicationServices appservice, IUserServices userservice, IWebHostEnvironment webhostbuilder, ISeekerProfileServices _seekerProfileServices)
        {
            appService = appservice;
            userService = userservice;
            webhostBuilder = webhostbuilder;
            seekerProfileServices = _seekerProfileServices;

        }
        [Route("seeker/dash")]
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        [Route("applicationform")]
        public async Task<IActionResult> ApplyJob(string id,string title)
        {
             ViewBag.JobId = id;
            ViewBag.JobTitle = title;

            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = await userService.GetUserId(email);

            if (await appService.IsApplcationExist(new Guid(userId), new Guid(id)))
            {
                ViewBag.Success = false;
                ViewBag.Failed = true;

                return View();
            }
           
            ViewBag.Success = false;
            ViewBag.Failed = false;

            return View();
        }

        [HttpPost]
        [Route("applicationform")]
        public async Task<IActionResult> ApplyJob(ApplyViewModel applicationForm)
        {
            
            try
            {
               if(!ModelState.IsValid)
                {
                    ViewBag.Success = false;
                    ViewBag.Failed = false;
                    return View();
                }
               if(applicationForm.CV is not null)
               {
                    string folder = "cv/";
                    applicationForm.UrlOfCV = await UploadCv(folder, applicationForm.CV);
                }
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var userId = await userService.GetUserId(email);

                if (await appService.IsApplcationExist(new Guid(userId), applicationForm.JobId))
                {
                    ViewBag.Success = false;
                    ViewBag.Failed = true;
                    ModelState.Clear();

                    return View();
                }
                    
                applicationForm.UserId = new Guid(userId);
                
                await appService.CreateApplication(applicationForm);

                ViewBag.Success = true;
                ViewBag.Failed = false;

                ModelState.Clear();
            }
            catch(Exception ex)
            {
                throw new Exception("internal server problem");
            }

           
            return View();
        }
        [Route("seeker/applicationlist")]
        public async Task<IActionResult> GetAllApplication()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = await userService.GetUserId(email);

            var listOfjob = await appService.GetAllApplicationsById(new Guid(userId));

            return View(listOfjob);
        }
        private async Task<string> UploadCv(string folderpath , IFormFile file)
        {
            
            folderpath += (Guid.NewGuid().ToString() + "_" + file.FileName);

            string serverFolder = Path.Combine(webhostBuilder.WebRootPath, folderpath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderpath;
        }

        [Route("seeker/myprofile")]
        public async Task<IActionResult> SeekerProfile()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = await userService.GetUserId(email);

            var profile = await seekerProfileServices.GetProfile(new Guid(userId));

            ViewBag.FormatedSkills = seekerProfileServices.FormatedSkills(profile.skills);
            ViewBag.FormatedAchievements = seekerProfileServices.FormatedAchievement(profile.Achievements);

            return View(profile);
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = await userService.GetUserId(email);

            var profile = await seekerProfileServices.GetProfile(new Guid(userId));

            ViewBag.profileId = profile.Id.ToString();
            ViewBag.userId = profile.UserId.ToString();
            ViewBag.Success = false;
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(SeekerProfile profile)
        {
            if(!ModelState.IsValid)return View(profile);

            if(profile.Image is not null)
            {
                string folder = "profilephoto/";
                profile.ImageUrl = await UploadImage(folder, profile.Image);
            }
            var result = await seekerProfileServices.UpdateProfile(profile);

            if(result)
            {
                ViewBag.Success = true;
            }
            else
            {
                ViewBag.Success = false;
            }
            return View();
        }
        private async Task<string> UploadImage(string folderpath, IFormFile file)
        {

            folderpath += (Guid.NewGuid().ToString() + "_" + file.FileName);

            string serverFolder = Path.Combine(webhostBuilder.WebRootPath, folderpath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderpath;
        }




    }
}
