using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Services {
    public class MediaService {
        string storageUrl = "jdgs-7e441.appspot.com";
        public async Task<string> UploadMedia(IFormFile file, string userId, string fileName = "") {
            if (fileName == "") {
                fileName = ObjectId.GenerateNewId(DateTime.Now).ToString();
            }
            var stream = file.OpenReadStream();
            var task = new FirebaseStorage(storageUrl)
                .Child("UserMedia")
                .Child("User-" + userId)
                .Child(fileName)
                .PutAsync(stream);
            return await task;
        }
        public async Task<string> UpdateProfilePicture(IFormFile file, string userId) {
            var stream = file.OpenReadStream();
            var task = new FirebaseStorage(storageUrl)
                .Child("UserMedia")
                .Child("User-" + userId)
                .Child("ProfilePicture")
                .PutAsync(stream);
            return await task;
        }
    }
}
