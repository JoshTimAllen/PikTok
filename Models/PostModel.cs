using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class PostModel {
        public string userId { get; set; }
        public string postId { get; set; }
        public string profilePictureUrl { get; set; }
        public string description { get; set; } = " ";
        public List<Media> medias { get; set; } = new List<Media>();
        public DateTime timePosted { get; set; }
    }
}
