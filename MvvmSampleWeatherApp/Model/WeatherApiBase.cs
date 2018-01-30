using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{
    public class WeatherApiBase
    {
        public static WeatherApiBase Current { get; private set; }
        public WeatherApiBase()
        {
            Current = new WeatherApiBase();
        }

        public WeatherCollection Items { get; set; }
        public async Task<WeatherCollection> GetWeatherCollection()
        {
            var nowUrl = Constants.NowUrl;
            var nowResp = await Util.SendHttpRequestWithAuth(nowUrl, Constants.UID, Constants.TOKENKEY);
            var weatherCollection = Util.ParseJsonResult<WeatherCollection>(nowResp);
            if (weatherCollection != null)
            {
                Items = weatherCollection;
            }
            return weatherCollection;
        }

    }
}
