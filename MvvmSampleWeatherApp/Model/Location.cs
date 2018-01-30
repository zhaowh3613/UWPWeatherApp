using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{
    [DataContract]
    public class Location
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "name")]
        public string name { get; set; }
        [DataMember(Name = "country")]
        public string country { get; set; }
        [DataMember(Name = "timezone")]
        public string timezone { get; set; }
        [DataMember(Name = "timezone_offset")]
        public string timezone_offset { get; set; }
    }
}
