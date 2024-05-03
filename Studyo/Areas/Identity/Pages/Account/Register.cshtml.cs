// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Google.Apis.Auth;
using Microsoft.Extensions.Logging;

namespace Studyo.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [Display(Name = "Username")]
            public string Username { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            // Comment next line to remove annoying message
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> Authenticate(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                // Coloque aqui o ID do cliente do seu aplicativo do Google
                Audience = new List<string>() { "your-google-app-client-id" }
            };

            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
                var userId = payload.Subject;
                var email = payload.Email;
                var name = payload.Name;

                // Aqui você pode criar o usuário e fazer login
                // ...

                return new OkResult();

            }
            catch (InvalidJwtException)
            {
                return Unauthorized();
            }
        }

        public async Task<IActionResult> OnPostGoogleAsync([FromBody] RegisterModel.InputModel Input, string returnUrl = null)
        {
            _logger.LogInformation("Iniciando o método OnPostGoogleAsync.");

            returnUrl ??= Url.Content("~/");

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Esta é uma solicitação AJAX, trate-a como um registro do Google
                var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return new JsonResult(new { redirectUrl = returnUrl });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return new JsonResult(ModelState);
            }
            else
            {
                // Esta é uma solicitação normal, trate-a como um registro normal
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                // Se chegamos até aqui, algo falhou, então redisplay form
                return Page();
            }
        }




        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Esta é uma solicitação AJAX, trate-a como um registro do Google
                var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return new JsonResult(new { redirectUrl = returnUrl });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return new JsonResult(ModelState);
            }
            else
            {
                // Esta é uma solicitação normal, trate-a como um registro normal
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

                // Se chegamos até aqui, algo falhou, então redisplay form
                return Page();
            }
        }


        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                    $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

    }


}