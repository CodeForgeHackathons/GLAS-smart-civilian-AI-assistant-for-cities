using GLAS_Server.Services.Interfaces;
using GLAS_Server.Data;
using GLAS_Server.DTO;
using Microsoft.EntityFrameworkCore;
using GLAS_Server.Models;
using BCrypt.Net;
namespace GLAS_Server.Services
{

    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly IJwtTokenProvider _jwtTokenProvider;

        public UserService(AppDbContext db, IJwtTokenProvider jwtTokenProvider)
        {

            _db = db;
            _jwtTokenProvider = jwtTokenProvider;

        }

        public async Task<UserProfile?> GetProfileAsync(uint id)
        {

            var user = await _db.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user == null)
                return null;

            var profileData = new UserProfile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
            };
            return profileData;
        }
        //   public async Task<bool?> DeleteUserAsync(int userid) => false; //soon

        public async Task<(bool Success, string Message)> RegisterAsync(DTO.RegisterRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName) || string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.BirthDate))
                return (false, "Enter all lines");

            var exists = await _db.Users.AnyAsync(user => user.PhoneNumber == request.PhoneNumber);

            if (exists)
                return (false, "User already exists");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = hashedPassword,
                BirthDate = request.BirthDate,
                PhoneNumber = request.PhoneNumber
            };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return (Success: true, Message: "User registered!");


        }

        public async Task<LoginResponse?> LoginAsync(DTO.LoginRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.Password))
                return null;


            var user = await _db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return null;

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return null;

            var token = _jwtTokenProvider.GenerateToken(user.Id, user.PhoneNumber);

            var result_profile = new LoginResponse
            {
                AccountID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                Token = token
            };
            return result_profile;

        }
        public async Task<(bool, string)> UpdateProfileAsync(DTO.UserProfile request)
        {

            var user = await _db.Users.FirstOrDefaultAsync(user => user.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return (true, "User not found");

            user.BirthDate = request.BirthDate;
            //...
            await _db.SaveChangesAsync();
            return (true, "Profile updated!");

        }


    }

}
