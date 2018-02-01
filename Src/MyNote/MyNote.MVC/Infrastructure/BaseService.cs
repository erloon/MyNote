using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Isam.Esent.Interop;
using Newtonsoft.Json;
using RestSharp;

namespace MyNote.MVC.Infrastructure
{
    public class BaseService
    {
        private readonly string _clientUrl;
        private readonly IStoreService _storeService;
        private readonly RestClient _restClient;

        public BaseService(string clientUrl, IStoreService storeService)
        {
            _clientUrl = clientUrl ?? throw new ArgumentNullException(nameof(clientUrl));
            _storeService = storeService ?? throw new ArgumentNullException(nameof(storeService));
            _restClient = new RestClient(_clientUrl);
        }

        private RestRequest CreateRequest(string actionUrl, Method method, string json)
        {
            var request = new RestRequest(actionUrl, method);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            return request;
        }

        private RestRequest CreateRequestWithCookie(string actionUrl, Method method, string json)
        {
            var request = new RestRequest(actionUrl, method);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            request.AddParameter(_storeService.Cookie.Name, _storeService.Cookie.Value, ParameterType.Cookie);
            return request;
        }

        private RestRequest CreateGetRequestWithCookie(string actionUrl, Method method)
        {
            var request = new RestRequest(actionUrl, method);
            request.AddParameter(_storeService.Cookie.Name, _storeService.Cookie.Value, ParameterType.Cookie);
            return request;
        }
        public async Task<Cookie> IdentityRequest<TResponse>(string actionUrl, Method method, string json)
            where TResponse : class, new()
        {
            var request = CreateRequest(actionUrl, method, json);
            IRestResponse<TResponse> response = null;
            var cancellationTokenSource = new CancellationTokenSource();
            CookieContainer cookiecon = new CookieContainer();
            Cookie cookie = null;
            response = await _restClient.ExecuteTaskAsync<TResponse>(request, cancellationTokenSource.Token);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var restsharpCookie = response.Cookies.FirstOrDefault();
                cookie = new Cookie(restsharpCookie.Name, restsharpCookie.Value, restsharpCookie.Path, restsharpCookie.Domain);
                cookiecon.Add(cookie);
            }

            _restClient.CookieContainer = cookiecon;
            return cookie;
        }

        public async Task<TResponse> PerformRequestWithCookie<TResponse>(string actionUrl, Method method, string json ="")
            where TResponse : class, new()
        {
            RestRequest request = null;

            if (json == "")
            {
                request = CreateGetRequestWithCookie(actionUrl, method);
            }
            request = CreateRequestWithCookie(actionUrl, method, json);
            IRestResponse<TResponse> response = null;
            var cancellationTokenSource = new CancellationTokenSource();

            response = await _restClient.ExecuteTaskAsync<TResponse>(request, cancellationTokenSource.Token);
            return response.Data;
        }

        public async Task<TResponse> PerformRequest<TResponse>(string actionUrl, Method method, string json)
            where TResponse : class, new()
        {
            var request = CreateRequest(actionUrl, method, json);
            IRestResponse<TResponse> response = null;
            var cancellationTokenSource = new CancellationTokenSource();

            response = await _restClient.ExecuteTaskAsync<TResponse>(request, cancellationTokenSource.Token);
            return response.Data;
        }

        protected string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        protected TResult Deserialize<TResult>(string value)
            where TResult : class, new()
        {
            return JsonConvert.DeserializeObject<TResult>(value);
        }
    }
}