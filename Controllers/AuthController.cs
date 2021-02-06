using System.Collections.Generic;
using PikTok.Models;
using PikTok.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text.Json;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using Firebase.Storage;
using MongoDB.Bson;

namespace PikTok.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller {
        private readonly DatabaseService databaseService;
        private readonly MediaService mediaService;

        public AuthController(AuthService authService, DatabaseService databaseService, MediaService mediaService) {
            this.authService = authService;
            this.databaseService = databaseService;
            this.mediaService = mediaService;
        }

        public AuthService authService { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromForm] string Email, [FromForm] string Password) {
            //Checks and retrievs user
            var userAccount = await authService.AuthenticateUser(Email, Password);
            if (userAccount != null) {
                //Gets the jwt token
                AuthToken authToken = authService.GetToken(userAccount);
                string jsd = JsonSerializer.Serialize(authToken);
                Console.WriteLine(jsd);
                //Writes to cookies
                Response.Cookies.Append("Token", jsd);
            }
            else {
                return View("cta");
            }
            return Redirect("/");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerForm"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromForm] string Email, [FromForm] string UserName, [FromForm] string Password, [FromForm] IFormFile ProfilePhoto) {
            bool exsist = await databaseService.CheckIfEmailIsTaken(Email);
            if (exsist) { return View("cta"); }
            //Creates the account in the database service
            UserAccount userAccount = await databaseService.CreateAccount(new UserAccount() {
                Email = Email,
                Password = Password,
                profile = new ProfileModel() {
                    UserName = UserName
                }
            });
            //If there is a profile pifture in the form, this updates the record in the database after uploading the image to firebase
            if (ProfilePhoto != null) {
                userAccount.profile.ProfilePicture = new Media() {
                    mediaType = TypeOfMedia.Image,
                    url = await mediaService.UpdateProfilePicture(ProfilePhoto, userAccount.userId)
                };
                _ = databaseService.UpdateUserAccount(userAccount.profile, nameof(userAccount.profile), userAccount.userId, null);
            }
            //Gets the model that contains the JWT token
            AuthToken authToken = authService.GetToken(userAccount);
            string jsd = JsonSerializer.Serialize(authToken);
            //Adds the token to client's Cookies
            Response.Cookies.Append("Token", jsd);
            return Redirect("/");
        }
        public class RegisterForm {
            
        }
    }
}