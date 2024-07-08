using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject2.Helpers
{
    public class RandomUserGenerator
    {
        private static Random random = new Random();
        public static string GenerateName()
        {
            string[] prefixes = { "user", "customer", "admin", "testuser", "guest" };
            string[] suffixes = { "123", "456", "789", "abc", "xyz" };

            string prefix = prefixes[random.Next(prefixes.Length)];
            string suffix = suffixes[random.Next(suffixes.Length)];

            return $"{prefix}_{suffix}";
        }

        public static string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";
            const int passwordLength = 10;

            char[] password = new char[passwordLength];
            for (int i = 0; i < password.Length; i++)
            {
                password[i] = chars[random.Next(chars.Length)];
            }

            return new string(password);
        }

        public static string GenerateEmail()
        {
            string[] domains = { "example.com", "test.com", "domain.com", "mail.com" };
            string[] providers = { "gmail", "yahoo", "hotmail", "outlook" };

            string username = GenerateName();
            string provider = providers[random.Next(providers.Length)];
            string domain = domains[random.Next(domains.Length)];

            return $"{username}@{provider}.{domain}";
        }
    }
}
