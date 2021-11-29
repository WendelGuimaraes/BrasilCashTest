using RestSharp;

namespace BrasilCashTest.Services
{
    public class RestService
    {
        public static T Get<T>(string url, string method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method, Method.GET);
            var result = client.Execute<T>(request);
            return result.Data;
        }
    }
}
