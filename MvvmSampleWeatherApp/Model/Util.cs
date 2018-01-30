using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{
    public class Util
    {
        public static async Task<string> SendHttpRequestWithAuth(string url, string uid, string tokenkey)
        {
            string respStr = "";
            try
            {
                if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(uid) || string.IsNullOrWhiteSpace(tokenkey))
                {
                    return "";
                }
                var uri = new Uri(url);
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(uid, tokenkey);
                respStr = await client.GetStringAsync(uri);
                var jsonObject = JsonConvert.DeserializeObject<WeatherCollection>(respStr);

                return respStr;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SendHttpRequest Error: {ex.Message}");
                return respStr;
            }

        }

        public static T ParseJsonResult<T>(string jsonStr)
        {
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<T>(jsonStr);
                return jsonObject;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ParseJsonResult Error: {ex.Message}");
                return default(T);
            }
        }
    }
}
