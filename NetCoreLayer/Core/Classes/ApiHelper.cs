using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Core.Classes
{
    public class ApiHelper
    {
        private readonly IConfiguration _configuration;
        public static string baseAddress;
        public ApiHelper()
        {
            _configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();
            baseAddress = _configuration.GetSection("ApiUrl").Value ?? "";
        }

        public HttpClient APIInitial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            return client;
        }

        public static HttpClient WebApiClient = new HttpClient();


        public static string bodyRequest(string httpMethod, string route, IDictionary<string, object> postParams = null)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), $"{baseAddress}/{route}");

                if (postParams != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(postParams);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                try
                {
                    if (apiResponse != "")
                        return apiResponse;
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error ocurred while calling the API. It responded with the following message: {response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }
        public static string bodyRequestWithParameter(string httpMethod, string route, string parameter)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod(httpMethod), $"{baseAddress}/{route}/" + parameter);

                if (parameter != null)
                {
                    string jsonContent = JsonConvert.SerializeObject(parameter);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = client.SendAsync(requestMessage).Result;
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                try
                {
                    if (apiResponse != "")
                        return apiResponse;
                    else
                        throw new Exception();
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error ocurred while calling the API. It responded with the following message: {response.StatusCode} {response.ReasonPhrase}");
                }
            }
        }
    }
}
