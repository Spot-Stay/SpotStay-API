using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace openapi데이터파싱
{
    // 1. CSV 데이터 구조와 일치하는 클래스 정의
    public class CampingSite
    {
        [Name("국립공원관리번호(ID_CD)")]
        public string ID_CD { get; set; }

        [Name("명칭_한글(KOR_NM)")]
        public string KOR_NM { get; set; }

        [Name("주소_지번(LNM_ADRES)")]
        public string LNM_ADRES { get; set; }

        [Name("전화번호(TELNO)")]
        public string TELNO { get; set; }

        [Name("야영동수(CMP_NUM)")]
        public int CMP_NUM { get; set; }

        [Name("경도(LONGITUDE)")]
        public float LONGITUDE { get; set; }

        [Name("위도(LATITUDE)")]
        public float LATITUDE { get; set; }


        public List<CampingSite> CsvPasing(string name)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);      //한글 깨짐

            string filePath = name;

            // 2. StreamReader와 CsvReader를 이용한 파싱
            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("euc-kr")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // CSV의 헤더명과 클래스의 프로퍼티명이 같으면 자동으로 매핑됩니다.
                List<CampingSite> records = csv.GetRecords<CampingSite>().ToList();

                return records;
            }
        }
    }
}
