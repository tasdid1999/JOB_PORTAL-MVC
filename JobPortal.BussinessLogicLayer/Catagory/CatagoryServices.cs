using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.Interfaces;
using JobPortal.DataAccessLayer.ViewModel.CatagoryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.BussinessLogicLayer
{
    public class CatagoryServices : ICatagoryServices
    {
        private readonly ICatagoryRepository _repo;
        public CatagoryServices(ICatagoryRepository repo)
        {
            _repo = repo;
        }
        public async Task AddCatagoryAsync(CatagoryViewModel catagory)
        {
            await _repo.AddCatagoryAsync(catagory);
        }

        public async Task<bool> DeleteCatagoryAsync(Guid CatagoryId)
        {
           var isDeleted =  await _repo.DeleteCatagoryAsync(CatagoryId);

            if (isDeleted) return true;

            return false;
        }

        public async Task<List<CatagoryViewModel>> GetAllCatagoryAsync()
        {
            var listOfCatagory = await _repo.GetAllCatagoryAsync();

            var catagoryViewList = new List<CatagoryViewModel>();

            foreach(var catagory in listOfCatagory)
            {
                catagoryViewList.Add(new CatagoryViewModel() { CatagoryId = catagory.Id,CatagoryName = catagory.Name});
            }

            return catagoryViewList;
        }

        public async Task<Catagory> UpdateCatagoryAsync(Catagory catagory,Guid id)
        {
            var updatedCatagory = await _repo.UpdateCatagoryAsync(catagory,id);

            return updatedCatagory;
        }
        public async Task<Catagory?> GetCatagoryByIdAsync(Guid id)
        {
            var catagory = await _repo.GetCatagoryByIdAsync(id);

            return catagory;
        }
    }
}
