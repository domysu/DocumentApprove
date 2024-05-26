using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentuTvirtinimoSistema.Models
{
    public class UserRoles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        [NotMapped]
        public List<User> Users { get; set; } = new List<User>();
    }  

}
