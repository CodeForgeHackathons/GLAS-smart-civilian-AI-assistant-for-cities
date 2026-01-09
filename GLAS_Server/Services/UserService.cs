using GLAS_Server.Services.Interfaces;
using GLAS_Server.Data;
using GLAS_Server.DTO;
using Microsoft.EntityFrameworkCore;
using GLAS_Server.Models;
namespace GLAS_Server.Services
{

    public class UserService : IUserService
    {
        private readonly AppDbContext _db;

        public UserService(AppDbContext db)
        {

            _db = db;

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

            var user = new User { FirstName = request.FirstName, LastName = request.LastName, Password = request.Password, BirthDate = request.BirthDate };
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            return (Success: true, Message: "User registered!");


        }

        public async Task<UserProfile?> LoginAsync(DTO.LoginRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.Password))
                return null;


            var exists = await _db.Users.AnyAsync(user => user.PhoneNumber == request.PhoneNumber && user.Password == request.Password);
            if (!exists)
                return null;

            var result_profile = new UserProfile
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                //....
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
