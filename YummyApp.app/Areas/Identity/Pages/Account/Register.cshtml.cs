﻿// Licensed to the .NET Foundation under one or more agreements.
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
using Microsoft.Extensions.Logging;
using Tesseract;
using YummyApp.app.Services.FileUploadService;
using YummyApp.Core.Models;
using YummyApp.Core.ViewModels.AdminViewModels;
using YummyApp.EF.Data;

namespace YummyApp.app.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "Administrator")]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IImageService _imageService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IWebHostEnvironment hostingEnvironment,
            IImageService imageService)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _imageService = imageService;   
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
            [Required]
            [StringLength(100, ErrorMessage = "The First Name field is required.", MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The Last Name field is required.", MinimumLength = 2)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            public string Role { get; set; }

            public IFormFile? Image { get; set; }

            public string? JobTitle { get; set; }

            public string? Description { get; set; }
            public string? PhoneNumber { get; set; }

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

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("/Admin/Chef/Index");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //if (Input.Image != null)
                //{
                //    var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes

                //    // Read the first 8 bytes of the file to check the header
                //    byte[] headerBytes = new byte[8];
                //    using (var reader = Input.Image.OpenReadStream())
                //    {
                //        reader.Read(headerBytes, 0, headerBytes.Length);
                //    }

                //    // Define header signatures for valid image formats
                //    byte[][] validHeaders = new byte[][]
                //    {
                //        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, // JPEG
                //        new byte[] { 0x89, 0x50, 0x4E, 0x47 }, // PNG
                //        new byte[] { 0xFF, 0xD8, 0xFF }// JPG
                //    };

                //    bool isValidFormat = false;
                //    foreach (var validHeader in validHeaders)
                //    {
                //        if (headerBytes.Take(validHeader.Length).SequenceEqual(validHeader))
                //        {
                //            isValidFormat = true;
                //            break;
                //        }
                //    }

                //    if (!isValidFormat)
                //    {
                //        ModelState.AddModelError("Input.Image", "Invalid image File.");
                //        return Page();
                //    }
                //    else if (Input.Image.Length > maxSizeBytes)
                //    {
                //        ModelState.AddModelError("Input.Image", "Image size should be within 4 megabytes.");
                //        return Page();
                //    }

                //}

                //if (Input.Image != null)
                //{
                //    var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes

                //    // Read the first 8 bytes of the file to check the header
                //    byte[] headerBytes = new byte[8];
                //    using (var reader = Input.Image.OpenReadStream())
                //    {
                //        reader.Read(headerBytes, 0, headerBytes.Length);
                //    }

                //    // Define header signatures for valid image formats
                //    byte[][] validHeaders = new byte[][]
                //    {
                //    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, // JPEG
                //    new byte[] { 0x89, 0x50, 0x4E, 0x47 }, // PNG
                //    new byte[] { 0xFF, 0xD8, 0xFF } // JPG
                //    };

                //    bool isValidFormat = false;
                //    foreach (var validHeader in validHeaders)
                //    {
                //        if (headerBytes.Take(validHeader.Length).SequenceEqual(validHeader))
                //        {
                //            isValidFormat = true;
                //            break;
                //        }
                //    }

                //    if (!isValidFormat)
                //    {
                //        ModelState.AddModelError("ImageFile", "Invalid image file format.");
                //        return Page();
                //    }
                //    else if (Input.Image.Length > maxSizeBytes)
                //    {
                //        ModelState.AddModelError("ImageFile", "Image size should be within 4 megabytes.");
                //        return Page();
                //    }

                //    // Replace with your OCR implementation using Tesseract
                //    using (var engine = new TesseractEngine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "eng", EngineMode.Default))
                //    {
                //        using (var img = Pix.LoadTiffFromMemory(await ImageToByteArrayAsync(Input.Image)))
                //        {
                //            using (var page = engine.Process(img))
                //            {
                //                var text = page.GetText();
                //                if (!string.IsNullOrWhiteSpace(text))
                //                {
                //                    ModelState.AddModelError("ImageFile", "Image contains text.");
                //                    return Page();
                //                }
                //            }
                //        }
                //    }
                //}

                //if (Input.Image != null)
                //{
                //    var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes

                //    // Read the first 8 bytes of the file to check the header
                //    byte[] headerBytes = new byte[8];
                //    using (var reader = Input.Image.OpenReadStream())
                //    {
                //        reader.Read(headerBytes, 0, headerBytes.Length);
                //    }

                //    // Define header signatures for valid image formats
                //    byte[][] validHeaders = new byte[][]
                //    {
                //    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, // JPEG
                //    new byte[] { 0x89, 0x50, 0x4E, 0x47 }, // PNG
                //    new byte[] { 0xFF, 0xD8, 0xFF } // JPG
                //    };

                //    bool isValidFormat = false;
                //    foreach (var validHeader in validHeaders)
                //    {
                //        if (headerBytes.Take(validHeader.Length).SequenceEqual(validHeader))
                //        {
                //            isValidFormat = true;
                //            break;
                //        }
                //    }

                //    if (!isValidFormat)
                //    {
                //        ModelState.AddModelError("Image", "Invalid image file.");
                //        return Page();
                //    }
                //    else if (Input.Image.Length > maxSizeBytes)
                //    {
                //        ModelState.AddModelError("Image", "Image size should be within 4 megabytes.");
                //        return Page();
                //    }

                //    // Replace with your actual Tesseract OCR implementation
                //    var tesseractExePath = Path.Combine("C:\\Program Files\\Tesseract-OCR", "tesseract.exe");
                //    var tessdataPath = Path.GetDirectoryName(tesseractExePath);

                //    using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                //    {
                //        using (var img = Pix.LoadTiffFromMemory(ImageToByteArray(Input.Image)))
                //        {
                //            using (var page = engine.Process(img))
                //            {
                //                var text = page.GetText();
                //                if (!string.IsNullOrWhiteSpace(text))
                //                {
                //                    ModelState.AddModelError("Image", "Image contains text.");
                //                    return Page();
                //                }
                //            }
                //        }
                //    }
                //}

                //if (Input.Image != null)
                //{
                //    var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes

                //    // Read the first 8 bytes of the file to check the header
                //    byte[] headerBytes = new byte[8];
                //    using (var reader = Input.Image.OpenReadStream())
                //    {
                //        reader.Read(headerBytes, 0, headerBytes.Length);
                //    }

                //    // Define header signatures for valid image formats
                //    byte[][] validHeaders = new byte[][]
                //    {
                //        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, // JPEG
                //        new byte[] { 0x89, 0x50, 0x4E, 0x47 }, // PNG
                //        new byte[] { 0xFF, 0xD8, 0xFF } // JPG
                //    };

                //    bool isValidFormat = false;
                //    foreach (var validHeader in validHeaders)
                //    {
                //        if (headerBytes.Take(validHeader.Length).SequenceEqual(validHeader))
                //        {
                //            isValidFormat = true;
                //            break;
                //        }
                //    }

                //    if (!isValidFormat)
                //    {
                //        ModelState.AddModelError("Input.Image", "Invalid image File.");
                //        return Page();
                //    }
                //    else if (Input.Image.Length > maxSizeBytes)
                //    {
                //        ModelState.AddModelError("Input.Image", "Image size should be within 4 megabytes.");
                //        return Page();
                //    }

                //    // Replace with your OCR implementation
                //    // Example: Tesseract OCR library

                //    //var tesseractExePath = Path.Combine("C:\\Program Files\\Tesseract-OCR", "tesseract.exe");
                //    //var tessdataPath = Path.GetDirectoryName(tesseractExePath);

                //    //using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default))
                //    //{
                //    var tesseractExePath = Path.Combine("C:\\Program Files\\Tesseract-OCR", "tesseract.exe");
                //    var datapath = @"D:\tessdata-main\tessdata-main"; // Provide the correct path

                //    using (var engine = new TesseractEngine(datapath, "eng", EngineMode.Default))
                //    {
                //        using (var img = Pix.LoadTiffFromMemory(await ImageToByteArrayAsync(Input.Image)))
                //        {
                //            using (var page = engine.Process(img))
                //            {
                //                var text = page.GetText();
                //                if (!string.IsNullOrWhiteSpace(text))
                //                {
                //                    ModelState.AddModelError("Input.Image", "Image contains text.");
                //                    return Page();
                //                }
                //            }
                //        }
                //    }
                //}

                //if (Input.Image != null)
                //{
                //    var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes

                //    // Read the first 8 bytes of the file to check the header
                //    byte[] headerBytes = new byte[8];
                //    using (var reader = Input.Image.OpenReadStream())
                //    {
                //        reader.Read(headerBytes, 0, headerBytes.Length);
                //    }

                //    // Define header signatures for valid image formats
                //    byte[][] validHeaders = new byte[][]
                //    {
                //        new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, // JPEG
                //        new byte[] { 0x89, 0x50, 0x4E, 0x47 }, // PNG
                //        new byte[] { 0xFF, 0xD8, 0xFF } // JPG
                //    };

                //    bool isValidFormat = false;
                //    foreach (var validHeader in validHeaders)
                //    {
                //        if (headerBytes.Take(validHeader.Length).SequenceEqual(validHeader))
                //        {
                //            isValidFormat = true;
                //            break;
                //        }
                //    }

                //    if (!isValidFormat)
                //    {
                //        ModelState.AddModelError("Input.Image", "Invalid image File.");
                //        return Page();
                //    }
                //    else if (Input.Image.Length > maxSizeBytes)
                //    {
                //        ModelState.AddModelError("Input.Image", "Image size should be within 4 megabytes.");
                //        return Page();
                //    }

                //    try
                //    {
                //        using (var memoryStream = new MemoryStream())
                //        {
                //            await Input.Image.CopyToAsync(memoryStream);
                //            memoryStream.Seek(0, SeekOrigin.Begin); // Reset the position to the beginning

                //            using (var img = Pix.LoadTiffFromMemory(memoryStream.ToArray()))
                //            {
                //                // Replace the following with your OCR implementation

                //                var tesseractExePath = Path.Combine("C:\\Program Files\\Tesseract-OCR", "tesseract.exe");
                //                var datapath = @"D:\tessdata-main\tessdata-main"; // Provide the correct path
                //                using (var engine = new TesseractEngine(datapath, "eng", EngineMode.Default))
                //                {
                //                    using (var page = engine.Process(img))
                //                    {
                //                        var text = page.GetText();
                //                        if (!string.IsNullOrWhiteSpace(text))
                //                        {
                //                            ModelState.AddModelError("Input.Image", "Image contains text.");
                //                            return Page();
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    catch (IOException ex)
                //    {
                //        ModelState.AddModelError("Input.Image", $"Failed to load image from memory: {ex.Message}");
                //        return Page();
                //    }
                //}

                //        if (Input.Image != null)
                //        {
                //            var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes

                //            // Read the first 8 bytes of the file to check the header
                //            byte[] headerBytes = new byte[8];
                //            using (var reader = Input.Image.OpenReadStream())
                //            {
                //                reader.Read(headerBytes, 0, headerBytes.Length);
                //            }

                //            // Define header signatures for valid image formats
                //            byte[][] validHeaders = new byte[][]
                //            {
                //new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, // JPEG
                //new byte[] { 0x89, 0x50, 0x4E, 0x47 }, // PNG
                //new byte[] { 0xFF, 0xD8, 0xFF } // JPG
                //            };

                //            bool isValidFormat = false;
                //            foreach (var validHeader in validHeaders)
                //            {
                //                if (headerBytes.Take(validHeader.Length).SequenceEqual(validHeader))
                //                {
                //                    isValidFormat = true;
                //                    break;
                //                }
                //            }

                //            if (!isValidFormat)
                //            {
                //                ModelState.AddModelError("Input.Image", "Invalid image File.");
                //                return Page();
                //            }
                //            else if (Input.Image.Length > maxSizeBytes)
                //            {
                //                ModelState.AddModelError("Input.Image", "Image size should be within 4 megabytes.");
                //                return Page();
                //            }

                //            try
                //            {
                //                using (var memoryStream = new MemoryStream())
                //                {
                //                    await Input.Image.CopyToAsync(memoryStream);
                //                    memoryStream.Seek(0, SeekOrigin.Begin); // Reset the position to the beginning

                //                    var tesseractExePath = Path.Combine("C:\\Program Files\\Tesseract-OCR", "tesseract.exe");
                //                    var datapath = @"D:\tessdata-main\tessdata-main"; // Provide the correct path
                //                    using (var engine = new TesseractEngine(datapath, "eng", EngineMode.Default))
                //                    {
                //                        using (var img = Pix.LoadTiffFromMemory(memoryStream.ToArray()))
                //                        {
                //                            using (var page = engine.Process(img))
                //                            {
                //                                var text = page.GetText();
                //                                if (!string.IsNullOrWhiteSpace(text))
                //                                {
                //                                    ModelState.AddModelError("Input.Image", "Image contains text.");
                //                                    return Page();
                //                                }
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //            catch (IOException ex)
                //            {
                //                ModelState.AddModelError("Input.Image", $"Failed to load image from memory: {ex.Message}");
                //                return Page();
                //            }
                //        }

                if (Input.Image != null)
                {
                    var maxSizeBytes = 4 * 1024 * 1024; // 4 megabytes in bytes

                    using (var memoryStream = new MemoryStream())
                    {
                        await Input.Image.CopyToAsync(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin); // Reset the position to the beginning

                        byte[] headerBytes = new byte[8];
                        memoryStream.Read(headerBytes, 0, headerBytes.Length);

                        byte[][] validHeaders = new byte[][]
                        {
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }, // JPEG
            new byte[] { 0x89, 0x50, 0x4E, 0x47 }, // PNG
            new byte[] { 0xFF, 0xD8, 0xFF } // JPG
                        };

                        bool isValidFormat = validHeaders.Any(validHeader => headerBytes.Take(validHeader.Length).SequenceEqual(validHeader));

                        if (!isValidFormat)
                        {
                            ModelState.AddModelError("Input.Image", "Invalid image File.");
                            return Page();
                        }
                        else if (Input.Image.Length > maxSizeBytes)
                        {
                            ModelState.AddModelError("Input.Image", "Image size should be within 4 megabytes.");
                            return Page();
                        }

                        try
                        {
                            var tesseractExePath = "tesseract"; // This assumes the 'tesseract' command is available globally
                            var datapath = @"D:\tessdata-main\tessdata-main"; // Provide the correct path

                            using (var engine = new TesseractEngine(datapath, "eng", EngineMode.Default))
                            using (var img = Pix.LoadTiffFromMemory(memoryStream.ToArray()))
                            using (var page = engine.Process(img))
                            {
                                var text = page.GetText();
                                if (!string.IsNullOrWhiteSpace(text))
                                {
                                    ModelState.AddModelError("Input.Image", "Image contains text.");
                                    return Page();
                                }
                            }
                        }
                        catch (IOException ex)
                        {
                            ModelState.AddModelError("Input.Image", $"Failed to load image from memory: {ex.Message}");
                            return Page();
                        }
                    }
                }

                var user = CreateUser();
                //required fields
                user.FirstName = Input.FirstName;
                user.LastName = Input.LastName;

                await _userStore.SetUserNameAsync(user, Input.FirstName + "_" + Input.LastName, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);


                if (result.Succeeded)
                {
                    
                    user.PhoneNumber = Input.PhoneNumber;
                    user.JobTitle = Input.JobTitle;
                    user.Description = Input.Description;

                    if(Input.Image != null)
                    {
                        user.ImageName = _imageService.uploadImage("UserImages", Input.Image);
                    }

                    // Add Role To User 
                    user.UserType = (Input.Role == "Chef") ? UserType.Chef : UserType.Administrator;
                    
                    var role = await _roleManager.FindByNameAsync(Input.Role);
                    if (role != null)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    
                    _logger.LogInformation("User created a new account with password.");
                    TempData["message"] = "New "+Input.Role +" Added Successfully";
                    return LocalRedirect(returnUrl);
                    //var userId = await _userManager.GetUserIdAsync(user);
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }

        //private async Task<byte[]> ImageToByteArrayAsync(IFormFile image)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await image.CopyToAsync(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}

        //private async Task<byte[]> ImageToByteArrayAsync(IFormFile image)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await image.CopyToAsync(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}

        //private byte[] ImageToByteArray(IFormFile image)
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        image.CopyTo(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}


    }
}
