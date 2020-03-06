using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http.Headers;

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
        try
        {
            var url = _configuration.GetValue<string>(IMAGEURL);
            var client = _clientFactory.CreateClient();
            //TODO ARREGLAR MULTIPARTFORMADATA
            var multipart = new MultipartFormDataContent();

            using (MemoryStream ms = new MemoryStream(image))
            {
                var name = "pepe";
                var stream = new StreamContent(ms);
                stream.Headers.Add("Content-Type", "application/octet-stream");
                stream.Headers.Add("Content-Disposition", "form-data; name=\"file\"; filename=\"" + name + "\"");
                multipart.Add(stream, "pepe", name);
            }

            // var response = await client.PostAsync(new Uri(url), multipart);
            var response = await client.PostAsync(url, multipart);

            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<IEnumerable<String>>(responseStream);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}