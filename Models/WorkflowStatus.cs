namespace DokumentuTvirtinimoSistema.Models
{
    public class WorkflowStatus
    {
        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
    }
}
    