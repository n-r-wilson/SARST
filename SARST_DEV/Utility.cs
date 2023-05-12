using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace SARST_DEV {
    public static class Utility {
        public static bool IsLetter(char c) {
            if (c >= 'a' && c <= 'z'
             || c >= 'A' && c <= 'Z')
                return true;
            return false;
        }

        public static bool IsNumber(char c) {
            if (c >= '0' && c <= '9')
                return true;
            return false;
        }

        public static bool IsSymbol(char c) {
            const string valid_symbols = "!@#$%^&*()-+_=";
            if (valid_symbols.Contains(c))
                return true;
            return false;
        }

        public static bool IsValidPassword(string password) {
            if (password.Length < 8
             || password.Length > 64)
                return false;

            int number_count = 0, 
                symbol_count = 0;

            foreach (char c in password) {
                if (IsSymbol(c)) {
                    symbol_count++;
                    continue;
                }

                if (IsNumber(c)) {
                    number_count++;
                    continue;
                }
                if (IsLetter(c)) continue;

                return false; // c was an invalid char
            }

            if (symbol_count < 2
             || number_count < 2)
                return false;

            return true;
        }
        public static bool IsValidUsername(string username) {
            if (username.Length < 8
             || username.Length > 32)
                return false;

            foreach (char c in username) {
                if (!IsSymbol(c)
                 && !IsNumber(c)
                 && !IsLetter(c))
                    return false;
            }

            return true;
        }
        public static bool IsValidEmail(string email) {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }




    }
}