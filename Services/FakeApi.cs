using Newtonsoft.Json;
using ProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FakeApi : IData
    {
        private HttpClient httpClient = null;

        public async Task<List<Product>> GetProductData()
        {
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Host = "fakerapi.it";
            uriBuilder.Path += "/api/v1/products";
            uriBuilder.Scheme = "https";
            Dictionary<string, string> requestBody = new Dictionary<string, string>();

            var response = await(await SendRequest(uriBuilder.Uri, requestBody,false)).Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<ResponseObject>(response);
            return data.data.ToList();
        }
        private async Task<HttpResponseMessage> SendRequest(Uri uri, IDictionary<string, string> requestBody, bool usePost = true)
        {
            int tries = 0;

            while (tries < 2)
            {
                HttpRequestMessage httpRequest = new HttpRequestMessage(usePost ? HttpMethod.Post : HttpMethod.Get, uri);

                var httpClient = GetHTTPClient();

                HttpResponseMessage responseMessage = await httpClient.SendAsync(httpRequest, HttpCompletionOption.ResponseContentRead);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    // try to get the new token if expired meanwhile but not more that once during the call
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        tries++;
                        continue;
                    }

                    throw new ProtocolException(ProtocolException.Reason.HTTPError, $"Request failed! Server response: status={responseMessage.StatusCode}, phrase={responseMessage.ReasonPhrase}");
                }

                return responseMessage;
            }

            throw new InvalidOperationException("Internal programm error");
        }

        private HttpClient GetHTTPClient()
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }
            return httpClient;
        }

        private string FormUrlEncodedContent(IDictionary<string, string> requestBody)
        {
            string result = "";

            foreach (var item in requestBody)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += "&";
                }

                result += $"{item.Key}={item.Value}";
            }

            return result;
        }

       
    }
}
