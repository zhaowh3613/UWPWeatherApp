using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{
    [DataContract]
    public class Daily
    {
        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "text_day")]
        public string TextDay { get; set; }

        [DataMember(Name = "code_day")]
        public string CodeDay { get; set; }

        [DataMember(Name = "text_night")]
        public string TextNight { get; set; }

        [DataMember(Name = "code_night")]
        public string CodeNight { get; set; }

        [DataMember(Name = "high")]
        public string High { get; set; }

        [DataMember(Name = "low")]
        public string Low { get; set; }

        [DataMember(Name = "precip")]
        public string Precip { get; set; }

        [DataMember(Name = "wind_direction")]
        public string WindDirection { get; set; }

        [DataMember(Name = "wind_direction_degree")]
        public string WindDirectionDegree { get; set; }

        [DataMember(Name = "wind_speed")]
        public string WindSpeed { get; set; }

        [DataMember(Name = "wind_scale")]
        public string WindSWcale { get; set; }
    }
    
}
