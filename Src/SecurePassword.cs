﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Src
{
    internal class SecurePassword
    {
        public static string HashPassword(string password)
        {
            string passwordHash;

            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;
        }

        public static void VerifyPassword(string password, string passwordHash)
        {
            byte[] hashBytes = Convert.FromBase64String(passwordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();
        }
    }
}

