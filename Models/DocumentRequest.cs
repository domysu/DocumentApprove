using DokumentuTvirtinimoSistema.Models;

public class DocumentRequest
{
    public int RequestId { get; set; }
    public string InitiatingDepartment { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<DocumentData> DocumentData { get; set; }
    public Department department { get; set; }


    public DocumentRequest() { }
    public DocumentRequest(string initiatingDepartment,string status, DateTime createdDate) {
      
        InitiatingDepartment = initiatingDepartment;
        Status = status;
        CreatedDate = createdDate;


    } 
}