using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Models.PacketModels {
    public class JsonPacket {

    }
    public interface IPacket {
        PacketType packetType { get; set; }
    }
    public class iPacket : IPacket {
        public PacketType packetType { get; set; }
    }
    public enum PacketType {
        NewMessage,
    }
    public class MessagePacket : IPacket {
        public PacketType packetType { get; set; }
        public string externalUserId { get; set; }
        public string message { get; set; }
    }
}
