using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace MvcApplication1.Models
{
    public class ProductDb
    {
        private readonly string constr = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;

        public Product ReturnProduct(int i)
        {
            //创建一个product类
            Product products = new Product();

            MySqlConnection myconn = null;
            MySqlCommand mycom = null;
            
            myconn = new MySqlConnection(constr);
            myconn.Open();
            mycom = myconn.CreateCommand();
            mycom.CommandText = "SELECT *FROM products WHERE Id="+i;        //操作语句

            //读取数据
            MySqlDataReader reader = mycom.ExecuteReader();
            while (reader.Read())
            {
                products.Id = Convert.ToInt32(reader[0]);
                products.Description = reader[1].ToString();
                products.ImageUrl = reader[2].ToString();
                products.Name = reader[3].ToString();
                products.Price = Convert.ToDecimal(reader[4]);
                //products.Id = i;

            }


            //关闭连接
            myconn.Close();
            //返回该类
            return products;
        }
    }
}