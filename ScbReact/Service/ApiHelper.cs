using System.Net.Http.Headers;

namespace ScbReact.Service
{
    public static class ApiHelper
    {
        public static HttpClient ApiFetch { get; set; }
        public static void InitializeClient()
        {

            ApiFetch = new HttpClient();
            
            ApiFetch.DefaultRequestHeaders.Accept.Clear();
            ApiFetch.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
