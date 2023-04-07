namespace Ensilog.Engagebay.Abstractions
{
    public interface IEngageBayRequest<TBody>
    {

        RestSharp.Method Method { get; }

        string Uri { get; }

        TBody Body { get; }

        string ContentType { get; }
    }

    public interface IEngageBayRequest<TBody, TResponse> : IEngageBayRequest<TBody>
    {
    }
}
