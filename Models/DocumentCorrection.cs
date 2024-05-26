namespace DokumentuTvirtinimoSistema.Models
{
    public class DocumentCorrection
    {
        public int Id { get; set; }
        public string DocumentId { get; set; }
        public string CorrectedData { get; set; }
        public DateTime CorrectionDate { get; set; }
    }
}
    