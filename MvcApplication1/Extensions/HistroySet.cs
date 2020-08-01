using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MvcApplication1.Extensions
{

    public class HistroySet
    {
        private readonly string constr = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;


        //shopping表，记录用户的购物记录
        public void SetList(int id,string name,decimal cost,string accode)
        {
            MySqlConnection myconn = null;
            MySqlCommand mycom = null;

            myconn = new MySqlConnection(constr);
            myconn.Open();



            mycom = myconn.CreateCommand();
            mycom.CommandText = "insert into shopping(id,user,cost,accountcode,accountdate) values ('" + id + "','" + name + "','" + cost + "','" + accode + "','" + DateTime.Now + "')";        //操作语句


            //读取数据
            int n = mycom.ExecuteNonQuery();

            //关闭连接
            myconn.Close();



        }
        //string s1 = "insert into shopping(id,user,cost,accountcode,accountdate) values ('" + id + "','" + name + "','" + cost + "','" + accode + "','" + DateTime.Now + "')";                            //编写SQL命令


        //shopppingby，记录被购买商品的数据
        public void SetProduct(int id, string name, int no,int num)
        {
            MySqlConnection myconn = null;
            MySqlCommand mycom = null;

            myconn = new MySqlConnection(constr);
            myconn.Open();



            mycom = myconn.CreateCommand();
            mycom.CommandText = "insert into shopping(id,user,product_id,num,date) values ('" + id + "','" + name + "','" + no + "','" + num + "','" + DateTime.Now + "')";        //操作语句


            //读取数据
            int n = mycom.ExecuteNonQuery();

            //关闭连接
            myconn.Close();



        }



    }

}
