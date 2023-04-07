using Ensilog.Engagebay.Abstractions;
using Ensilog.Engagebay.Exceptions;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Serializers.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ensilog.Engagebay
{
    public class EngageBayClient
    {
        private const string ROOT_URL = "https://app.engagebay.com/";
        private RestClient _restClient;

        public EngageBayClient(string apiKey)
        {
            _restClient = new RestClient(
                baseUrl: ROOT_URL,
                configureSerialization: ConfigureJsonSerialization);
            _restClient.AddDefaultHeader("Authorization", apiKey);
            _restClient.AddDefaultHeader("Accept", "application/json");

        }

        private void ConfigureJsonSerialization(SerializerConfig config)
        {
            JsonSerializerOptions jsonSerializationOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            jsonSerializationOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
            config.UseSystemTextJson(jsonSerializationOptions);
        }

        /// <summary>
        /// Call a request that has no return other than HTTP Codes
        /// </summary>
        /// <typeparam name="TBody">The type of the body to be sent for the request</typeparam>
        /// <param name="request"The request to be sent></param>
        /// <returns></returns>
        public async Task Call<TBody>(IEngageBayRequest<TBody> request)
        {
            var restRequest = new RestRequest(request.Uri, request.Method);
            if (request.Body != null
                && !string.IsNullOrWhiteSpace(request.ContentType))
            {
                restRequest.AddBody(request.Body, request.ContentType);
            }
            RestResponse response = await _restClient.ExecuteAsync(restRequest);
            EnsureHTTPCode(response);
        }

        /// <summary>
        /// Call a request that has a returned object
        /// </summary>
        /// <typeparam name="TBody">Type of the body to be sent by the request</typeparam>
        /// <typeparam name="TResponse">Type of the response sent back from the API</typeparam>
        /// <param name="request">The request to send</param>
        /// <returns></returns>
        public async Task<TResponse> Call<TBody, TResponse>(IEngageBayRequest<TBody, TResponse> request)
        {
            var restRequest = new RestRequest(request.Uri, request.Method);
            if (request.Body != null
                && !string.IsNullOrWhiteSpace(request.ContentType))
            {
                restRequest.AddBody(request.Body, request.ContentType);
            }
            RestResponse<TResponse> response = await _restClient.ExecuteAsync<TResponse>(restRequest);
            EnsureHTTPCode(response);
            return response.Data;
        }

        private void EnsureHTTPCode(RestResponse response)
        {
            if (response.StatusCode >= System.Net.HttpStatusCode.OK && response.StatusCode < System.Net.HttpStatusCode.MultipleChoices)
            {
                response.ThrowIfError();
                return;
            }

            string fullErrorMessage = response.ErrorMessage + "\n" + response.Content;

            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new WrongApiKeyException(fullErrorMessage);
                case System.Net.HttpStatusCode.BadRequest:
                    throw new IncorrectQueryDataException(fullErrorMessage);
                case System.Net.HttpStatusCode.InternalServerError:
                    throw new EngageBayInternalServerErrorException(fullErrorMessage);
                case System.Net.HttpStatusCode.NotFound:
                    throw new EndpointNotFoundException();
            }

            throw new UnkwownEngageBayAPIException(fullErrorMessage);
        }
    }
}
