using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PikTok.Models;
using PikTok.Models.PacketModels;
using PikTok.Services;
using System.Threading.Tasks;

namespace PikTok.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : Controller {
        public MessagesController(AuthService authService, DatabaseService databaseService) {
            this.authService = authService;
            this.databaseService = databaseService;
        }
        public AuthService authService { get; }
        private readonly DatabaseService databaseService;
        [HttpGet]
        public async Task<IActionResult> Home() {
            //Checks if cookies contains Token
            if (!Request.Cookies.ContainsKey("Token")) { return View("cta"); }
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            foreach (ChatModel chat in userAccount.chats) {

            }
            return View("Messages", new HomeViewModel() {
                userAccount = userAccount
            });
        }
        [HttpGet("GetChats")]
        public async Task<IActionResult> GetChats() {
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            if (userAccount == null) { return View("cta"); }
            return Ok(userAccount.chats);
        }
        [HttpGet("GetUsername")]
        public async Task<IActionResult> GetUsername(string externalUserId) {
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            UserAccount userAccount = await authService.GetUserWithExternalId(externalUserId);
            if (userAccount == null) { return NotFound(externalUserId); }
            return Ok(userAccount.profile.UserName);
        }
    }
}