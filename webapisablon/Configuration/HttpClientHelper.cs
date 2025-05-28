using System.Text;
using Newtonsoft.Json;

namespace webapisablon.Configuration
{
    public class HttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var dataAsString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(dataAsString);
            }
            return default;
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseContent);
            }

            throw new Exception($"API Hatası: {response.StatusCode} - {responseContent}");
        }

        public async Task<T> PostAsyncImage<T>(string url, HttpContent content)
        {
            var response = await _httpClient.PostAsync(url, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(responseContent);
            }

            throw new Exception($"API Hatası: {response.StatusCode} - {responseContent}");
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var dataAsString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(dataAsString);
            }
            return default;
        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API Hatası: {response.StatusCode} - {responseContent}");
                }

                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(responseData);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Request Hatası: {ex.Message}");
            }
        }
    }
}
