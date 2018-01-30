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
        public string date { get; set; }

        [DataMember(Name = "text_day")]
        public string text_day { get; set; }

        [DataMember(Name = "code_day")]
        public string code_day { get; set; }

        [DataMember(Name = "text_night")]
        public string text_night { get; set; }

        [DataMember(Name = "code_night")]
        public string code_night { get; set; }

        [DataMember(Name = "high")]
        public string high { get; set; }

        [DataMember(Name = "low")]
        public string low { get; set; }

        [DataMember(Name = "precip")]
        public string precip { get; set; }

        [DataMember(Name = "wind_direction")]
        public string wind_direction { get; set; }

        [DataMember(Name = "wind_direction_degree")]
        public string wind_direction_degree { get; set; }

        [DataMember(Name = "wind_speed")]
        public string wind_speed { get; set; }

        [DataMember(Name = "wind_scale")]
        public string wind_scale { get; set; }
    }
    
}
