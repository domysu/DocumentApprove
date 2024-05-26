using DokumentuTvirtinimoSistema.Interfaces;
using DokumentuTvirtinimoSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DokumentuTvirtinimoSistema.Services
{
    public class UserService : IUser
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AppDbContext _dbContext;

        public UserService(AppDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> AddUserAsync(User user, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException(nameof(password), "Password cannot be null or empty.");
                }

                user.PasswordHash = _passwordHasher.HashPassword(user, password);
                user.isActive = true;
                user.LastLogin = DateTime.UtcNow;

                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
               return user;
            }
            catch
            {
                throw;
            }
        }
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.Include(u => u.Roles)
                                         .FirstOrDefaultAsync(u => u.Username == username);
        }
    
    }
}
