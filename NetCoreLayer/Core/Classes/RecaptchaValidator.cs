using Core.Interfaces;
using Core.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class RecaptchaValidator :IRecaptchaValidator
    {
        private readonly IConfiguration _configuration;
        private static string GoogleSecretKey { get; set; }
        private static string GoogleRecaptchaVerifyApi { get; set; }
        private static decimal RecaptchaThreshold { get; set; }
        public RecaptchaValidator()
        {
            _configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .Build();

            GoogleRecaptchaVerifyApi = _configuration.GetSection("GoogleRecaptcha").GetSection("VefiyAPIAddress").Value ?? "";
            GoogleSecretKey = _configuration.GetSection("GoogleRecaptcha").GetSection("RecaptchaV3SecretKey").Value ?? "";

            var hasThresholdValue = decimal.TryParse(_configuration.GetSection("GoogleRecaptcha").GetSection("RecaptchaMinScore").Value ?? "", out var threshold);
            if (hasThresholdValue)
            {
                RecaptchaThreshold = threshold;
            }
        }

        public async Task<bool> RecaptchaVerifyAsync(string token)
        {
            if (String.IsNullOrEmpty(token))
            {
                throw new Exception("Token cannot be null!");
            }
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync($"{GoogleRecaptchaVerifyApi}?secret={GoogleSecretKey}&response={token}");
                var tokenResponse = JsonConvert.DeserializeObject<RecaptchaModel>(response);
                if (!tokenResponse.Success || tokenResponse.Score < RecaptchaThreshold)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
