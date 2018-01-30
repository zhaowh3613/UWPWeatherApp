using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{

    [DataContract]
    public class Now
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "code")]
        public string code { get; set; }

        [DataMember(Name = "temperature")]
        public string temperature { get; set; }

        [DataMember(Name = "feels_like")]
        public string feels_like { get; set; }

        [DataMember(Name = "pressure")]
        public string pressure { get; set; }

        [DataMember(Name = "humidity")]
        public string humidity { get; set; }

        [DataMember(Name = "visibility")]
        public string visibility { get; set; }

        [DataMember(Name = "wind_direction_degree")]
        public string wind_direction_degree { get; set; }

        [DataMember(Name = "wind_speed")]
        public string wind_speed { get; set; }

        [DataMember(Name = "wind_scale")]
        public string wind_scale { get; set; }

        [DataMember(Name = "clouds")]
        public string clouds { get; set; }

        [DataMember(Name = "dew_point")]
        public string dew_point { get; set; }
    }
}
