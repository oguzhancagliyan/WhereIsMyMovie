using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WhereIsMyMovieUtility.Extensions;

namespace WhereIsMyMovieUtility.Managers
{
    public sealed class RequestManager
    {
        //private static HttpClient _httpClient = new HttpClient();
        private static readonly Lazy<RequestManager> lazy = new Lazy<RequestManager>();
        public static RequestManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }
        public async Task<T> GetAsyncWithStream<T>(string baseAdress, string requestUri, TimeSpan? timeOut)
        {

            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseAdress);
                _httpClient.Timeout = timeOut ?? new TimeSpan(0, 0, 30);

                var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    var result = stream.ReadAndDeserializeFromJson<T>();
                    return result;
                }
            }
        }
        public async Task<T> GetAsyncWithoutStream<T>(string baseAdress, string requestUri, TimeSpan? timeout)
        {
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseAdress);
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.Timeout = timeout ?? new TimeSpan(0, 0, 30);
                var response = await _httpClient.GetAsync(requestUri);
                var content = await response.Content.ReadAsStringAsync();
                var result = Activator.CreateInstance<T>();
                if (response.Content.Headers.ContentType.MediaType == "application/json")
                {
                    result = JsonConvert.DeserializeObject<T>(content);
                    return result;
                }
                else if (response.Content.Headers.ContentType.MediaType == "application/xml")
                {
                    var serializer = new XmlSerializer(typeof(T));
                    result = (T)serializer.Deserialize(new StreamReader(content));
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }
        public async Task<HttpResponseMessage> PostAsync<T>(T data, string baseAdress, string requestUri)
        {
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseAdress);
                var response = await _httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
                return response;
            }
        }
        public async Task<HttpResponseMessage> PutAsync<T>(T data, string baseAdress, string requestUri)
        {
            using (var _httpClient = new HttpClient())
            {
                _httpClient.BaseAddress = new Uri(baseAdress);
                var response = await _httpClient.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
                return response;
            }
        }
        /// <summary>
        /// Get HttpGet request with Restclient
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="data">T type data</param>
        /// <param name="baseAdress">the request baseadress</param>
        /// <param name="requestUri">the request url</param>
        /// <param name="headers">headers with string,string dictionary. dictionary key value  </param>
        /// <returns></returns>
        public async Task<T> GetAsyncWithRestClient<T>(string baseAdress, string requestUri, Dictionary<string, string> headers, List<Parameter> parameters) where T : class, new()
        {
            var client = new RestClient(baseAdress);
            var request = new RestRequest(requestUri);            
            foreach (var item in headers)
            {
                request.AddHeader(item.Key, item.Value);
            }
            if (parameters.Count > 0)
                request.Parameters.AddRange(parameters);
            var response = await client.ExecuteGetTaskAsync(request);
            var resposeFromExension = response.Content.GetDocumentFromString<T>(response.ContentType == "application/json" ? DeserializeFromString.ContentType.Json : DeserializeFromString.ContentType.Xml);
            return resposeFromExension;
        }
        public async Task PostAsyncWithRestClient<T>(T data,string baseAdress,string requestUri,Dictionary<string,string> headers,string a)
        {
            var client = new RestClient(baseAdress);
            var request = new RestRequest();
        }
    }
}
