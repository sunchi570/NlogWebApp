namespace NlogWebApp.Services
{
    public interface IValueService
    {
        [DefaultInterceptor]
        string Get();
    }
}
