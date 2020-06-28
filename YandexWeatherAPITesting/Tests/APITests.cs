using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Yandex.Weather.API.Helpers;
using Yandex.Weather.API.Models;

namespace Yandex.Weather.API.Tests
{
    [TestFixture]
    public class APITests
    {
        public string ApiUri { get; set; } = "https://api.weather.yandex.ru/v2/forecast?";
        public LanguageEnum Language { get; set; } = LanguageEnum.Null;
        public string AccessToken { get; set; } = ConfigurationManager.AppSettings["X-Yandex-API-Key"]; // X-Yandex-API-Key
        public string Latitude { get; set; } = "55,75322"; // Широта в градусах. Обязательное поле.
        public string Longitude { get; set; } = "37,62251"; // Долгота в градусах. Обязательное поле.
        public int Limit { get; set; } = 2; // Количество дней в прогнозе, включая текущий.
        public bool Hours { get; set; } = false;    // почасовой прогноз не возвращается.
        public bool Extra { get; set; } = false;    // значение по умолчанию, расширенная информация об осадках не возвращается.

        private HttpClientAsyncHelper HttpClientAsyncHelper => new HttpClientAsyncHelper();

        private Uri Uri => new Uri(new Uri(ApiUri), ParametersForLink);

        private string ParametersForLink
        {
            get
            {
                string str = $"?lat={Latitude}";    // Широта в градусах. Обязательное поле. (по умолчнию Москва)
                str += $"&lon={Longitude}"; // Долгота в градусах. Обязательное поле. (по умолчанию Москва)
                if (Language != LanguageEnum.Null) 
                    str += $"&lang={Language}"; // Сочетания языка и страны, для которых будут возвращены данные погодных формулировок.
                str += $"&limit={Limit}";   // Количество дней в прогнозе, включая текущий.
                str += $"&hours={Hours}";   // Для каждого из дней ответ будет содержать прогноз погоды по часам.
                str += $"&extra={Extra}";   // Расширенная информация об осадках. 
                return str;
            }
        }

        private RestResponse GetRestReponse()
        {
            Dictionary<string, string> httpHeader = new Dictionary<string, string>();
            httpHeader.Add("X-Yandex-API-Key", AccessToken);
            httpHeader.Add("Accept", "application/json");

            RestResponse restResponse = HttpClientAsyncHelper.PerformGetRequest(Uri, httpHeader).GetAwaiter().GetResult();
            Assert.AreEqual(200, restResponse.StatusCode);
            return restResponse;
        }

        private string GetSeason(DateTime date)
        {
            bool lastYearIsLeap = DateTime.IsLeapYear(date.Year - 1);
            bool thisIsLeap = DateTime.IsLeapYear(date.Year);
            bool nextYearIsLeap = DateTime.IsLeapYear(date.Year + 1);

            float summerStart = 6.21f;
            float autumnStart = 9.23f;
            float winterStart = 12.21f;

            //check if we need summer adjustment
            if (thisIsLeap) summerStart = 6.20f;
          
            //check if we need autumn adjustment
            if (thisIsLeap || lastYearIsLeap) autumnStart = 9.22f;
           
            //check if we need winter adjustment
            if (nextYearIsLeap) winterStart = 12.22f;

            if (date.Year == 2034 || date.Year == 2038) autumnStart -= 0.01f;

            float value = (float)date.Month + date.Day / 100f;   // <month>.<day(2 digit)>
            if (value < 3.20 || value >= winterStart) return "winter";
            if (value < summerStart) return "spring";
            if (value < autumnStart) return "summer";
            return "autumn";
        }

        /// <summary>
        /// lat - широта (в градусах) соответствует заданной вами;
        /// </summary>
        [Test]
        public void CheckForecastLatitude()
        {            
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            string actualLatitude = jsonData.Info.Latitude.ToString();
            Assert.AreEqual(Latitude, actualLatitude,
                $"\n  Ошибка! Значение широты (в градусах) в ответе не соответствует заданному." +
                $"\n  Ожидаемое значение: \"{Latitude}\"" +
                $"\n  Фактическое значение: \"{actualLatitude}\"\n");
        }

        /// <summary>
        /// lon - долгота (в градусах) соответствует заданной вами;
        /// </summary>
        [Test]
        public void CheckForecastLongitude()
        {
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            string actualLongitude = jsonData.Info.Longitude.ToString();
            Assert.AreEqual(Longitude, actualLongitude,
                $"\n  Ошибка! Значение долготы (в градусах) в ответе не соответствует заданному." +
                $"\n  Ожидаемое значение: \"{Longitude}\"" +
                $"\n  Фактическое значение: \"{actualLongitude}\"\n");
        }

        /// <summary>
        /// offset - проверьте часовой пояс;
        /// </summary>
        [Test]
        public void CheckForecastTimeZoneOffset()
        {
            var expectedOffset = 10800;
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            int actualOffset = jsonData.Info.TimeZoneInfo.Offset;
            Assert.AreEqual(expectedOffset, actualOffset,
                $"\n  Ошибка! Значение часового пояса (в секундах) в ответе не соответствует заданному." +
                $"\n  Ожидаемое значение: \"{expectedOffset}\"" +
                $"\n  Фактическое значение: \"{actualOffset}\"\n");
        }

