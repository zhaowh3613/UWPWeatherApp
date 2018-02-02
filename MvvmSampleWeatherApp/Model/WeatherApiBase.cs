using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{
    public class WeatherApiBase
    {
        private static WeatherApiBase _instance;
        public static WeatherApiBase Instance
        {
            get
            {
                return _instance ?? (_instance = new WeatherApiBase());
            }
        }

        public WeatherApiBase()
        {
        }

        public WeatherCollection Items { get; set; }
        private async Task<WeatherCollection> GetWeatherCollection(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    return null;
                }
                var resp = await Util.SendHttpRequestWithAuth(url, Constants.UID, Constants.TOKENKEY);
                var weatherCollection = Util.ParseJsonResult<WeatherCollection>(resp);
                return weatherCollection;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"GetWeatherCollection Error: {ex.Message}");
                return null;
            }
        }

        public async Task<WeatherCollection> GetWeatherNow(string city = "beijing")
        {
            var url = String.Format(Constants.NowUrl, city.Trim());
            var collection = await GetWeatherCollection(url);
            return collection;
        }

        public async Task<WeatherCollection> GetWeatherDaily(string city = "beijing")
        {
            var url = String.Format(Constants.DailyUrl, Constants.TOKENKEY, city.Trim());
            var collection = await GetWeatherCollection(url);
            return collection;
        }

        public async Task<WeatherCollection> GetWeatherSuggestion(string city = "beijing")
        {
            var url = String.Format(Constants.SuggestionUrl, city.Trim());
            var collection = await GetWeatherCollection(url);
            return collection;
        }
    }
}
