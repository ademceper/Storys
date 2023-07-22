using Story.Data;
using Story.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using NETCore.MailKit.Core;

namespace Story.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IEmailService emailService;
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;

        public AccountController(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
             IConfiguration configuration,
                IEmailService emailService,
                AppDbContext context,
            IWebHostEnvironment env
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.emailService = emailService;
            this.configuration = configuration;
            this.context = context;
            this.env = env;
        }
        public IActionResult AccessDenied()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View(new LoginViewModel { IsPersistent = true });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.IsPersistent, true);
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl ?? "/");
            }
            else
            {
                ModelState.AddModelError("", "Geçersiz kullanıcı girişi!");
                return View(model);
            }


        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email, Name = model.Name, EmailConfirmed = true };
                List<string> mail = context.Users.Select(x => x.Email).ToList();

                bool varmı = mail.Any(x => x == model.Email);


                var result = await userManager.CreateAsync(user);

                await userManager.AddToRoleAsync(user, "Members");
                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.GivenName, user.Name));
                if (result.Succeeded && varmı == false)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    TempData["success"] = "Kayıt Olma İşleminiz Tamamlanmıştır.";
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    TempData["error"] = "Aynı İsimli Başka Bir E-Mail Olduğundan Kayıt İşlemi Tamamlanamadı. Lütfen Tekrar Deneyiniz";
                    return Redirect("register");
                }

            }
            


            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult RegisterSuccess()
        {

            return View();
        }
        public IActionResult RegisterHata()
        {

            return View();
        }
    }
}