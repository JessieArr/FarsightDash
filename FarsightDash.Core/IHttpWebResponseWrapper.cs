namespace FarsightDash.BaseModules
{
    public interface IHttpWebResponseWrapper
    {
        string RedirectedURL { get; }
        string Status { get; }
        string Headers { get; }
        string Body { get; }
    }
}