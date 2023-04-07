using RestSharp;

namespace Ensilog.Engagebay.Abstractions
{
    /// <summary>
    /// Represents a command sent to Engage Bay that will not give any response data, apart from HTTP codes
    /// </summary>
    public abstract class EngageBayCommand<TBody> : IEngageBayRequest<TBody>
    {
        public virtual Method Method => Method.Post;

        public abstract string Uri { get; }

        public virtual TBody Body => default;

        public virtual string ContentType => "application/json";

    }

    /// <summary>
    /// Represents a command sent to Engage Bay that will not give any response data, apart from HTTP codes and does not need any body
    /// </summary>
    public abstract class EngageBayCommand : EngageBayCommand<string>
    {
        public override string ContentType => null;
    }

    /// <summary>
    /// Represents a command sent to Engage Bay that will return a response
    /// </summary>
    /// <typeparam name="TResponse">The type of the response</typeparam>
    public abstract class EngageBayCommand<TBody, TResponse> : EngageBayCommand<TBody> where TResponse : class
    {

    }
}
