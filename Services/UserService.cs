using System.Linq;
using Models.Context;
using Models.Enitites;

namespace Services
{
    public class UserService: IUserService
    {  
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public User GetUserByEmail(string email)
        {
            return _db.Users.First(u => u.Email == email);
        }

        public void UpdatePasswordByUserId(int id, string password)
        {
            var user = _db.Users.Find(id);
            user.Password = password;
            _db.Update(user);
            _db.SaveChanges();
        }
    }
}
