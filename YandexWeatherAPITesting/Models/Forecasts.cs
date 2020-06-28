using System.Collections.Generic;
using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class Forecasts
    {
        [JsonProperty("date")]
        public string Date { get; set; }    // Дата прогноза в формате ГГГГ-ММ-ДД.

        [JsonProperty("date_ts")]
        public int DateUnix { get; set; }   // Дата прогноза в формате Unixtime.

        [JsonProperty("week")]
        public int NumberOfWeek { get; set; }   // Порядковый номер недели.

        [JsonProperty("sunrise")]
        public string SunriseTime { get; set; } // Время восхода Солнца, локальное время (может отсутствовать для полярных регионов).

        [JsonProperty("sunset")]
        public string SunsetTime { get; set; }  // Время заката Солнца, локальное время (может отсутствовать для полярных регионов).

        [JsonProperty("moon_code")]
        public int MoonPhaseCode { get; set; }  // Код фазы Луны.

        [JsonProperty("moon_text")]
        public string MoonPhaseName { get; set; }   // Текстовый код для фазы Луны. 

        [JsonProperty("parts")]
        public Parts Parts { get; set; }   // Прогнозы по времени суток и 12-часовые прогнозы.

        [JsonProperty("hours")]
        public List<Hours> Hours { get; set; }   // Объект почасового прогноза погоды. Содержит 24 части (часа) в первые 2-3 суток, после возвращается пустая строка. 
    }
}
