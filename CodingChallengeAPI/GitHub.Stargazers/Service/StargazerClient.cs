using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace GitHub.Stargazers.Service
{
    public static class StargazerClient
    {
        private static HttpClient client;
        public static HttpClient StargazerClientConnection()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri($"https://api.github.com/repos/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "jaredmcrowley");
                return client;
            }
            return client;
        }
    }
}
