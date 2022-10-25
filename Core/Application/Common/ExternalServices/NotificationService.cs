using System.Net.Http.Headers;
using System.Text;
using Core.Application.Common.Models;
using Core.Common.Exceptions;
using Core.Domain.Interfaces.Services;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Core.Application.Common.ExternalServices;

public class NotificationService: INotificationService
{
    private readonly ISerializerService _jsonSerializer;
    private readonly IConfiguration _configuration;
    private readonly HttpClient client;

    public NotificationService(IHttpClientFactory clientFactory, ISerializerService jsonSerializer, IConfiguration configuration) {
        _configuration = configuration;
        _jsonSerializer = jsonSerializer;
        client = clientFactory.CreateClient("NotificationApi");
    } 


    public async Task<EmailResponse> SendMail(EmailRequest request)
    {
        string apikey = _configuration.GetValue<string>("ExternalServices:Notification:ApiKey");

        var url = string.Format("/v1/email/send");
        var result = new EmailResponse();

        var json = _jsonSerializer.Serialize(request);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8);
        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        httpContent.Headers.Add("X-ApiKey", apikey);

       var response = await client.PostAsync(url, httpContent);
        if (response.IsSuccessStatusCode) {
            var stringResponse = await response.Content.ReadAsStringAsync();
            result = _jsonSerializer.Deserialize<EmailResponse>(stringResponse);
        }
        else
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            throw new InternalServerException("No fue posible enviar el correo electrónico");
        }

        return result;
    }


}

