using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class ClimaCellModel
    {
        [DataMember]
        public Main main { get; set; }
    }

    [DataContract]
    class Main
    {
        [DataMember]
        public float longitude { get; set; }
        [DataMember]
        public float latitude { get; set; }
    }
}
