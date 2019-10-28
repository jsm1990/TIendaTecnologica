using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaTecnologica.Models;

namespace TiendaTecnologica.Controllers
{
    //[Authorize]
    public class AutenticacionController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        //public AutenticacionController(SignInManager<IdentityUser> signInManager)
        //{
        //    this.signInManager = signInManager;
        //}

        //public AutenticacionController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        //{
        //    userManager = _userManager;
        //    signInManager = _signInManager;
        //}

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    return RedirectToAction("index", "Home");
        //}

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View("Registro");
        }

        //[HttpPost]
        //public async Task<IActionResult> Registro(Usuarios model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new IdentityUser { UserName = model.UsuCorreo, Email = model.UsuCorreo };
        //        var result = await _userManager.CreateAsync(user, model.UsuContraseña);

        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, isPersistent: false);
        //            return RedirectToAction("Index", "Home");
        //        }

        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }
        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Correo, model.Contraseña, model.Recordarme, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Autenticacion");
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Correo,
                    Email = model.Correo
                };

                var result = await userManager.CreateAsync(user, model.Contraseña);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View("Registro");
        }
    }
}
