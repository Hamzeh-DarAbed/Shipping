using Shipping.Entities;
using Shipping.Dto;

namespace Shipping.repo.IRepositories

{
    public interface IUserRepository: IRepository<UserModel, string>
    {
        string GenerateToken(UserModel user);
        UserModel Authenticate(LogInUserDto user);
        UserModel Login(LogInUserDto user);
        void Register(CreateUserDto user);

    }
   
}