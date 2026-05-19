using System.Text.Json;
using System.Web;
using KakaoLocal;

namespace KakaoLocal
{
    public class LocalService : ILocalService
    {
        HttpClient client = new HttpClient();

        private readonly string _kakaoRestApiKey;

        // 생성자를 통해 IConfiguration을 주입받습니다.
        public LocalService(IConfiguration configuration)
        {
            _kakaoRestApiKey = configuration["ApiKeys:KakaoRestApiKey"]
                               ?? throw new InvalidOperationException("KakaoRestApiKey not found.");
        }

        public async Task<KakaoLocalResult?> SearchPlaceAsync(string keyword)
        {
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Add("Authorization", $"KakaoAK {_kakaoRestApiKey}");

            string encodedKeyword = HttpUtility.UrlEncode(keyword);
            string requestUrl = $"https://dapi.kakao.com/v2/local/search/keyword.json?query={encodedKeyword}";

            HttpResponseMessage response = await client.GetAsync(requestUrl);


            if (response.IsSuccessStatusCode)
            {
                // 수신된 JSON 텍스트 추출
                string jsonString = await response.Content.ReadAsStringAsync();

                // JSON 데이터를 C# 객체 구조로 변환
                KakaoLocalResult? result = JsonSerializer.Deserialize<KakaoLocalResult>(jsonString);

                return result;
            }
            else
            {
                // HTTP 상태 코드가 200이 아닌 경우 
                Console.WriteLine($"API 호출 실패. 상태 코드: {response.StatusCode}");
                return null;
            }
        }
    }
}
