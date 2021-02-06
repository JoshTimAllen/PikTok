using System;

namespace PikTok.Models {
    public class Media {
        public TypeOfMedia mediaType { get; set; }
        public string url { get; set; }
    }
    public enum TypeOfMedia {
        Image,
        Video,
        Gif
    }
}