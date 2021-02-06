using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class TokenDataModel {
        public TokenDataModel () {
        }
        public TokenDataModel (string userId) {
            this.userId = userId;
        }
        public string userId { get; set; }
    }
}
