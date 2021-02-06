using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PikTok.Models;
using PikTok.Models.PacketModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebSocketSharp;
using WebSocketSharp.NetCore;
using WebSocketSharp.NetCore.Server;

namespace PikTok.Services {
    public class WebSocketServerService {
        private readonly AuthService authService;
        static IServiceProvider serviceProvider;
        /// <summary>
        /// Key: Websocket connection ID, 
        /// Value: userId
        /// </summary>
        static List<WebSocketConnectionData> webSocketChatConnections = new List<WebSocketConnectionData>();
        public static List<string> onlineUsers = new List<string>();
        public WebSocketServerService(AuthService authService, IServiceProvider _serviceProvider) {
            this.authService = authService;
            serviceProvider = _serviceProvider;
        }
        public class ChatService : WebSocketBehavior {
            public ChatService() {
                authService = serviceProvider.GetService<AuthService>();
                databaseService = serviceProvider.GetService<DatabaseService>();
            }
            AuthService authService;
            DatabaseService databaseService;
            public WebSocketConnectionData webSocketConnectionData { get; private set; }
            protected override void OnOpen() {
                var TokenCookie = Context.CookieCollection.First(c => c.Name == "Token");
                if (TokenCookie == null) { return; }
                _ = authService.GetUserWithJsonToken(HttpUtility.UrlDecode(TokenCookie.Value), (userAccount) => {
                    if (userAccount != null) {
                        webSocketConnectionData = new WebSocketConnectionData(ID, userAccount.userId, userAccount.externalUserId, this);
                        webSocketChatConnections.Add(webSocketConnectionData);

                        Console.WriteLine(userAccount.profile.UserName);
                        Console.WriteLine("Connection count = " + webSocketChatConnections.Count);

                        if (!onlineUsers.Contains(userAccount.userId)) {
                            onlineUsers.Add(userAccount.userId);
                        }
                    }
                    else {
                        Close();
                    }
                });
                Console.WriteLine("Connected ID - " + ID);
            }
            protected override void OnClose(CloseEventArgs e) {
                if (webSocketConnectionData != null && webSocketChatConnections.Contains(webSocketConnectionData)) {
                    webSocketChatConnections.Remove(webSocketConnectionData);
                    _ = RemoveFromOnlineList();
                }
                Console.WriteLine("Disconnected ID - " + ID);
                Console.WriteLine("Connection count = " + webSocketChatConnections.Count);
            }
            async Task RemoveFromOnlineList() {
                await Task.Delay(10000);
                if (onlineUsers.Contains(webSocketConnectionData.UserId)) {
                    onlineUsers.Remove(webSocketConnectionData.UserId);
                }
            }
            protected override void OnMessage(MessageEventArgs e) {
                if (e.IsText) {
                    Console.WriteLine(e.Data);
                    IPacket packet = JsonConvert.DeserializeObject<iPacket>(e.Data);
                    Console.WriteLine(packet.packetType);
                    switch (packet.packetType) {
                        case PacketType.NewMessage: {
                            _ = SendChatMessage(JsonConvert.DeserializeObject<MessagePacket>(e.Data));
                            break;
                        }
                    }
                }
            }
            async Task SendChatMessage(MessagePacket messagePacket) {
                var list = webSocketChatConnections.FindAll(con => con.ExternalUserId == messagePacket.externalUserId);
                await databaseService.UpdateChat(messagePacket.externalUserId, webSocketConnectionData.UserId, messagePacket.message);
                foreach (WebSocketConnectionData con in list) {
                    ChatService chatService = (ChatService)con.Service;
                    chatService.Send(JsonConvert.SerializeObject(messagePacket));
                }
            }
        }
        public void Start() {
            Console.WriteLine("Websocket started");
            var wssv = new WebSocketServer("ws://localhost:1000");
            wssv.AddWebSocketService<ChatService>("/chat");
            wssv.Start();
        }
        public async Task UpdateOnlineStatus(string userId) {

        }
        public class WebSocketConnectionData {
            public WebSocketConnectionData(string connectionId, string userId, string externalUserId, WebSocketBehavior service) {
                ConnectionId = connectionId;
                UserId = userId;
                ExternalUserId = externalUserId;
                Service = service;
            }

            public string ConnectionId { get; }
            public string UserId { get; }
            public string ExternalUserId { get; }
            public WebSocketBehavior Service { get; }
        }
    }
}