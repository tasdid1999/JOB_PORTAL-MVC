using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.ViewModel.CatagoryView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Interfaces
{
    public interface ICatagoryRepository
    {
        Task<List<Catagory>> GetAllCatagoryAsync();

         Task<Catagory> AddCatagoryAsync(CatagoryViewModel catagory);

         Task<bool> DeleteCatagoryAsync(Guid CatagoryId);

        Task<Catagory?> GetCatagoryByIdAsync(Guid id);

        Task<Catagory> UpdateCatagoryAsync(Catagory catagory , Guid id);
    }
}
