using Microsoft.AspNetCore.Http;
namespace pizzeria.utils
{

    public interface IStreamService
    {
        byte[] GetBytes(IFormFile file);
    }
}