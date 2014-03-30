using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace ShareMemory
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = ConfigurationManager.AppSettings["MYSQL_CONNECTION_STRING"];
            //myConnectionString = "server=6a847837-1089-4ac6-a511-a2fe00305beb.mysql.sequelizer.com;database=db6a84783710894ac6a511a2fe00305beb;uid=zvezearwrycmmbik;pwd=?";
            string sql = "select * from TestMySQLDB where testid=@ID";
            string userID;
            string UserPsw;
            DataSet dataset;
            using (conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                using(MySqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new MySqlParameter("@ID", value));

                    dataset = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dataset);
                }
            }
            if(dataset.Tables[0].Rows.Count>0)
            {

                DataTable dt=dataset.Tables[0];
                DataRow row=dt.Rows[0];
                userID=row["userid"].ToString();
                UserPsw=row["password"].ToString();
                

            }
            else
            {
                return "No result";
            }
            return string.Format("TestID: {0} userid: {1} passwod: {2}", value,userID,UserPsw);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public int SetData(User user)
        {
            return 1;
        }
    }
}
