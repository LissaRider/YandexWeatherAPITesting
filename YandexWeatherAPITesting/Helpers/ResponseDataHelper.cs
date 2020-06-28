using Newtonsoft.Json;
using System.IO;
using Yandex.Weather.API.Models;

namespace Yandex.Weather.API.Helpers
{
    public class ResponseDataHelper
    {
        //ResponseDataHelper.DeserializeJsonResponse<T>(restResponse.ResponseContent)
        public static T DeserializeJsonResponse<T>(string responseData) where T : class =>
            JsonConvert.DeserializeObject<T>(responseData);
    }
}