using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Website_demomvc.DTO;
using Website_demomvc.Models.Account;

namespace Website_demomvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly Website_demomvcDbContext _context;

        public AccountController(Website_demomvcDbContext context)
        {
            _context = context;
        }

        //Đăng ký tài khoản
        [HttpGet]
        public IActionResult RegisterAccount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAccount(RegisterViewModel user, string email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Account account = new Account
                    {
                        FullName = user.FullName,
                        Age = user.Age,
                        Email = user.Email,
                        Password = user.Password,
                        DateCreate = DateTime.Now
                    };
                    var Email = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.Email.ToLower() == email.ToLower());
                    if (Email != null)
                    {
                        ViewBag.Alert = "Email này đã được sử dụng";
                        return View(user);
                    }
                    else
                    {
                        try
                        {
                            //Đăng nhập thành công -- lưu thời gian đăng nhập lại
                            _context.Add(account);
                            await _context.SaveChangesAsync();
                            //Lưu Session Mã Khách hàng
                            HttpContext.Session.SetString("FullName", account.FullName.ToString());
                            var userName = HttpContext.Session.GetString("FullName");
                            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, account.FullName),
                            new Claim("FullName", account.FullName.ToString())
                        };
                            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            await HttpContext.SignInAsync(claimsPrincipal);
                            ViewBag.Success = "Đăng ký thành công";
                            return RedirectToAction("Index", "Products");
                        }
                        catch
                        {
                            return View();
                        }
                    }
                }
                else
                {
                    return View(user);
                }
            }
            catch
            {
                //_notyfService.Error("Đăng ký tài khoản thất bại");
                return View(user);
            }
        }

        //Đăng nhập tài khoản
        [HttpGet]
        public IActionResult LoginAccount(string returnUrl = null)
        {
            var taikhoanID = HttpContext.Session.GetString("FullName");

            if (taikhoanID != null)
            {
                return RedirectToAction("RegisterAccount", "Account");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAccount(LoginViewModel user, string returnUrl = null)
        {
            //var cd = _context.Accounts.ToList();
                var account = _context.Accounts
                        .AsNoTracking()
                        .SingleOrDefault(x => x.Email == user.Email);
                if (account == null)
                {
                    ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                    return View(user);
                }
                string password = user.Password;
                if (account.Password != password)
                {
                    ViewBag.Error = "Thông tin đăng nhập không chính xác";
                    return View(user);
                }
                //Lưu Session Mã Khách hàng
                HttpContext.Session.SetString("FullName", account.FullName.ToString());
                var userName = HttpContext.Session.GetString("FullName");
                var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, account.FullName),
                            new Claim("FullName", account.FullName.ToString())
                        };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                //_notyfService.Success("Đăng nhập thành công");
                if (string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    return Redirect(returnUrl);
                }

        }

        [HttpGet]
        [Route("dang-xuat.html", Name = "Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Remove("FullName");
            return RedirectToAction("LoginAccount", "Account");
        }
    }
}