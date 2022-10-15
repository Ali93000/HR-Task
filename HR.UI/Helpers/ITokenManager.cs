using HR.UI.Models;

namespace HR.UI.Helpers
{
    public interface ITokenManager
    {
        TokenDecodedData DecodeToken(string token);

    }
}
