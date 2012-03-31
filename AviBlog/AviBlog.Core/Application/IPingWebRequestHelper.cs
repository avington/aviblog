namespace AviBlog.Core.Application
{
    public interface IPingWebRequestHelper
    {
        void Send(string serviceUrl, string postUrl, string blogName);
    }
}