namespace DokumentuTvirtinimoSistema.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public Roles(int id, string roleName) {
        

              Id = id;
            RoleName = roleName;
        
        }
    }  


}
