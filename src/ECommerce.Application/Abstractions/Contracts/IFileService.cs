namespace ECommerce.Application.Abstractions.Contracts;

public interface IFileService
{
    
    public string UploadFile(Guid fileId,Stream stream);
}