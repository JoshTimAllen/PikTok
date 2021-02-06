using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PikTok.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PikTok.Services;
namespace PikTok.Controllers {
    public class ProfileController : Controller {
        private readonly AuthService authService;
        private readonly DatabaseService databaseService;
        public ProfileController(AuthService authService, DatabaseService databaseService) {
            this.authService = authService;
            this.databaseService = databaseService;
        }
        [HttpGet]
        public async Task<IActionResult> LoadProfile(string UserName) {
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            ProfileViewModel model = new ProfileViewModel();
            model.userAccount = userAccount;
            
            if(UserName == userAccount.profile.UserName) {
                model.isOwner = true;
                model.userAccountToView = userAccount;
            }
            else {
                model.userAccountToView = await databaseService.GetUserWithUsername(UserName);
                if(model.userAccountToView == null) {
                    model.profileNotfound = true;
                    model.userAccountToView = new UserAccount() {
                        profile = new ProfileModel() {
                            UserName = "Profile not found",
                            ProfilePicture = new Media()
                        }
                    };
                }
            }
            return View("Profile", model);
        }
        [HttpPost]
        public async Task<IActionResult> UploadMedia(string UserName, [FromForm] IFormFile ProfilePhoto) {
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            UserAccount userAccount = await authService.GetUser(Request.Cookies);

            var stream = ProfilePhoto.OpenReadStream();

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there
            var task = new FirebaseStorage("jdgs-7e441.appspot.com")
                .Child("data")
                .Child("random")
                .Child("file.png")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            return View("Profile", new ProfileViewModel() {
                userAccount = userAccount
            });
        }
        [HttpGet]
        public async Task<IActionResult> LoadProfileMedia(string UserName) {
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            UserAccount userAccount = await authService.GetUser(Request.Cookies);

            return View("Profile", new ProfileViewModel() {
                userAccount = userAccount
            });
        }
        [HttpGet]
        public async Task<IActionResult> LoadProfileMediaByID(string UserName,string MediaID) {
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            UserAccount userAccount = await authService.GetUser(Request.Cookies);

            return View("Profile", new ProfileViewModel() {
                userAccount = userAccount
            });
        }
        [HttpPost("AddFriend")]
        public async Task<IActionResult> AddFriend(string TargetUsername) {
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            UserAccount targetAccount = await databaseService.GetUserWithUsername(TargetUsername);
            //if()
            ///targetAccount.FriendRequests.Add()
            return Ok();
        }
    }
}