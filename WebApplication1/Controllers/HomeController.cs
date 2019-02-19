using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        List<userInformation> listOfUsers = new List<userInformation>();
        List<Item> ItemList = new List<Item>()
        {
            new Item("Hot Chocolate", "Milk, Cocoa, Sugar, Fat", 1.99),
            new Item("Latte",  "Milk, Coffee", 1.99),
            new Item("Coffee",  "Coffee, Water", 1.00),
            new Item("Tea", "Black Tea", 1.00),
            new Item("Frozen Lemonade",  "Lemon, Sugar, Ice", 1.99)
            };

        List<Item> shoppingCart = new List<Item>();

        
        
        public ActionResult Index()
        {
            if (Session["CurrentUser"] != null && Session["CurrentLogin"] != null)
            {
                ViewBag.enter = "enter";


            }
         
            return View();

        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Menu()
        {
                 ViewBag.ItemsList = ItemList;
                return View(); 
        }
       
        public ActionResult AddItem(string itemName)
        {
           
                    if (Session["ShoppingCart"] != null)
                    {
                        shoppingCart = (List<Item>)Session["ShoppingCart"];
                  
                    }
            foreach ( var itm in ItemList)
            {

                if (itemName == itm.Name)
                {
                    shoppingCart.Add(itm);
                }

            }

                    Session["ShoppingCart"] = shoppingCart;
                        return RedirectToAction("Menu");

            }
                
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Registeration()
        {
            userInformation userObj = new userInformation();
            return View(userObj);


        }
        [ActionName("Registeration"), HttpPost]
        public ActionResult Registeration(userInformation user)
        {
            if (Session["CurrentUser"] != null)
            {

                listOfUsers = (List<userInformation>)Session["CurrentUser"];

                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {

                    listOfUsers.Add(user);
                    Session["CurrentUser"] = listOfUsers;
                    return RedirectToAction("Login");
                }

                return View(user);
            }
        }
        public ActionResult Login()
        {
            LoginInfo userObj = new LoginInfo();
            return View(userObj);


        }
        [ActionName("Login"), HttpPost]
        public ActionResult Login(LoginInfo loginUser)
        {
            if (ModelState.IsValid)
            {
               
                var list  = Session["CurrentUser"] as List<userInformation>;
                foreach (var person in list)
                {
                    if (loginUser.Email == person.Email && loginUser.Password == person.Password)
                    {
                        if (Session["CurrentLogin"] == null)
                        {
                            Session["CurrentLogin"] = loginUser;
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ViewBag.Error = "Incorrect login!!";
                        return View();
                    }
                }
                
            }
            return View();


        }

        

        public ActionResult Logout()
        {
            
            Session.Remove("CurrentUser");
            Session.Remove("CurrentLogin");

            return View();
            
        }
        public ActionResult ReviewCart()
        {
            List<Item> review = new List<Item>();
             review = (List<Item>)Session["ShoppingCart"];
            ViewBag.Cart = review;
            return View();

        }


    }


    
    }

