using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace openapi데이터파싱
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MyDB db = new MyDB();
            db.Open();
            
            
            CampingSite site = new CampingSite();
            List<CampingSite> l = site.CsvPasing(@"C:\Users\aaa\Desktop\몰입형 프로젝트\openapi데이터파싱\야영장.csv");

            foreach (CampingSite c in l)
            {
                db.Insert(c.ID_CD, c.KOR_NM, c.LNM_ADRES, c.TELNO, c.CMP_NUM, c.LONGITUDE, c.LATITUDE);
            }

            //ViewPoint site = new ViewPoint();
            //List<ViewPoint> L = site.CsvPasing("조망점.csv");

            //foreach (ViewPoint c in L)
            //{
            //    db.Insert2(c.KOR_NM, c.LONGITUDE, c.LATITUDE);
            //}



        }
    }
}
