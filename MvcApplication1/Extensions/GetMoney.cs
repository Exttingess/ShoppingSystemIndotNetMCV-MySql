using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace MvcApplication1.Extensions
{
    public class GetMoney
    {


        private readonly string constr = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;

        public string LookMoney(string name)
        {
            

            MySqlConnection myconn = null;
            MySqlCommand mycom = null;
            string sum="";
            myconn = new MySqlConnection(constr);
            myconn.Open();
            mycom = myconn.CreateCommand();
            mycom.CommandText = "SELECT sum FROM register WHERE name='" + name+"'";        //操作语句

            //读取数据
            MySqlDataReader reader = mycom.ExecuteReader();
            if (reader.Read())
            {
                sum= reader.GetString(0);
                

            }
             //关闭连接
            myconn.Close();
            //返回该类
            return sum;

           
           
        }

        public void UpdateMoney(string name,decimal num)
        {
            MySqlConnection myconn = null;
            MySqlCommand mycom = null;
            
            myconn = new MySqlConnection(constr);
            myconn.Open();




            mycom = myconn.CreateCommand();
            mycom.CommandText = "UPDATE register SET sum="+ num +"WHERE name='" + name+"'";        //操作语句


            //读取数据
            int n = mycom.ExecuteNonQuery();

            //关闭连接
            myconn.Close();
            //返回该类
            

        }
       

    }
}