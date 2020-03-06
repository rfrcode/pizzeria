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


           ByteArrayContent stream = new ByteArrayContent(image);
           multipart.Add(stream, "pepe", "pepe");
           
           /*using(MemoryStream ms = new MemoryStream(image)){
               ms.Position =0;
               var stream = new StreamContent(ms);              
               multipart.Add(stream, "pepe", "pepe");
           }*/


            //stream.Headers.Add("Content-Type", "application/octet-stream");
            



            var response = await client.PostAsync(new Uri(url), multipart);


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