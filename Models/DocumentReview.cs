namespace DokumentuTvirtinimoSistema.Models
{
    public class DocumentReview
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string Status { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string? ReviewedBy { get; set; } // Nullable string
        public DateTime? ReviewedDate { get; set; } // Nullable DateTime
        public string Comments { get; set; }

        public ICollection<ValidationLog> ValidationLogs { get; set; } = new List<ValidationLog>();
    }
}