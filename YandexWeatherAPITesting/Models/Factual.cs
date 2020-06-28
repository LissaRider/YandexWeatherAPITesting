using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class Factual
    {
        [JsonProperty("temp")]
        public int Temperature { get; set; }    // Температура (°C).

        [JsonProperty("feels_like")]
        public int FeelsLikeTemperature { get; set; }     // Ощущаемая температура (°C).

        [JsonProperty("temp_water")]
        public int WaterTemperature { get; set; }   // Температура воды (°C). Параметр возвращается для населенных пунктов, где данная информация актуальна.

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

        [JsonProperty("pressure_pa")]   // Давление (в гектопаскалях).
        public int PressureInPa { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }   // Влажность воздуха (в процентах).

        [JsonProperty("daytime")]
        public string DayTime { get; set; } // Светлое или темное время суток.

        [JsonProperty("polar")]
        public bool Polar { get; set; } // Признак того, что время суток, указанное в поле daytime, является полярным.

        [JsonProperty("season")]
        public string Season { get; set; }  // Время года в данном населенном пункте.

        [JsonProperty("obs_time")]
        public int TimeOfMeasurementUnix { get; set; }  // 	Время замера погодных данных в формате Unixtime.

        [JsonProperty("is_thunder")]
        public bool IsThunder { get; set; }  // Признак грозы.

        [JsonProperty("prec_type")]
        public int PrecipitationType { get; set; }  // Тип осадков.

        [JsonProperty("prec_strength")]
        public int PrecipitationЫtrength { get; set; }  // Сила осадков.

        [JsonProperty("cloudness")]
        public int Сloudness { get; set; }  // Облачность.

        [JsonProperty("phenom_icon")]
        public string PhenomIcon { get; set; }  // Код дополнительной иконки погодного явления. Обрабатывается по аналогии с icon.

        [JsonProperty("phenom_condition")]
        public int PhenomCondition { get; set; }  // Код расшифровки дополнительного погодного описания. Обрабатывается по аналогии с condition.
    }
}
