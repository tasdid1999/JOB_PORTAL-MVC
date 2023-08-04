using JobPortal.BussinessLogicLayer;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.CatagoryView;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.PresentationLayer.Controllers
{
    public class CatagoryController : Controller
    {

        private readonly ICatagoryServices catagoryservice;

        public CatagoryController(ICatagoryServices _services)
        {
            catagoryservice = _services;
        }

        [HttpGet]
        public IActionResult AddCatagory()
        {
            return View();
        }


        [HttpPost]
        
        public async Task<IActionResult> AddCatagory(CatagoryViewModel catagory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("AddCatagory");
                }

                await catagoryservice.AddCatagoryAsync(catagory);
                return RedirectToAction("GetAllCatagory");

            }
            catch (Exception ex)
            {
                throw new Exception("server issue!");
            }



        }
        public async Task<IActionResult> DeleteCatagory(Guid CatagoryId)
        {
            try
            {
                var isDeleted = await catagoryservice.DeleteCatagoryAsync(CatagoryId);
                return RedirectToAction("GetAllCatagory");
            }
            catch (Exception ex)
            {
                throw new Exception("server issue!");
            }



        }

        [Route("getallcatagory")]
        public async Task<IActionResult> GetAllCatagory()
        {
            var ListOfCatagory = await catagoryservice.GetAllCatagoryAsync();

            return View(ListOfCatagory);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCatagory(Guid CatagoryId)
        {
            var catagory = await catagoryservice.GetCatagoryByIdAsync(CatagoryId);

            ViewBag.CatagoryName = catagory.Name;
            ViewBag.CatagoryId = catagory.Id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCatagory(Catagory catagory)
        {
            var result = await catagoryservice.UpdateCatagoryAsync(catagory, catagory.Id);

            return RedirectToAction("GetAllCatagory");
        }


        

    }
}
