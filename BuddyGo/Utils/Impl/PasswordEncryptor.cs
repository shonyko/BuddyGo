using System.Security.Cryptography;

namespace BuddyGo.Utils.Impl {
    public class PasswordEncryptor : IPasswordEncryptor
    {
        public void CreatePasswordHash(string password, out byte[] hash, out byte[] salt) {
            using(var hmac = new HMACSHA512()) {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                hmac.Dispose();
            }
        }

        public bool VerifyPassword(string password, byte[] hash, byte[] salt) {
            using (var hmac = new HMACSHA512(salt)) {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                hmac.Dispose();

                return computedHash.SequenceEqual(hash);
            }
        }
    }
}
