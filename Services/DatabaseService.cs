using MongoDB.Bson;
using MongoDB.Driver;
using PikTok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PikTok.Services {
    public class DatabaseService {
        private const string MONGO_URI = "mongodb+srv://admin:F8QtpGj3GncZSdbcrZGrmjUNRzM58S4VSqfiaVY3N6tdZk7HPAhq2Ry@cluster0.echv6.gcp.mongodb.net/DominoWorld?retryWrites=true&w=majority";
        private const string DATABASE_NAME = "PikTok";
        private MongoClient client;
        private IMongoDatabase database;

        private IMongoCollection<UserAccount> UserAccounts;
        public DatabaseService() {
            client = new MongoClient(MONGO_URI);
            database = client.GetDatabase(DATABASE_NAME);
            UserAccounts = database.GetCollection<UserAccount>("Users");
            //GetPlayeruserAccount("g05644537000257399114", (userAccount) => { print(userAccount.userId); });
            CreateIndex();
        }
        public async Task<UserAccount> GetUserWithUsername(string userName, Action<UserAccount> callback = null) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(user => user.profile.UserName == userName);
            var Search = UserAccounts.Find(filter);

            bool found = Search.FirstOrDefault() != null;
            /// Gets Player userAccount if found
            if (found) {
                UserAccount userAccount = await Search.FirstAsync();
                callback?.Invoke(userAccount);
                callback = null;
                return userAccount;
            }
            else {
                callback?.Invoke(null);
                callback = null;
                return null;
            }
        }
        public async Task<UserAccount> GetUser(string userId, Action<UserAccount> callback = null) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(user => user.userId == userId);
            var Search = UserAccounts.Find(filter);

            bool found = Search.FirstOrDefault() != null;
            /// Gets Player userAccount if found
            if (found) {
                UserAccount userAccount = await Search.FirstAsync();
                callback?.Invoke(userAccount);
                callback = null;
                return userAccount;
            }
            else {
                callback?.Invoke(null);
                callback = null;
                return null;
            }
        }
        public async Task<UserAccount> GetUserWithExternalId(string externalUserId, Action<UserAccount> callback = null) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(user => user.externalUserId == externalUserId);
            var Search = UserAccounts.Find(filter);

            bool found = Search.FirstOrDefault() != null;
            /// Gets Player userAccount if found
            if (found) {
                UserAccount userAccount = await Search.FirstAsync();
                callback?.Invoke(userAccount);
                callback = null;
                return userAccount;
            }
            else {
                callback?.Invoke(null);
                callback = null;
                return null;
            }
        }
        public async Task AddPost(PostModel post, UserAccount userAccount) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(search => search.userId == userAccount.userId);
            var Search = UserAccounts.Find(filter);
            bool found = await Search.AnyAsync();
            /// Gets Player record if found
            if (found) {
                UpdateDefinition<UserAccount> update = Builders<UserAccount>.Update.AddToSet("posts", post);
                await UserAccounts.UpdateOneAsync(filter, update);
                userAccount.posts.Add(post);
            }
        }
        public async Task<UserAccount> GetUser(string Email, string Password, Action<UserAccount> callback = null) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(player => player.Email == Email && player.Password == Password);
            var Search = UserAccounts.Find(filter);

            bool found = Search.FirstOrDefault() != null;
                Console.WriteLine(found);
            /// Gets Player userAccount if found
            if (found) {
                UserAccount userAccount = await Search.FirstAsync();
                callback?.Invoke(userAccount);
                callback = null;
                return userAccount;
            }
            else {
                callback?.Invoke(null);
                callback = null;
                return null;
            } 
        }
        public async Task<bool> CheckIfEmailIsTaken(string Email) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(player => player.Email == Email);
            var Search = UserAccounts.Find(filter);
            return await Search.FirstOrDefaultAsync() != null;
        }
        public async Task<UserAccount> CreateAccount(UserAccount userAccount, Action<UserAccount> callback = null) {
            userAccount.DateRegistered = DateTime.Now;
            //userAccount.LastUpdate = DateTime.Now;
            userAccount.userId = ObjectId.GenerateNewId(DateTime.Now).ToString();
            userAccount.externalUserId = ObjectId.GenerateNewId().ToString();
            //userAccount.profile.UserName = ObjectId.GenerateNewId(DateTime.Now).ToString();
            await UserAccounts.InsertOneAsync(userAccount);
            callback?.Invoke(userAccount);
            callback = null;
            return userAccount;
        }
        public async Task<UserAccount> CreateAccount(string Email, string Password, ProfileModel profile, Action<UserAccount> callback = null) {
            UserAccount userAccount = new UserAccount();
            userAccount.profile = profile;
            userAccount.DateRegistered = DateTime.Now;
            //userAccount.LastUpdate = DateTime.Now;
            userAccount.userId = ObjectId.GenerateNewId(DateTime.Now).ToString();
            //userAccount.profile.UserName = ObjectId.GenerateNewId(DateTime.Now).ToString();
            await UserAccounts.InsertOneAsync(userAccount);
            callback?.Invoke(userAccount);
            callback = null;
            return userAccount;
        }
        public async Task UpdateUserAccount<T>(T Update_Value, string nameof_Value, string userId, Action callback) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(player => player.userId == userId);
            UpdateDefinition<UserAccount> update = Builders<UserAccount>.Update
            .Set(nameof_Value, Update_Value);
            await UserAccounts.UpdateOneAsync(filter, update);
            callback?.Invoke();
            callback = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FriendUserName"></param>
        /// <param name="mydatabaseID"></param>
        /// <returns>Added or not</returns>
        public async Task<bool> Follow(string targetUserName, UserAccount userAccount) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(search => search.profile.UserName == targetUserName);
            var Search = UserAccounts.Find(filter);
            bool found = await Search.AnyAsync();
            /// Gets Player record if found
            if (found) {
                UserAccount record = await Search.FirstAsync();

                FilterDefinition<UserAccount> filter2 = Builders<UserAccount>.Filter.Where(user => user.profile.UserName == targetUserName);
                UpdateDefinition<UserAccount> update = Builders<UserAccount>.Update.AddToSet("Followers", userAccount.userId);
                await UserAccounts.UpdateOneAsync(filter2, update);

                if (!userAccount.Following.Contains(record.userId)) {
                    userAccount.Following.Add(record.userId);
                    await UpdateUserAccount(userAccount.Following, nameof(userAccount.Following), userAccount.userId, null);
                }
                return true;
            }
            else {
                return false;
            }
        }
        public async Task<bool> UpdateChat(string targetExternalId, string userId, string message, Action<bool> callback = null) {
            FilterDefinition<UserAccount> filter = Builders<UserAccount>.Filter.Where(search => search.externalUserId == targetExternalId);
            var Search = UserAccounts.Find(filter);
            bool found = await Search.AnyAsync();
            /// Gets Player record if found
            if (found) {
                UserAccount targetUser = await Search.FirstAsync();

                FilterDefinition<UserAccount> filter2 = Builders<UserAccount>.Filter.Where(user => user.userId == userId);
                UserAccount myUser = await GetUser(userId);
                ChatMessage chatMessage = new ChatMessage() {
                    message = message,
                    ownerExtrnalId = myUser.externalUserId,
                    timeSent = DateTime.Now
                };
                {
                    ChatModel chat = targetUser.chats.Find(ch => ch.externalUserId == myUser.externalUserId);
                    
                    if (chat != null) {
                        chat.chatMessages.Add(chatMessage);                        
                    }
                    else {
                        chat = new ChatModel();
                        chat.externalUserId = myUser.externalUserId;
                        chat.chatMessages = new List<ChatMessage>();
                        chat.profilePictureUrl = myUser.profile.ProfilePicture.url;
                        chat.chatMessages.Add(chatMessage);
                        targetUser.chats.Add(chat);
                    }
                    await UpdateUserAccount(targetUser.chats, nameof(targetUser.chats), targetUser.userId, null);
                }

                {
                    ChatModel chat = myUser.chats.Find(ch => ch.externalUserId == targetExternalId);
                    if (chat != null) {
                        chat.chatMessages.Add(chatMessage);
                    }
                    else {
                        chat = new ChatModel();
                        chat.externalUserId = targetExternalId;
                        chat.chatMessages = new List<ChatMessage>();
                        chat.profilePictureUrl = targetUser.profile.ProfilePicture.url;
                        chat.chatMessages.Add(chatMessage);
                        myUser.chats.Add(chat);
                    }
                    await UpdateUserAccount(myUser.chats, nameof(myUser.chats), myUser.userId, null);
                }
                callback?.Invoke(true);
                return true;
            }
            else {
                callback?.Invoke(false);
                return false;
            }
        }
        void CreateIndex() {
            var notificationLogBuilder = Builders<UserAccount>.IndexKeys;
            var indexModel = new CreateIndexModel<UserAccount>(notificationLogBuilder.Ascending(x => x.userId));
            UserAccounts.Indexes.CreateOne(indexModel);
        }
    }
}
