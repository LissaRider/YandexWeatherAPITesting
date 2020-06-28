using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class Hours
    {
        [JsonProperty("hour")]
        public string Hour { get; set; }  // 	Значение часа, для которого дается прогноз (0-23), локальное время.

        [JsonProperty("hour_ts")]
        public int PredictionTimeUnix { get; set; }  // Время прогноза в Unixtime.

        [JsonProperty("temp")]
        public string Temperature { get; set; } // Максимальная дневная или минимальная ночная температура (°C).
       
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

        [JsonProperty("prec_mm")]
        public int ExpectedPrecipitationInMm { get; set; }  // Прогнозируемое количество осадков (в мм).

        [JsonProperty("prec_period")]
        public int ExpectedPrecipitationPeriodInMinutes { get; set; }   // Прогнозируемый период осадков (в минутах).

        [JsonProperty("prec_type")]
        public int PrecipitationType { get; set; }   // Тип осадков. 

        [JsonProperty("prec_strength")]
        public int PrecipitationStrength { get; set; }   // Сила осадков.

        [JsonProperty("is_thunder")]
        public int IsThunder { get; set; }   // Признак грозы.
        [JsonProperty("cloudness")]
        public int Cloudness { get; set; }   // Облачность.
    }
}