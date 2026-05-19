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
    public class ViewPoint
    {
        [Name("명칭_한글(KOR_NM)")]
        public string KOR_NM { get; set; }

        [Name("경도(LONGITUDE)")]
        public string LONGITUDE { get; set; }

        [Name("위도(LATITUDE)")]
        public string LATITUDE { get; set; }


        public List<ViewPoint> CsvPasing(string filePath)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);      //한글 깨짐


            // 2. StreamReader와 CsvReader를 이용한 파싱
            using (var reader = new StreamReader(filePath, Encoding.GetEncoding("euc-kr")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // CSV의 헤더명과 클래스의 프로퍼티명이 같으면 자동으로 매핑됩니다.
                List<ViewPoint> records = csv.GetRecords<ViewPoint>().ToList();

                return records;
            }
        }
    }
}
