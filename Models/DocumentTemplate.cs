using System.ComponentModel.DataAnnotations;

namespace DokumentuTvirtinimoSistema.Models
{
    public class DocumentTemplate
    {
        [Key]
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string Description { get; set; }
        public string FieldsStructure { get; set; } 

        // Numatytasis konstruktorius
        public DocumentTemplate()
        {
        }

        // Konstruktorius su parametrais
        public DocumentTemplate(string templateName, string description)
        {
            TemplateName = templateName;
            Description = description;
        }
    }
}
