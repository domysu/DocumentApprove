using System.ComponentModel.DataAnnotations;

namespace DokumentuTvirtinimoSistema.Models
{
    public class DocumentTemplate
    {
        [Key]
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string Description { get; set; }
        public string FieldsStructure { get; set; } // JSON structure representing the fields
    }
}
