using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace MvcApplication1.Extensions
{
    public class LoginCart
    {
        private int n;
        private readonly string constr = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;

        public bool compition(string a, string b)
        {

            //string conns = "server=127.0.0.1;User Id=root;password=123456;Database=c#";
            //MySqlConnection mySql = new MySqlConnection(conns);

            string username = a;  //取出账号
            string pw = b;         //取出密码

            //MD5
            GetMD5 mD5 = new GetMD5();
            string passwdmd = mD5.Md5(pw);



            //string constr = "server=127.0.0.1;User Id=root;password=123456;Database=c#"; //设置连接字符串
            MySqlConnection mycon = new MySqlConnection(constr);  //实例化连接对象
            mycon.Open();
            MySqlCommand mycom = mycon.CreateCommand();         //创建SQL命令执行对象

            string s1 = "select name,passwd from register where name='" + username + "' and passwd='" + passwdmd + "'";                                            //编写SQL命令
            mycom.CommandText = s1;                           //执行SQL命令
            MySqlDataAdapter myDA = new MySqlDataAdapter();       //实例化数据适配器
            myDA.SelectCommand = mycom;                       //让适配器执行SELECT命令
            DataSet myDS = new DataSet();                     //实例化结果数据集

            try
            {
                n = myDA.Fill(myDS, "register");              //将结果放入数据适配器，返回元祖个数
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (n != 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
    }
}