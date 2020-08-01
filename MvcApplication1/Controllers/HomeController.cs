using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using log4net;
using MvcApplication1.Extensions;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{


    public class HomeController : Controller
    {
        private ProductDb productDbs = new ProductDb();
        private static readonly ILog Log = LogManager.GetLogger(typeof(HomeController));

        private string name = "0";
        private static decimal sum = 0;
        private static ProductsListVm productlist = null;
        private static int noid = 0;

        public ActionResult Index()
        {
            Log.Info("记录日志 购物车！");

            ProductsListVm productsListVm = new ProductsListVm();
            productsListVm.Products = GetAllProducts();

            productlist = productsListVm;
            return View(productsListVm);
        }

        public ActionResult CartIndex(Cart cart, string returnUrl)
        {
            return View(new CartIndexVm
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        //添加到购物车
        public ActionResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Product product = GetAllProducts().Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }

        //点击数量+号或点击数量-号或自己输入一个值
        [HttpPost]
        public ActionResult IncreaseOrDecreaseOne(Cart cart, int id, int quantity)
        {
            Product product = GetAllProducts().Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                cart.IncreaseOrDecreaseOne(product, quantity);
            }
            return Json(new
            {
                msg = true
            });
            //return RedirectToAction("CartIndex");
        }

        //

        //从购物车移除
        public ActionResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Product product = GetAllProducts().Where(p => p.Id == id).FirstOrDefault();
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("CartIndex", new { returnUrl });
        }

        //清空购物车
        public ActionResult EmptyCart(Cart cart, string returnUrl)
        {
            cart.Clear();
            return View("Index", new ProductsListVm { Products = GetAllProducts() });
        }

        //显示购物车摘要
        public ActionResult Summary(Cart cart)
        {
            //test----------------
            sum = cart.ComputeTotalPrice();

            return View(cart);
        }
        /*
        private List<Product> GetAllProduct()
        {
            return new List<Product>()
            {
                new Product(){Id = 1, Description = "产品描述产品描述产描述",ImageUrl = "/images/1.jpg",Name = "产品1",Price = 1500M},
                new Product(){Id = 2, Description = "产品描品描述产品描述",ImageUrl = "/images/2.jpg",Name = "产品2",Price = 950M},
                new Product(){Id = 3, Description = "产品描述产品描述产品描述",ImageUrl = "/images/3.jpg",Name = "产品3",Price = 1555M},
                new Product(){Id = 4, Description = "产品描述产品描述产品描述描述",ImageUrl = "/images/4.jpg",Name = "产品4",Price = 25M},
                new Product(){Id = 5, Description = "产品描述产品描述产品描",ImageUrl = "/images/5.jpg",Name = "产品5",Price = 75M},
                new Product(){Id = 6, Description = "产品描产品描",ImageUrl = "/images/6.jpg",Name = "产品6",Price = 25M},
                new Product(){Id = 7, Description = "商品的的产品描产品描",ImageUrl = "/images/7.jpg",Name = "产品7",Price = 35M}

            };
        }
        */

        private List<Product> GetAllProducts()
        {


            List<Product> products = new List<Product>();

            for (int i = 1; i < 11; i++)
            {
                Product pro = new Product();
                pro = productDbs.ReturnProduct(i);
                products.Add(pro);
            }
            //Product p1 = new Product(1, "产品描述产品描述产描述", "/images/1.jpg", "产品1", 1500M);

            //products.Add(p1);
            return products;
        }

        //测试购物车项
        public ActionResult Demo()
        {
            return View();
        }



        //个人消息视图
        public ActionResult Account()
        {
            try
            {
                name = Session["user"].ToString();
                Log.Info("记录日志 用户：" + name + "查看主页！");


            }
            catch (Exception e)
            {
                throw e;
            }

            //string name = "111";
            GetMoney money = new GetMoney();
            ViewBag.sum = money.LookMoney(name);

            ViewBag.name = name;

            return View();

        }


        //统计支付信息
        public ActionResult PayIndex()
        {

            try
            {
                name = Session["user"].ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
            GetMoney money = new GetMoney();
            ViewBag.sum = sum.ToString();
            ViewBag.num = money.LookMoney(name);
            return View();
        }

        //支付操作
        public ActionResult Payed()
        {
            Log.Info("记录日志 购物结算！");

            try
            {
                name = Session["user"].ToString();
            }
            catch (Exception e)
            { throw e; }
            GetMoney money = new GetMoney();
            //余额
            decimal num = Convert.ToDecimal(money.LookMoney(name));
            //消费
            try
            {
                if (sum <= num)
                {

                    num = num - sum;
                    money.UpdateMoney(name, num);
                    ViewBag.num = num;
                    HistroySet histroy = new HistroySet();

                    Random random = new Random();

                    noid = random.Next(1000, 9999);



                    histroy.SetList(noid, name, sum, "x86" + noid);

                    return Content("<script>alert('支付成功！');history.go(-1);</script>");

                }
                else
                {
                    ViewBag.num = sum;
                    return Content("<script>alert('余额不足！');history.go(-1);</script>");

                }
            }
            catch (Exception e)
            {
                Log.Info("记录日志 支付异常！");

                return Content("<script>alert('账户错误，请联系管理员。错误代码-1256789！');history.go(-1);</script>");
                throw e;
            }
        }


        //充值操作
        public ActionResult AddPay()
        {
            try
            {
                name = Session["user"].ToString();
            }
            catch (Exception e)
            { throw e; }
            GetMoney money = new GetMoney();
            //余额
            try
            {
                decimal num = Convert.ToDecimal(money.LookMoney(name));
                //消费

                num = num + sum;

                money.UpdateMoney(name, num);

                return Content("<script>alert('您已充值！');history.go(-1);</script>");
            }
            catch (Exception e)
            {
                Log.Info("记录日志 充值异常！");

                return Content("<script>alert('充值失败，请联系管理员。错误代码4441949234！');history.go(-1);</script>");

                throw e;
            }
        }

        public ActionResult MainView(int id)
        {


            Product product = new Product();

            product = productDbs.ReturnProduct(id);





            return View(product);


        }
    }
}
