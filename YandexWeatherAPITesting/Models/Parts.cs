using Newtonsoft.Json;

namespace Yandex.Weather.API.Models
{
    public class Parts
    {
        [JsonProperty("night")]
        public Night Night { get; set; }    // прогноз на ночь.
        
        [JsonProperty("morning")]
        public Morning Morning { get; set; }    // прогноз на утро.
       
        [JsonProperty("day")]
        public Day Day { get; set; }    // прогноз на день.
        
        [JsonProperty("evening")]
        public Evening Evening { get; set; }    // прогноз на вечер.
        
        [JsonProperty("day_short")]
        public DayShort DayShort { get; set; }    // 12-часовой прогноз на день.

        [JsonProperty("night_short")]
        public NightShort NightShort { get; set; }    // прогноз на ночь, для которого исключены поля temp_min и temp_max, в поле temp указывается минимальная температура за ночной период.
    }
}
