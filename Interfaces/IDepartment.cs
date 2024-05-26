using DokumentuTvirtinimoSistema.Models;

namespace DokumentuTvirtinimoSistema.Interfaces
{
    public interface IDepartment
    { 
        Task<List<Department>> GetItemsAsync();
    }
}
