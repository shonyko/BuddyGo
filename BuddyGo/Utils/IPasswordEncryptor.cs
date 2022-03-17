namespace BuddyGo.Utils {
    public interface IPasswordEncryptor {
        public void CreatePasswordHash(string password, out byte[] hash, out byte[] salt);
        public bool VerifyPassword(string password, byte[] hash, byte[] salt);
    }
}
