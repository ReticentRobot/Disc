namespace Disc.Services
{
    public interface IHttpsClientHandlerService
    {
        HttpMessageHandler GetPlatformMessageHandler();
    }
}
