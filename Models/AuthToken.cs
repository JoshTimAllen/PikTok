using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class AuthToken {
        public string AuthCode { get; set; }
        public DateTime expires_in { get; set; }
    }
}
