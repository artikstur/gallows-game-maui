using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GallowsGame.Utils.ApiClients.YandexApi
{
    internal class ApiClient
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "";
        private const string _baseUrl = "https://dictionary.yandex.net/api/v1/dicservice.json/lookup";

        public ApiClient()
        {
            _httpClient = new HttpClient();
            if (string.IsNullOrEmpty(ApiKey))
            {
                throw new ArgumentNullException(nameof(ApiKey));
            }
        }

        public async Task<DicResult?> LookupAsync(string text, string lang = "ru-ru", string ui = "en", int flags = 0)
        {
            var url = $"{_baseUrl}?key={ApiKey}&text={text}&lang={lang}&ui={ui}&flags={flags}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка: {response.StatusCode}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<DicResult>(jsonResponse);

            return result;
        }

        public async Task<bool> GetWordData(string word)
        {
            var result = await LookupAsync(word);

            if (result?.def.Length > 0)
            {
                foreach (var def in result.def)
                {
                    if (def.pos == "noun")
                    {
                        return true;
                    }

                    //foreach (var tr in def.tr)
                    //{
                    //    if (tr.pos == "noun")
                    //    {
                    //        return true;
                    //    }
                    //}
                }
            }

            return false;
        }
    }
}
