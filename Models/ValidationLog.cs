namespace DokumentuTvirtinimoSistema.Models
{
    public class ValidationLog
    {
        public int Id { get; set; }
        public int DocumentReviewId { get; set; }
        public DateTime LogDate { get; set; }
        public string LogMessage { get; set; }

        public DocumentReview DocumentReview { get; set; }
    }
}