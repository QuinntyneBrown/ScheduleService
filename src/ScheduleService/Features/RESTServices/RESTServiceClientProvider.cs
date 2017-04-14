namespace ScheduleService.Features.RESTServices
{
    public interface IRESTServiceClientProvider
    {
        IRESTServiceClient Get(string timeZoneName);
    }

    public class RESTServiceClientProvider: IRESTServiceClientProvider
    {
        IRESTServiceClient Get(string timeZoneName)
        {
            throw new System.NotImplementedException();
        }
    }
}
