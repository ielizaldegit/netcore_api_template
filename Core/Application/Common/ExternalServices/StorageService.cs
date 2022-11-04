using System;
using Core.Application.Common.Models;
using Core.Common.Exceptions;
using System.Text;
using Core.Domain.Interfaces.Services;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;


namespace Core.Application.Common.ExternalServices;

public class StorageService: IStorageService
{
    private readonly ISerializerService _jsonSerializer;
    private readonly IConfiguration _configuration;
    private readonly HttpClient client;

    public StorageService(IHttpClientFactory clientFactory, ISerializerService jsonSerializer, IConfiguration configuration)
    {
        _configuration = configuration;
        _jsonSerializer = jsonSerializer;
        client = clientFactory.CreateClient("StorageApi");
    }


    public async Task<BlobResponse> UploadBlob(CreateBlobRequest request)
    {
        string apikey = _configuration.GetValue<string>("ExternalServices:Storage:ApiKey");

        var url = string.Format("/v1/blobs");
        var result = new BlobResponse();

        var json = _jsonSerializer.Serialize(request);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        httpContent.Headers.Add("X-ApiKey", apikey);

        var response = await client.PostAsync(url, httpContent);
        if (response.IsSuccessStatusCode)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            result = _jsonSerializer.Deserialize<BlobResponse>(stringResponse);
        }
        else
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            throw new InternalServerException("No fue posible almacenar el archivo en el container");
        }

        return result;
    }


}

