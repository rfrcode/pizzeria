using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;

public class ImageServer : IImageServer
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    private const string IMAGEURL = "ImageUrl";
    public ImageServer(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    public async ValueTask<IEnumerable<String>> GetImages(byte[] image)
    {
        var url = _configuration.GetValue<string>(IMAGEURL);        
        var client = _clientFactory.CreateClient();
        //TODO ARREGLAR MULTIPARTFORMADATA
        var multipart = new MultipartContent();
        
        multipart.Add(new ByteArrayContent(image));
        var response = await client.PostAsync(url, multipart);

        using (var responseStream = await response.Content.ReadAsStreamAsync()){
            return await JsonSerializer.DeserializeAsync<IEnumerable<String>>(responseStream);
        }
            
    }
}