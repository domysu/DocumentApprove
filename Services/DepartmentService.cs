using System.Collections.Generic;
using System.Threading.Tasks;
using DokumentuTvirtinimoSistema.Interfaces;
using DokumentuTvirtinimoSistema.Models;
using Microsoft.EntityFrameworkCore;

namespace DokumentuTvirtinimoSistema.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly AppDbContext _context;

        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetItemsAsync()
        {
            return await _context.Departments.ToListAsync();
        }
    }
}
