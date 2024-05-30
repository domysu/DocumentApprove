using System.ComponentModel.DataAnnotations;

namespace DokumentuTvirtinimoSistema.Models
{
    public class AuditLogs
    {
            [Key] public int AuditId { get; set; }
            public int AuditDocumentId { get; set; }
            public string AuditStatus { get; set; }
            public DateTime AuditTimestamp { get; set; }
    }
}

    