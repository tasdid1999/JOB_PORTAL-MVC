using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.CatagoryView;
using JobPortal.DataAccessLayer.ViewModel.JobView;

namespace JobPortal.BussinessLogicLayer
{
    public interface ICatagoryServices
    {
        Task AddCatagoryAsync(CatagoryViewModel catagory);
        Task<bool> DeleteCatagoryAsync(Guid CatagoryId);
        Task<List<CatagoryViewModel>> GetAllCatagoryAsync();

        Task<Catagory> UpdateCatagoryAsync(Catagory catagory , Guid id);

        Task<Catagory?> GetCatagoryByIdAsync(Guid CatagoryId);

       

    }
}
