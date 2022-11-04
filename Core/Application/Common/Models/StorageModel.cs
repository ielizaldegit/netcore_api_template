using System;
namespace Core.Application.Common.Models;

public class CreateBlobRequest
{
    public string BlobBase64 { get; set; }
    public string FileName { get; set; }
    public string FolderName { get; set; }
    public string Type { get; set; }
    public bool HasDefaultName { get; set; }
}

public class GetBlobRequest
{
    public string? Url { get; set; }
    public string? BlobName { get; set; }
}

public class BlobResponse
{
    public string Url { get; set; }
    public string Name { get; set; }
    public long Size { get; set; }
}

