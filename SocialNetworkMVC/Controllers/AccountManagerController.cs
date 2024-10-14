using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkMVC.Models;
using SocialNetworkMVC.Views.ViewsModels;

namespace SocialNetworkMVC.Controllers
{
    public class AccountManagerController : Controller
    {
        private IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountManagerController(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            // Передаем ReturnUrl в модель, чтобы сохранить его значение при отправке формы
            var model = new LoginViewModels { ReturnUrl = returnUrl };
            return View(model);
        }
        [Route("Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModels model)
        {
            
            if (ModelState.IsValid)
            {

               
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                   
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    }
                }
            }
                    
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();
                // Логирование или вывод ошибок
                foreach (var error in errors)
                {
                    // Например, вывод в консоль или в лог
                    Console.WriteLine(error);
                }
            }

                return View("Views/Home/Index.cshtml");
           
        }
        [Route("Logout")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Route("MyPage")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> MyPage()
        {
            var user = User;

            var result = _userManager.GetUserAsync(user);
            return View("User", new UserViewModel(result.Result));
        }
    }
}
