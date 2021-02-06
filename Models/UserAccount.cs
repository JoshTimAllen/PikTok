using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class UserAccount {
        public ObjectId _id { set; get; }
        public string userId{ get; set; }
        public string externalUserId{ get; set; }
        public DateTime DateRegistered { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ProfileModel profile { get; set; }
        public List<PostModel> posts { get; set; } = new List<PostModel>();
        public List<ChatModel> chats { get; set; } = new List<ChatModel>();
        public List<string> Followers { get; set; } = new List<string>();
        public List<string> Following { get; set; } = new List<string>();
        public List<string> SentRequests { get; set; } = new List<string>();
    }
}
