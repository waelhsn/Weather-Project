using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WeatherProject
{

    public class GothenburgWeather
    {
        public async static Task<RootObject> GetWeather()
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://api.openweathermap.org/data/2.5/weather?lat=57.709203&lon=11.9642338&appid=2fd1aaaa85e1d7d52c0b96d4920346a4&units=metric&lang=se");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);
            return data;
        }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public List<Weather> weather { get; set; }
        [DataMember]
        public Main main { get; set; }
        [DataMember]
        public Wind wind { get; set; }
        [DataMember]
        //public Clouds clouds { get; set; }
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
    }
    [DataContract]
    public class Weather
    {
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string icon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember]
        public double temp { get; set; }
        [DataMember]
        public double feels_like { get; set; }
        [DataMember]
        public double temp_min { get; set; }
        [DataMember]
        public double temp_max { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember]
        public double speed { get; set; }
    }
}