        /// <summary>
        /// name - проверьте название часового пояса;
        /// </summary>
        [Test]
        public void CheckForecastTimeZoneName()
        {
            var expectedName = "Europe/Moscow";
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            string actualName = jsonData.Info.TimeZoneInfo.Name.ToString();
            Assert.AreEqual(expectedName, actualName,
                $"\n  Ошибка! Наименование часового пояса в ответе не соответствует заданному." +
                $"\n  Ожидаемое значение: \"{expectedName}\"" +
                $"\n  Фактическое значение: \"{actualName}\"\n");
        }

        /// <summary>
        ///  abbr - проверьте сокращенное название часового пояса;
        /// </summary>
        [Test]
        public void CheckForecastTimeZoneAbbrevation()
        {
            var expectedAbbr = "MSK";
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            string actualAbbr = jsonData.Info.TimeZoneInfo.Abbreviation.ToString();
            Assert.AreEqual(expectedAbbr, actualAbbr,
                $"\n  Ошибка! Cокращенное название часового пояса в ответе не соответствует заданному." +
                $"\n  Ожидаемое значение: \"{expectedAbbr}\"" +
                $"\n  Фактическое значение: \"{actualAbbr}\"\n");
        }

        /// <summary>
        /// dst - проверьте признак летнего времени;
        /// </summary>
        [Test]
        public void CheckForecastSummerTimeAttribute()
        {
            var expectedSummerTimeAttribute = false;
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            bool actualSummerTimeAttribute = jsonData.Info.TimeZoneInfo.IsSummerTime;
            Assert.AreEqual(expectedSummerTimeAttribute, actualSummerTimeAttribute,
                $"\n  Ошибка! Признак летнего времени в ответе не соответствует заданному." +
                $"\n  Ожидаемое значение: \"{expectedSummerTimeAttribute}\"" +
                $"\n  Фактическое значение: \"{actualSummerTimeAttribute}\"\n");
        }

        /// <summary>
        /// url - проверьте страницу населенного пункта, убедитесь что ссылка правильная, что
        /// широта и долгота внутри ссылки указаны верные
        /// в версии 2 внутри ссылки нет координат
        /// </summary>
        [Test]
        public void CheckForecastUrl()
        {
            string expectedUrl = "https://yandex.ru/pogoda/moscow";           
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            string actualUrl = jsonData.Info.CitySiteUrl.ToString();
            Assert.AreEqual(expectedUrl, actualUrl,
                $"\n  Ошибка! Значение страницы населенного пункта на сайте в ответе не соответствует заданному." +
                $"\n  Ожидаемое значение: \"{expectedUrl}\"" +
                $"\n  Фактическое значение: \"{actualUrl}\"\n");
        }

        /// <summary>
        /// Проверьте длину прогноза, убедитесь что прогноз действительно на два дня;
        /// </summary>
        [Test]
        public void CheckForecastDuration()
        {
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            var actualForecastsCount = jsonData.Forecasts.Count;
            Assert.AreEqual(Limit, actualForecastsCount,
               $"\n  Ошибка! Количество прогнозов в ответе не соответствует заданному." +
               $"\n  Ожидаемое значение: \"{Limit}\"" +
               $"\n  Фактическое значение: \"{actualForecastsCount}\"\n");
        }

        /// <summary>
        /// season - проверьте сезон;
        /// </summary>
        [Test]
        public void CheckForecastSeason()
        {
            var expectedSeason = GetSeason(DateTime.Now);           
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            string actualSeason = jsonData.Fact.Season.ToString();          
            Assert.AreEqual(expectedSeason, actualSeason,
               $"\n  Ошибка! Время года в данном населенном пункте в ответе не соответствует актуальному." +
               $"\n  Ожидаемое значение: \"{expectedSeason}\"" +
               $"\n  Фактическое значение: \"{actualSeason}\"\n");
        }

        /// <summary>
        /// Напишите логику и проверьте, что код фазы луны на второй день moon_code
        /// соответсвует текстовому коду moon_text.
        /// в версии 2 moon_text=$"moon-code-{moon_code}"
        /// </summary>
        [Test]
        public void CheckForecastMoonText()
        {            
            RestResponse restResponse = GetRestReponse();
            WeatherInfo jsonData = ResponseDataHelper.DeserializeJsonResponse<WeatherInfo>(restResponse.ResponseContent);
            string moonCode = jsonData.Forecasts[1].MoonPhaseCode.ToString();
            string actualMoonText = jsonData.Forecasts[1].MoonPhaseName.ToString();
            var expectedMoonText = $"moon-code-{moonCode}";           
            Assert.AreEqual(expectedMoonText, actualMoonText,
               $"\n  Ошибка! В ответе код фазы луны на второй день не соответствует текстовому коду." +
               $"\n  Ожидаемое значение: \"{expectedMoonText}\"" +
               $"\n  Фактическое значение: \"{actualMoonText}\"\n"); ;
        }
    }

    public enum LanguageEnum
    {
        Null,   // язык по умолчанию (Русский).
        ru_RU,  // русский язык для домена России.
        ru_UA,  // русский язык для домена Украины.
        uk_UA,  // украинский язык для домена Украины.
        be_BY,  // белорусский язык для домена Беларуси.
        kk_KZ,  // казахский язык для домена Казахстана.
        tr_TR,  // турецкий язык для домена Турции.
        en_US   // международный английский.
    }
}