using JobPortal.DataAccessLayer.Data;
using JobPortal.DataAccessLayer.Entities;
using JobPortal.DataAccessLayer.Interfaces;
using JobPortal.DataAccessLayer.ViewModel.CatagoryView;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.DataAccessLayer.Repository
{
    public class CatagoryRepository : ICatagoryRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public CatagoryRepository(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Catagory> AddCatagoryAsync(CatagoryViewModel catagory)
        {
            Catagory DataCatagory = new Catagory();
            DataCatagory.Id = Guid.NewGuid();
            DataCatagory.Name = catagory.CatagoryName;
            DataCatagory.Created = DateTime.Now;
            DataCatagory.Updated = DateTime.Now;

            var result = await _dbcontext.AddAsync(DataCatagory);
            await _dbcontext.SaveChangesAsync();

            return result.Entity;
            
        }

        public async Task<bool> DeleteCatagoryAsync(Guid CatagoryId)
        {
            var removableItem = _dbcontext.catagories.FirstOrDefault(x => x.Id == CatagoryId);
            if (removableItem is not null)
            {
                _dbcontext.catagories.Remove(removableItem);
                await _dbcontext.SaveChangesAsync();

                return true;

            }

            return false;
                
        }

        public async Task<List<Catagory>> GetAllCatagoryAsync()
        {
            var ListOfCatagory = await _dbcontext.catagories.AsNoTracking().ToListAsync();

            return ListOfCatagory;
        }

        public async Task<Catagory?> GetCatagoryByIdAsync(Guid id)
        {
            var catagory = await _dbcontext.catagories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return catagory;

        }

        public async Task<Catagory> UpdateCatagoryAsync(Catagory catagory , Guid catagoryId)
        {
            var updatedCatagory = await _dbcontext.catagories.FirstOrDefaultAsync(x => x.Id == catagoryId);

            if(catagory is not null)
            {
               updatedCatagory.Name = catagory.Name;
               updatedCatagory.Updated = DateTime.Now;
               await _dbcontext.SaveChangesAsync();

                return updatedCatagory;
            }

            return null;
        }
    }
}
