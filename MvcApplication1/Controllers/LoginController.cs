using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using log4net;
using MvcApplication1.Extensions;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginController));


        public ActionResult Index()
        {
            Log.Info("记录日志 登录！");


            return View();
        }


        //登录
        [HttpPost]
        public ActionResult Login(string name, string passwd, string vcode)
        {
            HttpCookie htco = Request.Cookies["ImageV"];
            LoginCart loginComs = new LoginCart();

            if (name == "")
            {
                return Content("<script>alert('账号不能为空！');history.go(-1);</script>");

            }
            else if (passwd == "")
            {

                return Content("<script>alert('密码不能为空！');history.go(-1);</script>");


            }
            else if (vcode != Session["ValidateCode"].ToString())
            {
                return Content("<script>alert('验证码错误！');history.go(-1);</script>");

            }
            else
            {
                bool result = loginComs.compition(name, passwd);

                if(result)
                {
                    

                    Session["user"] = name;

                    Log.Info("记录日志 用户：" + name + "登录成功！");
                    if (name == "admin")
                    {
                        Session["root"] = name;
                        return RedirectToAction("AdminIndex");
                    }

                    //var otherController = DependencyResolver.Current.GetService<HomeController>();
                    //var results = otherController.Index();
                    //return results;


                    return View("../Home/Account");
                }
                else
                {
                    Log.Info("记录日志 用户：" + name + "登录失败！");

                    return Content("<script>alert('登录失败！');history.go(-1);</script>");

                }
                //return Redirect(""); //直接转到指定的url地址
                //return RedirectToAction("~/Home/Index");
                //return Content("施钺啸的MVC");


            }
            

        }



        //验证码刷新
        public FileContentResult CreateValidate()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);

            return File(bytes, "image/JPEG");
        }




        public ActionResult RegIndex()
        {
            Log.Info("记录日志 注册！");

            return View();
        }

        //注册操作
        public ActionResult Regist(string name,string passwd,string repass,string vcode)
        {
            if (name == "")
            {
                return Content("<script>alert('账号不能为空！');history.go(-1);</script>");

            }
            else if (passwd == "")
            {

                return Content("<script>alert('密码不能为空！');history.go(-1);</script>");


            }
            //else if (vcode != Session["ValidateCode"].ToString())
            //{
            //    return Content("<script>alert('验证码错误！');history.go(-1);</script>");

            //}
            else if(passwd!=repass)
            {
                return Content("<script>alert('确认密码不正确！');history.go(-1);</script>");

            }
            else
            {
                Regists regists = new Regists();
                

                if (regists.Register(name,passwd))
                {
                    Log.Info("记录日志 用户：" + name + "注册成功！");

                    return Content("<script>alert('注册成功！');history.go(-1);</script>");

                }
                else
                {
                    Log.Info("记录日志 用户：" + name + "注册失败！");

                    return Content("<script>alert('注册失败！');history.go(-1);</script>");
                }

            }

            
        }

        public ActionResult AdminIndex()
        {
            
                ProductDb productDbs = new ProductDb();


                ProductsListVm productsList = new ProductsListVm();


                List<Product> products = new List<Product>();

                for (int i = 1; i < 11; i++)
                {
                    Product pro = new Product();
                    pro = productDbs.ReturnProduct(i);
                    products.Add(pro);
                }

                productsList.Products = products;
                return View(productsList);

            //if (Session["root"] != null)
            //{
            //}
            //else
            //{
            //    return View();

            //}



        }





    }
}
