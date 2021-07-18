﻿using Rest.net5.Data.VO;
using Rest.net5.Model;
using Rest.net5.Model.Context;
using System;
using System.Text ;
using System.Security.Cryptography;
using System.Linq;

namespace Rest.net5.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepository(MySQLContext context)
        {
            _context = context;
        }


        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(U => (U.UserName == user.UserName) && (U.Password == pass));
        }
        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any((u => u.Id.Equals(user.Id)))) return null;
            
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }

        private object ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}