using GLAS_Server.Services.Interfaces;
using GLAS_Server.Data;
using GLAS_Server.DTO;
using Microsoft.EntityFrameworkCore;
using GLAS_Server.Models;
using BCrypt.Net;
using System.Text.RegularExpressions;
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

        public async Task<(bool Success, string Message)> ChangePasswordAsync(DTO.ChangePasswordRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.OldPassword) || string.IsNullOrWhiteSpace(request.NewPassword))
                return (false, "All fields are required");

            var user = await _db.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user == null)
                return (false, "User not found");

            if (!BCrypt.Net.BCrypt.Verify(request.OldPassword, user.Password))
                return (false, "Old password is incorrect");

            // Validate new password strength
            if (request.NewPassword.Length < 8)
                return (false, "New password must be at least 8 characters long");

            if (!Regex.IsMatch(request.NewPassword, @"[a-zA-Z]") || !Regex.IsMatch(request.NewPassword, @"\d"))
                return (false, "New password must contain at least one letter and one number");

            var hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            user.Password = hashedNewPassword;
            await _db.SaveChangesAsync();
            return (true, "Password changed successfully");
        }


    }

}
