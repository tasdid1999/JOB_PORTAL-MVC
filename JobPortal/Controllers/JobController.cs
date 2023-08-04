using JobPortal.BussinessLogicLayer;
using JobPortal.BussinessLogicLayer.Job;
using JobPortal.BussinessLogicLayer.User;
using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.Interfaces;
using JobPortal.DataAccessLayer.ViewModel.JobView;

using JobPortal.PresentationLayer.Models.HelperModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace JobPortal.PresentationLayer.Controllers
{
    public class JobController : Controller
    {

        private readonly ICatagoryServices cataService;
        private readonly IJobServices jobService;
        private readonly IUserServices userService;
        private readonly SignInManager<ApplicationUser> signinManager;
        

        public JobController(ICatagoryServices _cataService, IJobServices _jobService, IUserServices _userService, SignInManager<ApplicationUser> _signinManager)
        {
            cataService = _cataService;
            jobService = _jobService;
            userService = _userService;
            signinManager = _signinManager;
           
        }

        [HttpGet]
        [Route("job/createjob")]
        [Authorize(Roles ="jobrecruiter")]
        public async Task<IActionResult> AddJob()
        {
            ViewBag.UserName = await userService.GetUserName(User.FindFirst(ClaimTypes.Email)?.Value);
            var catagories = await cataService.GetAllCatagoryAsync();

            ViewBag.Catagories = new SelectList(catagories,"CatagoryId","CatagoryName");

            ViewBag.PostDone = false;
            return View();
        }
        [HttpPost]
        [Route("job/createjob")]
        public async Task<IActionResult> AddJob(JobViewModel job)
        {
           if(!ModelState.IsValid)
            {
                ViewBag.PostDone = false;
                return View(job);
            }
            var Email = User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = await userService.GetUserId(Email);
            job.UserId = new Guid(userId);

            await jobService.CreateJobAsync(job);

            ViewBag.PostDone = true;
            ModelState.Clear();
            return View();

        }

        [Route("jobs")]
        public async Task<IActionResult> GetAllJob()
        {
            var catagories = await cataService.GetAllCatagoryAsync();
            
            return View(catagories);
        }

        [HttpGet("{id:Guid}")]
        [Route("jobs/catagory")]
        public async Task<IActionResult> GetAllJobByCatagory(Guid id, int page = 1)
        {
           
            var ListOfJob = await jobService.GetAllJobByCatagoryAsync(id,page);

            var catagories = await cataService.GetAllCatagoryAsync();

            var CatagoryAndJobList = new CatagoriesAndJobModel(catagories, ListOfJob);

            var totalJob = await jobService.JobCountByCatagoryAsync(id);

            var totalNumberOfPage = Convert.ToInt32(Math.Floor((double)totalJob / 2));

            var pageOfJob = new Pagination(page,ListOfJob, CatagoryAndJobList, id,totalNumberOfPage);

           return View(pageOfJob);

        }
        [HttpGet("{id:Guid}")]
        [Route("job/id")]
        public async Task<IActionResult> GetJobById(Guid id)
        {
            var job = await jobService.GetJobByIdAsync(id);

            return View(job);
        }

        [Route("jobs/title")]
        public async Task<IActionResult> GetAllJobByTitle(string title)
        {
            if(title is null)
            {
                RedirectToAction("GetAllJob");
            }

            var listOfJob = await jobService.GetAllJobByTitleAsync(title);
            var catagories = await cataService.GetAllCatagoryAsync();
            var model = new CatagoriesAndJobModel(catagories, listOfJob);
            return  View(model); ;
            
        }


        public async Task<IActionResult> JobApplicationControl(string Id,string jobTitle)
        {
            if(signinManager.IsSignedIn(User))
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                var role = await userService.GetUserRoleByEmailAsync(email);

                if (role[0] == "jobrecruiter")
                {

                    return RedirectToAction("Index", "Recruiter");
                }
                if (role[0] == "jobseeker")
                {
                    return RedirectToAction("ApplyJob", "Seeker",new {id = Id,title = jobTitle});
                }
            }
            else
            {
                return RedirectToAction("ApplyJob", "Seeker", new { id = Id,title = jobTitle });
            }

            return View();
        }
       
       
    }
}
