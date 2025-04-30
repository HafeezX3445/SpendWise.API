using SpendWise.API.DTOs;

namespace SpendWise.API.Repository.IRepo
{
    public interface IUserRepository
    {
        Task<UserResponseDto> RegisterAsync(RegisterUserDto dto);
        Task<UserResponseDto> LoginAsync(LoginUserDto dto);
    }

}
