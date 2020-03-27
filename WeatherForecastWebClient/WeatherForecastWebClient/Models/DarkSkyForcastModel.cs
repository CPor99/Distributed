using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace WeatherForecastWebClient.Models
{
    [DataContract]
    class DarkSkyForcastModel
    {
        [DataMember]
        public Daily daily;
    }

    [DataContract]
    class Daily
    {
        [DataMember]
        public List<Data> data { get; set; }
    }

    [DataContract]
    class Data
    {
        [DataMember]
        public long time { get; set; }
        [DataMember]
        public float temp_min { get; set; }
        [DataMember]
        public float temp_max { get; set; }
    }
}
