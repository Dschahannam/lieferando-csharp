using Lieferando.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lieferando.Utilities
{
    public class Hash
    {
        public string Encode(IHashable hashableInterface)
        {
            StringBuilder builder = new StringBuilder();
            using (var provider = System.Security.Cryptography.MD5.Create())
                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(hashableInterface.GetHashString())))
                    builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }

        public string Encode(string Input)
        {
            StringBuilder builder = new StringBuilder();

            using (var provider = System.Security.Cryptography.MD5.Create())
                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(Input)))
                    builder.Append(b.ToString("x2").ToLower());

            return builder.ToString();
        }
    }
}
