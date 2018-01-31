using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSampleWeatherApp.Model
{
    [DataContract]
    public class Suggestion
    {
        [DataMember(Name = "car_washing")]
        public CarWashing CarWashing { get; set; }

        [DataMember(Name = "dressing")]
        public Dressing Dressing { get; set; }

        [DataMember(Name = "flu")]
        public Flu Flu { get; set; }

        [DataMember(Name = "sport")]
        public Sport Sport { get; set; }

        [DataMember(Name = "travel")]
        public Travel Travel { get; set; }

        [DataMember(Name = "uv")]
        public UV UV { get; set; }
    }

    [DataContract]
    public class SuggestionDetailedBase
    {
        [DataMember(Name = "brief")]
        public string Brief { get; set; }
        [DataMember(Name = "details")]
        public string Detailed { get; set; }
    }

    [DataContract]
    public class CarWashing : SuggestionDetailedBase
    {

    }
    [DataContract]
    public class Dressing : SuggestionDetailedBase
    {

    }
    [DataContract]
    public class Flu : SuggestionDetailedBase
    {

    }
    [DataContract]
    public class Sport : SuggestionDetailedBase
    {

    }
    [DataContract]
    public class Travel : SuggestionDetailedBase
    {

    }
    [DataContract]
    public class UV : SuggestionDetailedBase
    {

    }
}
