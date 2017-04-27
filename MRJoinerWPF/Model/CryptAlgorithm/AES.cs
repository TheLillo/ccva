﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MRJoinerWPF.Model.CryptAlgorithm
{
    public class AES : IAlgorithm
    {
        public byte[] encrypt(byte[] file, string password)
        {
            using (Aes aes = Aes.Create())
            using (SHA256Managed h = new SHA256Managed())
            {
                byte[] salt = new byte[16];
                new RNGCryptoServiceProvider().GetBytes(salt);
                Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 };
                aes.KeySize = 256;
                aes.BlockSize = 128;
                byte[] hash = h.ComputeHash(file);
                aes.Key = derivedKey.GetBytes(aes.KeySize / 8);
                aes.IV = derivedKey.GetBytes(aes.BlockSize / 8);

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(hash, 0, hash.Length);
                    ms.Write(salt, 0, salt.Length);
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(file, 0, file.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }

        public byte[] decrypt(byte[] file, string password)
        {
            using (MemoryStream ms = new MemoryStream(file, false))
            using (Aes aes = Aes.Create())
            using (SHA256Managed h = new SHA256Managed())
            {
                try
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;

                    byte[] hash = new byte[32];
                    ms.Read(hash, 0, 32);
                    byte[] salt = new byte[16];
                    ms.Read(salt, 0, 16);

                    Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 };
                    aes.Key = derivedKey.GetBytes(aes.KeySize / 8);
                    aes.IV = derivedKey.GetBytes(aes.BlockSize / 8);

                    using (MemoryStream result = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                        {
                            byte[] buffer = new byte[1024];
                            int len;
                            while ((len = cs.Read(buffer, 0, buffer.Length)) > 0)
                                result.Write(buffer, 0, len);
                        }

                        byte[] final = result.ToArray();
                        /*if (Convert.ToBase64String(hash) != Convert.ToBase64String(h.ComputeHash(final)))
                            throw new UnauthorizedAccessException();*/

                        return final;
                    }
                }
                catch
                {
                    //never leak the exception type...
                    throw new UnauthorizedAccessException();
                }
            }
        }
    }
}
