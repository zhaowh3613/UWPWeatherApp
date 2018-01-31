using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{
    [DataContract]
    public class Weather
    {

        [DataMember(Name = "location")]
        public Location Location { get; set; }

        [DataMember(Name = "last_update")]
        public string LastUpdate { get; set; }
        public string BGUrl { get; set; }

        [DataMember(Name = "now")]
        public Now Now { get; set; }

        [DataMember(Name = "daily")]
        public Daily[] Daily { get; set; }

    }

    [DataContract]
    public class WeatherCollection
    {
        [DataMember(Name = "results")]
        public Weather[] results { get; set; }
    }
}
