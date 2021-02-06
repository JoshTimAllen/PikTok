using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class ProfileModel {
        public string profileId { get; set; }
        public string UserName { get; set; }
        public Media ProfilePicture { get; set; }        
    }
}
