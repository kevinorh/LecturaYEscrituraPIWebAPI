using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LecturaYEscritura.UseCases.Home
{
    public class PIWebApiClient
    {
        private HttpClient client;
        private HttpClientHandler clientHandler;

        /* Initiating HttpClient using the default credentials.
         * This can be used with Kerberos authentication for PI Web API. */
        public PIWebApiClient()
        {
            clientHandler= new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
            /*{
                //UseDefaultCredentials = true,
                UseDefaultCredentials = false,
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) =>
               {
                   return true;
               },
                //SslProtocols = System.Security.Authentication.SslProtocols.None
            });*/

        }

        /* Initializing HttpClient by providing a username and password. The basic authentication header is added to the HttpClient.
         * This can be used with Basic authentication for PI Web API. */
        public PIWebApiClient(string userName, string password)
        {
            clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
            string authInfo = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(String.Format("{0}:{1}", userName, password)));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authInfo);
        }

        /* Disposing the HttpClient. */
        public void Dispose()
        {
            client.Dispose();
        }

        /* Async GET request. This method makes a HTTP GET request to the uri provided
         * and throws an exception if the response does not indicate a success. */
        public async Task<string> GetAsync(string uri)
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var responseMessage = "Response status code does not indicate success: " + (int)response.StatusCode + " (" + response.StatusCode + " ). ";
                throw new HttpRequestException(responseMessage + Environment.NewLine + content);
            }
            return JsonConvert.SerializeObject(content);
        }

        /* Async POST request. This method makes a HTTP POST request to the uri provided
         * and throws an exception if the response does not indicate a success. */
        public async Task PostAsync(string uri, string data)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header
            client.DefaultRequestHeaders.Add("X-Requested-With", "message/http");
            HttpResponseMessage response = await client.PostAsync(uri, new StringContent(data, Encoding.UTF8, "application/json"));

            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var responseMessage = "Response status code does not indicate success: " + (int)response.StatusCode + " (" + response.StatusCode + " ). ";
                throw new HttpRequestException(responseMessage + Environment.NewLine + content);
            }
        }
        /* Calling the GetAsync method and waiting for the results. */
        public string GetRequest(string url)
        {
            var t = this.GetAsync(url);
            t.Wait();
            return t.Result;
        }

        /* Calling the PostAsync method and waiting for the results. */
        public void PostRequest(string url, string data)
        {
            Task t = this.PostAsync(url, data);
            t.Wait();
        }
    }
}
