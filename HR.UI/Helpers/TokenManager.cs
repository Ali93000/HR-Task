using HR.UI.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace HR.UI.Helpers
{
    public class TokenManager : ITokenManager
    {
        public TokenDecodedData DecodeToken(string token)
        {
            token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIiLCJlbWFpbCI6Im1hbmFnZXJAZ21haWwuLmNvbSIsImp0aSI6IjIiLCJVc2VySWQiOiIyIiwiVXNlck5hbWUiOiJtZSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkhSIE1hbmFnZXIiLCJleHAiOjE2NjU4NzI1MTEsImlzcyI6IlNlY3VyZUFwaSIsImF1ZCI6IlNlY3VyZUFwaVVzZXJzIn0.sAdYBOtn8VmDNBM93B6S8SJ6XFzocRARFkKd9a6I9EQ";
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(token);
            var tokenS = jsonToken as JwtSecurityToken;

            TokenDecodedData tokenDecodedData = new TokenDecodedData();
            tokenDecodedData.Email = tokenS.Claims.First(claim => claim.Type == "email").Value;
            tokenDecodedData.Jti = tokenS.Claims.First(claim => claim.Type == "jti").Value;
            tokenDecodedData.UserId = tokenS.Claims.First(claim => claim.Type == "UserId").Value;
            tokenDecodedData.UserName = tokenS.Claims.First(claim => claim.Type == "UserName").Value;

            List<string> roles = new List<string>();

            foreach (var item in jsonToken.Claims)
            {
                switch (item.Type)
                {
                    case "role":
                        roles.Add(item.Value);
                        break;
                }
            }
            tokenDecodedData.Roles = roles;
            return tokenDecodedData;
        }
    }
}
