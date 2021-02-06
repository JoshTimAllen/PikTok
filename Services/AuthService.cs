using System.Collections.Generic;
using System.IO;
using System.Linq;
using PikTok.Models;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace PikTok.Services {
    public class AuthService {
        List<UserAccount> userAccounts = new List<UserAccount>();
        public AuthService(IWebHostEnvironment webHostEnvironment, DatabaseService databaseService) {
            WebHostEnvironment = webHostEnvironment;
            this.databaseService = databaseService;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }
        DatabaseService databaseService { get; }
        /// <summary>
        /// Gets Token from Cookies, parses the token to verify the user {( In the controller you send "Request.cookies" as a parameter )}
        /// </summary>
        /// <param name="cookies"> In the controller you send "Request.cookies" as a parameter </param>
        /// <returns>User account</returns>
        public async Task <UserAccount> GetUserWithJsonToken(string jsonToken, Action<UserAccount> callback = null) {
            AuthToken authToken = JsonConvert.DeserializeObject<AuthToken>(jsonToken);
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(authToken.AuthCode);
            //Gets the value of the Clain, which in this case is TokenDataModel as a JSON string
            string tokenDataJson = jwt.Claims.ToList().Find(cl => cl.Type == ClaimTypes.UserData).Value;
            TokenDataModel tokenData = JsonConvert.DeserializeObject<TokenDataModel>(tokenDataJson);
            UserAccount userAccount = await databaseService.GetUser(tokenData.userId);
            callback?.Invoke(userAccount);
            return userAccount;
        }
        public async Task <UserAccount> GetUser(IRequestCookieCollection cookies) {
            return await GetUserWithJsonToken(cookies["Token"]);
        }
        public async Task <UserAccount> GetUser(string userId) {
            return await databaseService.GetUser(userId);
        }
        public async Task <UserAccount> GetUserWithExternalId(string externalUserId) {
            return await databaseService.GetUserWithExternalId(externalUserId);
        }
        public async Task <UserAccount> GetUserWithUserName(string UserName) {
            return await databaseService.GetUserWithUsername(UserName);
        }
        /// <summary>
        /// Create a container Class for JWT token
        /// </summary>
        /// <param name="userAccount"></param>
        /// <returns></returns>
        public AuthToken GetToken(UserAccount userAccount) {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
            //Serializes TokenDataModel to JSON
            string tokenData =JsonConvert.SerializeObject(new TokenDataModel(userAccount.userId) {
            });
            //Creates description of the token, which are data that the token will represent. such as expire date and user's name etc... User's information are called Claims
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new List<Claim>() {
                    //Adds tokendata as a claim to the token
                    new Claim(ClaimTypes.UserData,tokenData)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // Gets the token string
            var tokenString = tokenHandler.WriteToken(token);
            return new AuthToken() {
                AuthCode = tokenString
            };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="callBack"></param>
        /// <returns></returns>
        public async Task<UserAccount> AuthenticateUser(string Email, string Password, Action<AuthResponse, UserAccount> callBack = null) {
            UserAccount userAccount = await databaseService.GetUser(Email, Password);
            if (userAccount != null) {
                callBack?.Invoke(AuthResponse.Authentic, userAccount);
                return userAccount;
            }
            else {
                callBack?.Invoke(AuthResponse.Invalid_Input, userAccount);
                return userAccount;
            }
        }
    }

}
public enum AuthResponse {
    Authentic,
    Invalid_Input,
    User_does_not_exist
}