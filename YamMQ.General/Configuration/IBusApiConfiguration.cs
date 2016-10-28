namespace YamMQ.General.Configuration
{
    public interface IBusApiConfiguration
    {
        string Url { get; }
        IBusApiSecurityConfiguration SecurityConfiguration { get; }
    }
}