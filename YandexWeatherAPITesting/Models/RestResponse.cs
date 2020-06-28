namespace Yandex.Weather.API.Models
{
    public class RestResponse
    {
        public RestResponse(int statusCode, string responseData)
        {
            StatusCode = statusCode;
            ResponseContent = responseData;
        }

        public int StatusCode { get; }

        public string ResponseContent { get; }

        public override string ToString() =>
            string.Format("StatsCode : {0} ResponseData : {1}", StatusCode, ResponseContent);
    }
}
