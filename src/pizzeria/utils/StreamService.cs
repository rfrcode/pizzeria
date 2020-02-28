using Microsoft.AspNetCore.Http;
using System.IO;
namespace pizzeria.utils{
    public class StreamService  {
    public static byte[] GetFile(IFormFile file) {
        using(var memoryStream = new MemoryStream()) {
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
}