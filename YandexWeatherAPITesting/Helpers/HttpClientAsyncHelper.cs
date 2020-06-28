using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Yandex.Weather.API.Models;

namespace Yandex.Weather.API.Helpers
{
    public class HttpClientAsyncHelper
    {
        private HttpClient httpClient;

        private HttpClient AddHeadersAndCreateHttpClient(Dictionary<string, string> httpHeader)
        {
            HttpClient httpClient = new HttpClient();

            if (httpHeader != null)
            {
                foreach (var key in httpHeader.Keys)
                {
                    httpClient.DefaultRequestHeaders.Add(key, httpHeader[key]);
                }
            }
            return httpClient;
        }

        public async Task<RestResponse> PerformGetRequest(Uri requestUrl, Dictionary<string, string> httpHeader)
        {
            httpClient = AddHeadersAndCreateHttpClient(httpHeader);
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseContentRead);
            int statusCode = (int)httpResponseMessage.StatusCode;
            var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return new RestResponse(statusCode, responseData);
        }

        public async Task<RestResponse> PerformPostRequest(Uri requestUrl, HttpContent httpContent, Dictionary<string, string> httpHeader)
        {
            httpClient = AddHeadersAndCreateHttpClient(httpHeader);
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUrl, httpContent, CancellationToken.None);
            int statusCode = (int)httpResponseMessage.StatusCode;
            var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return new RestResponse(statusCode, responseData);
        }

        public async Task<RestResponse> PerformPostRequest(Uri requestUrl, string data, string mediaType, Dictionary<string, string> httpHeader)
        {
            httpClient = AddHeadersAndCreateHttpClient(httpHeader);
            HttpContent httpContent = new StringContent(data, Encoding.UTF8, mediaType);
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(requestUrl, httpContent, CancellationToken.None);
            int statusCode = (int)httpResponseMessage.StatusCode;
            var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return new RestResponse(statusCode, responseData);
        }

        public async Task<RestResponse> PerformPutRequest(Uri requestUrl, string content, string mediaType, Dictionary<string, string> httpHeader)
        {
            httpClient = AddHeadersAndCreateHttpClient(httpHeader);
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, mediaType);
            HttpResponseMessage httpResponseMessage = await httpClient.PutAsync(requestUrl, httpContent, CancellationToken.None);
            int statusCode = (int)httpResponseMessage.StatusCode;
            var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return new RestResponse(statusCode, responseData);
        }

        public async Task<RestResponse> PerformPutRequest(Uri requestUrl, HttpContent httpContent, Dictionary<string, string> httpHeader)
        {
            httpClient = AddHeadersAndCreateHttpClient(httpHeader);
            HttpResponseMessage httpResponseMessage = await httpClient.PutAsync(requestUrl, httpContent, CancellationToken.None);
            int statusCode = (int)httpResponseMessage.StatusCode;
            var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return new RestResponse(statusCode, responseData);
        }

        public async Task<RestResponse> PerformDeleteRequest(Uri requestUrl)
        {
            httpClient = AddHeadersAndCreateHttpClient(null);
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync(requestUrl, CancellationToken.None);
            int statusCode = (int)httpResponseMessage.StatusCode;
            var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return new RestResponse(statusCode, responseData);
        }

        //overloaded version 
        public async Task<RestResponse> PerformDeleteRequest(Uri requestUrl, Dictionary<string, string> httpHeader)
        {
            httpClient = AddHeadersAndCreateHttpClient(httpHeader);
            HttpResponseMessage httpResponseMessage = await httpClient.DeleteAsync(requestUrl, CancellationToken.None);
            int statusCode = (int)httpResponseMessage.StatusCode;
            var responseData = await httpResponseMessage.Content.ReadAsStringAsync();
            return new RestResponse(statusCode, responseData);
        }
    }
}
