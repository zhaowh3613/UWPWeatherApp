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
        public string Text { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "temperature")]
        public string Temperature { get; set; }

        [DataMember(Name = "feels_like")]
        public string FeelsLike { get; set; }

        [DataMember(Name = "pressure")]
        public string Pressure { get; set; }

        [DataMember(Name = "humidity")]
        public string Humidity { get; set; }

        [DataMember(Name = "visibility")]
        public string Visibility { get; set; }

        [DataMember(Name = "wind_direction_degree")]
        public string WindDirectionDegree { get; set; }

        [DataMember(Name = "wind_speed")]
        public string WindSpeed { get; set; }

        [DataMember(Name = "wind_scale")]
        public string WindScale { get; set; }

        [DataMember(Name = "clouds")]
        public string Clouds { get; set; }

        [DataMember(Name = "dew_point")]
        public string DewPoint { get; set; }
    }
}
