﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace GitHub.Repositories.Service
{
    public static class RepoClient
    {
        private static HttpClient client;
        public static HttpClient RepoClientConnection()
        {
            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://api.github.com/users/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "jaredmcrowley");
                return client;
            }
            return client;
        }
    }
}
