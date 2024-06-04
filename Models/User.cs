using System.ComponentModel.DataAnnotations.Schema;

namespace DokumentuTvirtinimoSistema.Models
{
    public class User
    {
        public User()
        {
            Email = "";
            Username = "";
        }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }   
      
        public int RoleID {  get; set; }
        public bool isActive { get; set; }

        public DateTime LastLogin { get; set; }
     
      
  
    }
}
