using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;


namespace MvcApplication1.Extensions
{
    public class Regists
    {
        private readonly string constr = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;
        public bool Register(string name, string passwd)
        {

            //MD5
            GetMD5 mD5 = new GetMD5();
            string passwdmd = mD5.Md5(passwd);







            MySqlConnection mycon = new MySqlConnection(constr);                  //实例化连接对象
            mycon.Open();
            //查询新注册的用户是否存在
            MySqlCommand checkCmd = mycon.CreateCommand();       //创建SQL命令执行对象
            string s = "select name from register where name='" + name + "'";
            checkCmd.CommandText = s;
            MySqlDataAdapter check = new MySqlDataAdapter();       //实例化数据适配器
            check.SelectCommand = checkCmd;                    //让适配器执行SELECT命令
            DataSet checkData = new DataSet();                 //实例化结果数据集
            int n = check.Fill(checkData, "register");         //将结果放入数据适配器，返回元祖个数
            if (n != 0)
            {
                return false;
                //Response.Write("<script>alert('用户名已存在！');</script>");

            }


            else
            {

                string s1 = "insert into Register(name,passwd) values ('" + name + "','" + passwdmd + "')";                            //编写SQL命令
                MySqlCommand mycom = new MySqlCommand(s1, mycon);          //初始化命令
                mycom.ExecuteNonQuery();             //执行语句
                mycon.Close();                       //关闭连接
                mycom = null;
                mycon.Dispose();                     //释放对象

                //Response.Write("<script>alert('注册成功！');</script>");
                return true;


            }


        }
    }
}