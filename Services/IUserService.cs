using Models.Enitites;

namespace Services
{
    public interface IUserService
    {
        User GetUserByEmail(string email);
        void UpdatePasswordByUserId(int id, string password);
    }
}