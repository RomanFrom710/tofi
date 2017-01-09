using System;
using System.Security.Cryptography;
using System.Text;

namespace TOFI.Providers
{
    public static class SignatureProvider
    {
        public static string GenerateNewKey()
        {
            byte[] key;
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                key = rsa.ExportCspBlob(true);
            }
            return ConcealKey(key);
        }

        public static string Sign(string data, string key)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportCspBlob(RevealKey(key));

                var rsaFormatter = new RSAPKCS1SignatureFormatter(rsa);
                rsaFormatter.SetHashAlgorithm("SHA256");

                return ConcealSignature(rsaFormatter.CreateSignature(CalculateHash(data)));
            }
        }

        public static bool Verify(string data, string signature, string key)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportCspBlob(RevealKey(key));

                var rsaDeformatter = new RSAPKCS1SignatureDeformatter(rsa);
                rsaDeformatter.SetHashAlgorithm("SHA256");

                return rsaDeformatter.VerifySignature(CalculateHash(data), RevealSignature(signature));
            }
        }


        private static string ConcealKey(byte[] key)
        {
            return Convert.ToBase64String(key);
        }

        private static byte[] RevealKey(string key)
        {
            return Convert.FromBase64String(key);
        }

        private static string ConcealSignature(byte[] signature)
        {
            return Convert.ToBase64String(signature);
        }

        private static byte[] RevealSignature(string signature)
        {
            return Convert.FromBase64String(signature);
        }

        private static byte[] CalculateHash(string data)
        {
            var hashAlgo = SHA256.Create();
            return hashAlgo.ComputeHash(Encoding.Unicode.GetBytes(data));
        }
    }
}