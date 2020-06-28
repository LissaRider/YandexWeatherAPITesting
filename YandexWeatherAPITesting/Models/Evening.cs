using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class Evening
    {
        public class Night
        {
            [JsonProperty("temp_min")]
            public int DayTemperatureMinimum { get; set; }  // Минимальная температура для времени суток (°C).

            [JsonProperty("temp_max")]
            public int DayTemperatureMaximum { get; set; }  // Максимальная температура для времени суток (°C).

            [JsonProperty("temp_avg")]
            public int AverageTemperature { get; set; } // Средняя температура для времени суток (°C).

            [JsonProperty("feels_like")]
            public int FeelsLikeTemperature { get; set; }   // Ощущаемая температура (°C).

            [JsonProperty("icon")]
            public string IconUrl { get; set; } // Код иконки погоды. Иконка доступна по адресу https://yastatic.net/weather/i/icons/blueye/color/svg/<значение из поля icon>.svg.

            [JsonProperty("condition")]
            public string Condition { get; set; }   // Код расшифровки погодного описания. 

            [JsonProperty("daytime")]
            public string DayTime { get; set; } // Светлое или темное время суток.

            [JsonProperty("polar")]
            public bool Polar { get; set; } // Признак того, что время суток, указанное в поле daytime, является полярным.

            [JsonProperty("wind_speed")]
            public float WindSpeed { get; set; }    // Скорость ветра (в м/с).

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

            [JsonProperty("cloudness")]
            public int Cloudness { get; set; }   // Облачность.
        }
    }
}