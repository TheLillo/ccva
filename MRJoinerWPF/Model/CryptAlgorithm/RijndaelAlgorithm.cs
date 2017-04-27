﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MRJoinerWPF.Model.CryptAlgorithm
{
    public class RijndaelAlgorithm : IAlgorithm
    {
        public byte[] encrypt(byte[] file, string password)
        {
            using (RijndaelManaged m = new RijndaelManaged())
            using (SHA256Managed h = new SHA256Managed())
            {
                byte[] salt = new byte[32];
                new RNGCryptoServiceProvider().GetBytes(salt);
                Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 };
                m.KeySize = 256;
                m.BlockSize = 256;
                byte[] hash = h.ComputeHash(file);
                m.Key = derivedKey.GetBytes(m.KeySize / 8);
                m.IV = derivedKey.GetBytes(m.BlockSize / 8);

                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(hash, 0, hash.Length);
                    ms.Write(salt, 0, salt.Length);
                    using (CryptoStream cs = new CryptoStream(ms, m.CreateEncryptor(), CryptoStreamMode.Write))
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
            using (RijndaelManaged m = new RijndaelManaged())
            using (SHA256Managed h = new SHA256Managed())
            {
                try
                {
                    m.KeySize = 256;
                    m.BlockSize = 256;

                    byte[] hash = new byte[32];
                    ms.Read(hash, 0, 32);
                    byte[] salt = new byte[32];
                    ms.Read(salt, 0, 32);

                    Rfc2898DeriveBytes derivedKey = new Rfc2898DeriveBytes(password, salt) { IterationCount = 10000 };
                    m.Key = derivedKey.GetBytes(m.KeySize / 8);
                    m.IV = derivedKey.GetBytes(m.BlockSize / 8);

                    using (MemoryStream result = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, m.CreateDecryptor(), CryptoStreamMode.Read))
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
