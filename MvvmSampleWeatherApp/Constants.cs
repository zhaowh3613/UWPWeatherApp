using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp
{
    public class Constants
    {
        public static readonly String TOKENKEY = "hwgl4pd1vl4qrkka";
        public static readonly String UID = "UE5A5FDF53";
        public static String NowUrl = "https://api.seniverse.com/v3/weather/now.json?key=" + TOKENKEY + "&location={0}&language=en&unit=c";
        //public static String NowUrl = $"https://api.seniverse.com/v3/weather/now.json?key={TOKENKEY}&location=beijing&language=en&unit=c";
        public static String DailyUrl = $" https://api.seniverse.com/v3/weather/daily.json?key={TOKENKEY}&location=beijing&language=en&unit=c&start=0&days=5";

    }
}
