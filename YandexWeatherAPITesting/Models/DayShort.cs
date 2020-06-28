using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class DayShort
    {
        [JsonProperty("temp")]
        public string Temperature { get; set; } // Максимальная дневная или минимальная ночная температура (°C).

        [JsonProperty("temp_min")]
        public int DayTemperatureMinimum { get; set; }  // Минимальная температура для времени суток (°C).

        [JsonProperty("feels_like")]
        public int FeelsLikeTemperature { get; set; }   // Ощущаемая температура (°C).

        [JsonProperty("icon")]
        public string IconUrl { get; set; } // Код иконки погоды. Иконка доступна по адресу https://yastatic.net/weather/i/icons/blueye/color/svg/<значение из поля icon>.svg.

        [JsonProperty("condition")]
        public string Condition { get; set; }   // Код расшифровки погодного описания. 

        [JsonProperty("wind_speed")]
        public float WindSpeed { get; set; }    // Скорость ветра (в м/с).

        [JsonProperty("wind_gust")]
        public float WindGust { get; set; } // Скорость порывов ветра (в м/с).

        [JsonProperty("wind_dir")]
        public string WindDirection { get; set; }   // Направление ветра. 

        [JsonProperty("pressure_mm")]
        public int PressureInMm { get; set; }   // Давление (в мм рт. ст.).

        [JsonProperty("pressure_pa")]
        public int PressureInPa { get; set; }   // Давление (в гектопаскалях).

        [JsonProperty("humidity")]
        public int Humidity { get; set; }   // Влажность воздуха (в процентах).

        [JsonProperty("prec_type")]
        public int PrecipitationType { get; set; }   // Тип осадков. 

        [JsonProperty("prec_strength")]
        public int PrecipitationStrength { get; set; }   // Сила осадков. 

        [JsonProperty("cloudness")]
        public int Cloudness { get; set; }   // Облачность.
    }
}