using DokumentuTvirtinimoSistema.Models;
using DokumentuTvirtinimoSistema.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DokumentuTvirtinimoSistema.Services
{
    public class RolesService : IRoles
    {
        private readonly AppDbContext _context;
        private readonly IUser _IUser;

        public RolesService(AppDbContext context, IUser IUser)
        {
            _IUser = IUser; 
            _context = context;
        }
        public async Task<List<Roles>> GetRolesAsync()
        {
            return await _context.Roles.ToListAsync();

        }

      
    }
}
