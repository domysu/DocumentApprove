public class DocumentData
{
    public int DataId { get; set; }  // Primary key
    public int RequestId { get; set; }  // Foreign key
    public string FieldName { get; set; }
    public string FieldValue { get; set; }
    public DocumentRequest DocumentRequest { get; set; }  // Navigation property
}