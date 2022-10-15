namespace HR.UI.Models
{
    public class TokenDecodedData
    {
        public TokenDecodedData()
        {
            Roles = new List<string>();
        }
        public string? Email { get; set; }
        public string Jti { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
