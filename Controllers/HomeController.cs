using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PikTok.Components;
using PikTok.Models;
using PikTok.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace PikTok.Controllers {
    [Route("")]
    public class HomeController : Controller {
        IWebHostEnvironment webHostEnvironment;
        private readonly IHtmlHelper htmlHelper;

        public HomeController(AuthService authService, DatabaseService databaseService, IWebHostEnvironment webHostEnvironment, IHtmlHelper htmlHelper) {
            this.authService = authService;
            this.databaseService = databaseService;
            this.webHostEnvironment = webHostEnvironment;
            this.htmlHelper = htmlHelper;
        }
        public AuthService authService { get; }
        private readonly DatabaseService databaseService;
        public async Task<IActionResult> Home() {
            //Checks if cookies contains Token
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            //Gets user with token
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            return View("home", new HomeViewModel() {
                userAccount = userAccount
            });
        }
        [HttpPost("Follow")]
        public async Task<IActionResult> Follow(string UserName) {
            //Checks if cookies contains Token
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            //Gets user with token
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            await databaseService.Follow(UserName, userAccount);
            return Ok();
        }
        [HttpGet("GetExternalId")]
        public async Task<IActionResult> GetExternalId() {
            //Checks if cookies contains Token
            if (!Request.Cookies.ContainsKey("Token")) {
                return Unauthorized();
            }
            //Gets user with token
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            return Ok(userAccount.externalUserId);
        }
    }
}