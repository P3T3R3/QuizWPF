using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCreator.Model
{
    public class CaesarCipher
    {
        private static readonly char[] PolishAlphabet = {
        'a', 'ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j', 'k', 'l',
        'ł', 'm', 'n', 'ń', 'o', 'ó', 'p', 'q', 'r', 's', 'ś', 't', 'u', 'v', 'w',
        'x', 'y', 'z', 'ź', 'ż'
    };

        public static string Encrypt(string text, int shift)
        {
            StringBuilder encryptedText = new StringBuilder();

            foreach (char c in text)
            {
                char encryptedChar = EncryptChar(c, shift);
                encryptedText.Append(encryptedChar);
            }

            return encryptedText.ToString();
        }

        public static string Decrypt(string encryptedText, int shift)
        {
            StringBuilder decryptedText = new StringBuilder();

            foreach (char c in encryptedText)
            {
                char decryptedChar = DecryptChar(c, shift);
                decryptedText.Append(decryptedChar);
            }

            return decryptedText.ToString();
        }

        private static char EncryptChar(char c, int shift)
        {
            int index = Array.IndexOf(PolishAlphabet, char.ToLower(c));
            if (index == -1)
            {
                return c;
            }

            int alphabetSize = PolishAlphabet.Length;
            int encryptedIndex = (index + shift) % alphabetSize;
            char encryptedChar = PolishAlphabet[encryptedIndex];
            return char.IsUpper(c) ? char.ToUpper(encryptedChar) : encryptedChar;
        }

        private static char DecryptChar(char c, int shift)
        {
            int index = Array.IndexOf(PolishAlphabet, char.ToLower(c));
            if (index == -1)
            {
                return c;
            }

            int alphabetSize = PolishAlphabet.Length;
            int decryptedIndex = (index - shift + alphabetSize) % alphabetSize;
            char decryptedChar = PolishAlphabet[decryptedIndex];
            return char.IsUpper(c) ? char.ToUpper(decryptedChar) : decryptedChar;
        }
    }
}
