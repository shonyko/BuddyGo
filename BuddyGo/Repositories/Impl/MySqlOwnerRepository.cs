using BuddyGo.Data;
using BuddyGo.Models;
using BuddyGo.Utils;

namespace BuddyGo.Repositories.Impl {
    public class MySqlOwnerRepository : GenericUserRepository<Owner>, IOwnerRepository {
        //private readonly ApplicationDbContext _dbContext;
        //private readonly IPasswordEncryptor _passwordEncryptor;
        public MySqlOwnerRepository(ApplicationDbContext dbContext, IPasswordEncryptor passwordEncryptor) : base(dbContext, dbContext.Owners) {
            //_dbContext = dbContext;
            //_passwordEncryptor = passwordEncryptor;
        }

        //public async Task Create(Owner owner) {
        //    if (owner == null) throw new ArgumentNullException(nameof(owner));
        //    _dbContext.Owners.Add(owner);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task<Owner> GetById(string id) {
        //    var owner = await _dbContext.Owners.Where(o => o.Id == id).Include(o => o.Pets).FirstOrDefaultAsync();
        //    return owner;
        //}

        //public async Task<Owner> GetOwnerByLogin(Owner owner) {
        //    //Console.WriteLine($"IN: Username: {owner.AuthData.Username} Password: {owner.AuthData.Password}");
        //    if (owner == null) throw new ArgumentNullException(nameof(owner));
        //    var byLogin = await _dbContext.Owners
        //        .Include(o => o.AuthData)
        //        .Include(o => o.Pets)
        //        .FirstOrDefaultAsync(o => o.AuthData.Username.Equals(owner.AuthData.Username) && o.AuthData.Password.Equals(owner.AuthData.Password));

        //    //var byLogin = users.FirstOrDefault(o => {
        //    //    //Console.WriteLine($"OUT: Username: {o.AuthData.Username} Password: {o.AuthData.Password}");
        //    //    //var hash = Encoding.UTF8.GetBytes(o.AuthData.Password);
        //    //    //var salt = Encoding.UTF8.GetBytes(o.AuthData.Salt);
        //    //    //return _passwordEncryptor.VerifyPassword(owner.AuthData.Password, hash, salt);
        //    //});
        //    return byLogin;
        //}

        //public IEnumerable<Owner> GetAll() {
        //    var owners = _dbContext.Owners.ToList();
        //    return owners;
        //}

        //public async Task Update(Owner owner) {
        //    _dbContext.Entry(await GetById(owner.Id)).CurrentValues.SetValues(owner);
        //    await _dbContext.SaveChangesAsync();
        //}

        //public async Task Delete(Owner owner) {
        //    if (owner == null) throw new ArgumentNullException(nameof(owner));
        //    _dbContext.Owners.Remove(owner);
        //    await _dbContext.SaveChangesAsync();
        //}
    }
}
