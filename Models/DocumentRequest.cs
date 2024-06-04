using DokumentuTvirtinimoSistema.Models;

public class DocumentRequest
{
    public int RequestId { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<DocumentData> DocumentData { get; set; }



    public DocumentRequest() { }
    public DocumentRequest(string status, DateTime createdDate) {
      
        Status = status;
        CreatedDate = createdDate;


    } 
}