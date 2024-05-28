using DokumentuTvirtinimoSistema.Models;

namespace DokumentuTvirtinimoSistema.Interfaces
{
    public interface IRoles
    {
        Task<List<Roles>> GetRolesAsync();
    

    }
}
