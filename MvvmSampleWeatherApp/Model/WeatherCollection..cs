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
        public Location location { get; set; }

        [DataMember(Name = "last_update")]
        public string last_update { get; set; }

        [DataMember(Name = "now")]
        public Now now { get; set; }

        [DataMember(Name = "daily")]
        public Daily[] daily { get; set; }

    }

    [DataContract]
    public class WeatherCollection
    {
        [DataMember(Name = "results")]
        public Weather[] results { get; set; }
    }
}
