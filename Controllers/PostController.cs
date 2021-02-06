using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PikTok.Models;
using PikTok.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class PostController : Controller {
        private readonly AuthService authService;
        private readonly DatabaseService databaseService;
        private readonly MediaService mediaService;

        public PostController(AuthService authService, DatabaseService databaseService, MediaService mediaService) {
            this.authService = authService;
            this.databaseService = databaseService;
            this.mediaService = mediaService;
        }
        [HttpGet("GetHomePosts")]
        public async Task<IActionResult> GetHomePosts() {
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            List<PostModel> posts = new List<PostModel>();
            foreach (string followingId in userAccount.Following) {
                UserAccount followingAccount = await authService.GetUser(followingId);
                posts = posts.Concat(followingAccount.posts).ToList();
            }
            return Ok(posts);
        }
        [HttpGet("GetPost")]
        public async Task<IActionResult> GetPost(string UserName, int CurrentIndex) {
            Console.WriteLine("USer Name : -" + UserName);
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            if (userAccount.profile.UserName == UserName) {
                return Ok(userAccount.posts);
            }
            else {
                UserAccount accountToView = await authService.GetUserWithUserName(UserName);
                return Ok(accountToView.posts);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost([FromForm] string Description, [FromForm] List<IFormFile> Files) {
            if (!Request.Cookies.ContainsKey("Token")) {
                return View("cta");
            }
            UserAccount userAccount = await authService.GetUser(Request.Cookies);
            PostModel post = new PostModel();
            post.postId = ObjectId.GenerateNewId(DateTime.Now).ToString();
            post.profilePictureUrl = userAccount.profile.ProfilePicture.url;
            post.userId = userAccount.userId;
            post.description = Description;
            post.timePosted = DateTime.Now;
            if (Request.Form.Files.Count > 0) {
                foreach (IFormFile file in Files) {
                    Console.WriteLine(file.ContentType);
                    Media media = new Media();
                    bool isValid = false;
                    if (file.ContentType.Contains("image")) {
                        media.mediaType = TypeOfMedia.Image;
                        isValid = true;
                    }
                    else if (file.ContentType.Contains("video")) {
                        media.mediaType = TypeOfMedia.Video;
                        isValid = true;
                    }
                    if (isValid) {
                        media.url = await mediaService.UploadMedia(file, userAccount.userId);
                        post.medias.Add(media);
                    }
                }
            }
            userAccount.posts.Add(post);
            await databaseService.AddPost(post, userAccount);
            return Redirect("/" + userAccount.profile.UserName);/* View("/", new ProfileViewModel() {
                userAccount = userAccount
            });*/
        }
    }
}
