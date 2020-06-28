using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class TimeZoneInfo
    {
        [JsonProperty("offset")]
        public int Offset { get; set; } // Часовой пояс в секундах от UTC.
        
        [JsonProperty("name")]
        public string Name { get; set; } // Название часового пояса.

        [JsonProperty("abbr")]
        public string Abbreviation { get; set; } // Сокращенное название часового пояса.

        [JsonProperty("dst")]
        public bool IsSummerTime { get; set; } // Признак летнего времени.
    }
}