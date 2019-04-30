using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDb
{
       class Program
        {
            static void Main(string[] args)
            {
                var senha = "Abc123!@#";
                var senhaEncryptValue = EncryptValue(senha);
                var senhaDecryptValue = DecryptValue(senhaEncryptValue);

                LoadDatabase.CreateTables(true, senhaEncryptValue);
            }

            public static string EncryptValue(string text)
            {
                try
                {
                    byte[] encData_byte = new byte[text.Length];

                    encData_byte = System.Text.Encoding.UTF8.GetBytes(text);
                    string encodedData = Convert.ToBase64String(encData_byte);

                    return encodedData;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error in base64Encode" + ex.Message);
                }
            }

            public static string DecryptValue(string text)
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecode_byte = Convert.FromBase64String(text);

                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);

                char[] decoded_char = new char[charCount];

                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new string(decoded_char);

                return result;
            }
        
    }
}
