using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class DarkSkyLocationModel
    {
        [DataMember]
        public float GeoPosition { get; set; }
    }

    [DataContract]
    class Currently
    {
        [DataMember]
        public float tempreature { get; set; }
    }
}
