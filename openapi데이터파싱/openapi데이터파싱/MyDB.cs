//MyDB.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Threading;        //MS SQL

namespace openapi데이터파싱
{
    //p.102
    internal class MyDB
    {
        #region 서버 연결 정보
        private const string SERVER_NAME = "bit85\\SQLEXPRESS";
        private const string DB_NAME = "WB43";
        private const string USER_ID = "ccm";
        private const string USER_PW = "1234";
        private SqlConnection scon = null;
        #endregion

        #region  1. SQLConnection (연결, 속성, 종료)
        public bool Open()
        {
            try
            {
                string constr = $@"Data Source={SERVER_NAME};Initial Catalog={DB_NAME}; User ID={USER_ID};Password={USER_PW}";
                scon = new SqlConnection(constr);
                scon.Open(); //연결 열기
                             //작업 수행
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        public void ServerInfo()
        {
            if (scon.State == ConnectionState.Open)
            {
                Console.WriteLine(scon.WorkstationId);
                Console.WriteLine(scon.ServerVersion);
                Console.WriteLine(scon.PacketSize);
                Console.WriteLine(scon.ConnectionTimeout);
                Console.WriteLine(scon.Database);
                Console.WriteLine(scon.DataSource);
                Console.WriteLine(scon.State);

            }
            else
            {
                Console.WriteLine("서버 상태 확인");
            }
        }
        public bool Close()
        {
            //if (scon.State == System.Data.ConnectionState.Open)
            //    scon.Close();
            try
            {
                scon.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        #endregion

        #region  2. Insert
        public bool Insert(string Name, string ParkName, string Address, string Phone, int SiteCount, float Latitude , float Longitude)
        {
            try
            {
                string sql = $"insert into  CampSite  values ('{Name}', '{ParkName}','{Address}', '{Phone}',{SiteCount}, {Latitude},{Longitude});";
                ExecCommand(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }


        public bool Insert2(string KOR_NM, string LONGITUDE, string LATITUDE)
        {
            try
            {
                string sql = $"insert into ViewPoint values (' ', ' ', '{KOR_NM}', '{LONGITUDE}', '{LATITUDE}');";
                ExecCommand(sql);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
        #endregion




        #region 2.1 (Insert, Update, Delete 용 명령 함수)
        private void ExecCommand(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, scon);
            try
            {
                if (cmd.ExecuteNonQuery() == 0)  //명령을 수행하고 영향을 받은 행의 수를 반환
                {
                    throw new Exception("row데이터 변경 없다");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
        }
        #endregion
        
    }
}
