using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class ChatModel {
        public string profilePictureUrl { get; set; }
        public string externalUserId { get; set; }
        public string userName { get; set; }
        public List<ChatMessage> chatMessages { get; set; } = new List<ChatMessage>();
    }
    public class ChatMessage {
        public string ownerExtrnalId { get; set; }
        public string message { get; set; }
        public DateTime timeSent { get; set; }
    }
}
