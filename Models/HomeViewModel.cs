using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class HomeViewModel {
        public bool isOwner { get; set; }
        public bool isFriend { get; set; }
        public UserAccount userAccount { get; set; }
    }
}
