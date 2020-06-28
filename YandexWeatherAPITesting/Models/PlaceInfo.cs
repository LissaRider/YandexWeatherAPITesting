using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class PlaceInfo
    {
        [JsonProperty("lat")]
        public float Latitude { get; set; } // Широта(в градусах).

        [JsonProperty("lon")]
        public float Longitude { get; set; }    // Долгота(в градусах).

        [JsonProperty("def_pressure_mm")]
        public int DefPressureInMm { get; set; } // Норма давления для данной координаты (в мм рт. ст.).

        [JsonProperty("def_pressure_pa")]
        public int DefPressureInPa { get; set; } // Норма давления для данной координаты(в гектопаскалях).

        [JsonProperty("url")]
        public string CitySiteUrl { get; set; } // Страница населенного пункта на сайте Яндекс.Погода.

        [JsonProperty("tzinfo")]
        public TimeZoneInfo TimeZoneInfo { get; set; } // Информация о часовом поясе.
    }
}