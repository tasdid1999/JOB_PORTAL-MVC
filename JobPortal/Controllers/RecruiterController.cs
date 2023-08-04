using JobPortal.BussinessLogicLayer.Application;
using JobPortal.BussinessLogicLayer.Job;
using JobPortal.BussinessLogicLayer.SeekerProfileService;
using JobPortal.BussinessLogicLayer.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobPortal.PresentationLayer.Controllers
{
    [Authorize(Roles = "jobrecruiter")]
    public class RecruiterController : Controller
    {

        private readonly IUserServices userServices;
        private readonly IJobServices jobServices;
        private readonly IApplicationServices appServices;
        private readonly ISeekerProfileServices seekerProfileService;
        public RecruiterController(IUserServices _userServices, IJobServices _jobServices, IApplicationServices _appServices, ISeekerProfileServices _seekerProfileService)
        {
            userServices = _userServices;
            jobServices = _jobServices;
            appServices = _appServices;
            seekerProfileService = _seekerProfileService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.UserName = await GetUserName();

            return View();
        }

        [Route("recruiter/managejob")]

        public async Task<IActionResult> ManageRecruiterJobPost()
        {
            ViewBag.UserName = await GetUserName();

            var Email = User.FindFirst(ClaimTypes.Email)?.Value;

            var userId = await userServices.GetUserId(Email);

            var listOfJob = await jobServices.GetAllJobByUserId(new Guid(userId));

            return View(listOfJob);
        }
        [HttpGet("jobId:int")]
        [Route("recruiter/applicantlist")]
        public async Task<IActionResult> GetAllApplicantForAJob(Guid jobId)
        {
            ViewBag.UserName = await GetUserName();

            var listOfApplicants = await appServices.GetAllApplicantsForAJob(jobId);

            return View(listOfApplicants);
        }

        [Route("recruiter/applicantprofile")]
        public async Task<IActionResult> GetApplicantProfile(string id)
        {
            var profile = await seekerProfileService.GetProfile(new Guid(id));
            ViewBag.FormatedAchievements = seekerProfileService.FormatedAchievement(profile.Achievements);
            ViewBag.FormatedSkills = seekerProfileService.FormatedSkills(profile.skills);
            return View(profile);
        }
        private async Task<string> GetUserName()
        {
           return await userServices.GetUserName(User.FindFirst(ClaimTypes.Email)?.Value);
        }
    }
}
