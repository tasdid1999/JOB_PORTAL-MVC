using JobPortal.BussinessLogicLayer;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.Interfaces;
using JobPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatagoryServices _catagoryService;
        public HomeController(ILogger<HomeController> logger, ICatagoryServices catagoryService)
        {
            _logger = logger;
            _catagoryService = catagoryService;
        }

        public async Task<IActionResult> Index(Catagory? catagory)
        {
            var listOfCatagory = await _catagoryService.GetAllCatagoryAsync();

            return View(listOfCatagory);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}