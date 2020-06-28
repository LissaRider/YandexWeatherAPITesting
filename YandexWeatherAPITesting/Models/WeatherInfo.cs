using Newtonsoft.Json;
using System.Collections.Generic;

namespace Yandex.Weather.API.Models
{
    public class WeatherInfo
    {
        [JsonProperty("now")]
        public int ServerTimeUnix { get; set; } // Время сервера в формате Unixtime.

        [JsonProperty("now_dt")]
        public string ServerTimeUtc { get; set; } // Время сервера в UTC.

        [JsonProperty("info")]
        public PlaceInfo Info { get; set; } // Объект информации о населенном пункте.

        [JsonProperty("fact")]
        public Factual Fact { get; set; }   // Объект фактической информации о погоде.

        [JsonProperty("forecasts")]
        public List<Forecasts> Forecasts { get; set; }  // Объект прогнозной информации о погоде.
    }
}