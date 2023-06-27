using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ruby.Models;
using System.Diagnostics;
using System.Security.Claims;
using System.Text.Json;
using System.Net.Mail;
using System.Net;

namespace Ruby.Controllers
{
    public class HomeController : Controller
    {
        private RubyHome_DatabaseContext db;
        public HomeController(RubyHome_DatabaseContext db)
        {
            this.db = db;
        }
        //вкладки
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public async Task<IActionResult> Properties()
        {
            return View(await db.Properties.ToListAsync());
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Support()
        {
            return View();
        }
        //методы для функионала
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Main");
        }
        
        //////////////////////авторизация///////////////////////////////
        public IActionResult SignIn()
        {
            if (HttpContext.Session.Keys.Contains("AuthUser"))
            {
                return RedirectToAction("Main", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {

            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.LoginUser == model.Login && u.PasswordUser == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetString("AuthUser", model.Login);
                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Main", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");


            }

            return RedirectToAction("SignIn", "Home");

        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, 
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("AuthUser");
            return RedirectToAction("SignIn");
        }
        //////////////////////////регистрация//////////////////////////////////////////////////
        
        // Метод, отображающий страницу регистрации
        public IActionResult SignUp()
        {
            return View();
        }

        // Метод, обрабатывающий POST-запрос после отправки данных регистрации
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User person)
        {
            if (ModelState.IsValid)
            {
                // Если данные прошли валидацию, добавляем пользователя в базу данных
                db.Users.Add(person);
                await db.SaveChangesAsync();

                // Перенаправляем на страницу входа
                return RedirectToAction("SignIn");
            }
            else
            {
                // Если данные не прошли валидацию, возвращаем на страницу регистрации с ошибками
                return View(person);
            }
        }


        //////////////////////////////Корзина//////////////////////////////////
        public IActionResult AddToCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));

            cart.CartLines.Add(db.Properties.Find(ID));

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("~/Home/Main");
        }

        public IActionResult RemoveFromCart()
        {
            int number = Convert.ToInt32(Request.Query["Number"]);

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));

            cart.CartLines.RemoveAt(number);

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("~/Home/Main");
        }
        public IActionResult RemoveAllFromCart()
        {
            int ID = Convert.ToInt32(Request.Query["ID"]);

            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));

            cart.CartLines.RemoveAll(item => item.IdProperty == ID);

            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize<Cart>(cart));

            return Redirect("~/Home/Main");
        }
        public IActionResult Cart()
        {
            Cart cart = new Cart();

            if (HttpContext.Session.Keys.Contains("Cart"))

                cart = JsonSerializer.Deserialize<Cart>(HttpContext.Session.GetString("Cart"));

            return View(cart);
        }

        public IActionResult SendMail(Send send)
        {
            MailAddress from = new MailAddress("andrey.kurdelov.00@mail.ru", "Ruby");
            MailAddress to = new MailAddress(send.Email);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Обращение от пользователя ";
            m.Body = "Добро пожаловать, " + send.Name + ", мы скоро свяжемся с вами";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru");
            smtp.Credentials = new NetworkCredential("andrey.kurdelov.00@mail.ru", "uA33qLHpf0Bd8Re1cfpj");
            smtp.EnableSsl = true;
            smtp.Send(m);

            MailAddress too = new MailAddress("andrey.kurdelov.00@mail.ru", "Ruby");
            MailMessage mo = new MailMessage(too, too);
            mo.Subject = "Обращение от пользователя " + send.Email;
            mo.Body = send.Message;
            mo.IsBodyHtml = true;

            smtp.Credentials = new NetworkCredential("andrey.kurdelov.00@mail.ru", "uA33qLHpf0Bd8Re1cfpj");
            smtp.EnableSsl = true;
            smtp.Send(mo);

            return View("Main");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}