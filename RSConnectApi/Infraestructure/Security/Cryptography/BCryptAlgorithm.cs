using RSConnect.Api.Domain.Entities;

namespace RSConnect.Api.Infraestructure.Security.Cryptography
{
    public class BCryptAlgorithm
    {
        public string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool Verify(string password, User user) => BCrypt.Net.BCrypt.Verify(password, user.Password);
    }
}
