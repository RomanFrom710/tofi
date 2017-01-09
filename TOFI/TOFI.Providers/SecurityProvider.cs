using System;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TOFI.Providers
{
    public static class SecurityProvider
    {
        private static readonly byte[] Pepper;


        static SecurityProvider()
        {
            Pepper = Guid.Parse(ConfigurationManager.AppSettings["pepper"]).ToByteArray();
        }


        public static string GetNewSalt()
        {
            return ConcealSalt(Guid.NewGuid());
        }

        public static string ApplySalt(string passwordText, string saltText)
        {
            var salt = RevealSalt(saltText).ToByteArray();
            var saltedPassword = Encoding.Unicode.GetBytes(passwordText).Concat(salt).ToArray();
            var hashAlgo = SHA256.Create();
            var hash = hashAlgo.ComputeHash(saltedPassword);
            var pepperedHash = hash.Concat(Pepper).ToArray();
            return Convert.ToBase64String(hashAlgo.ComputeHash(pepperedHash));
        }


        private static string ConcealSalt(Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray());
        }

        private static Guid RevealSalt(string saltText)
        {
            return new Guid(Convert.FromBase64String(saltText));
        }
    }
}