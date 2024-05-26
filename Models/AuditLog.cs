namespace DokumentuTvirtinimoSistema.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string Action { get; set; }
        public DateTime ActionDate { get; set; }
    }
}
    