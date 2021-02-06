using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models {
    public class MessageViewModel : IMultiParametersInOneModel {
        public UserAccount userAccount { get; set; }
    }
}
