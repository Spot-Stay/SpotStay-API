namespace KakaoLocal
{
    public class KakaoLocalResult
    {
        public LocalMeta? meta { get; set; }         //응답관련 정보

        public List<KakaoLocalApi>? documents { get; set; }  //응답 결과
    }

    public class LocalMeta
    {
        public int total_count { get; set; } // 검색된 전체 결과 수
    }


    // 실제 장소 데이터 요소
    public class KakaoLocalApi
    {
        public string? place_name { get; set; } // 장소명

        public string? address_name { get; set; } // 전체 지번 주소

        public string? road_address_name { get; set; } // 전체 도로명 주소

        public string? x { get; set; } // 경도 

        public string? y { get; set; } // 위도
    }
}
