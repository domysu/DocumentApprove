using Microsoft.AspNetCore.Components;

namespace DokumentuTvirtinimoSistema.Models
{
    public class DocumentCorrection
    {
        public int DataId { get; set; }
        public int RequestId { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public DocumentRequest DocumentRequest { get; set; }
    }
}
