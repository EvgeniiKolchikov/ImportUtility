using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGTest.Services
{
    /// <summary>
    /// Класс для форматирования текста
    /// </summary>
    public class TextFormatService
    {
        /// <summary>
        /// убирает лишние пробелы
        /// </summary>

        public static string RemoveExtraSpaces(string input)
        {
            string[] words = input.Split(' ');
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {

                if (!string.IsNullOrWhiteSpace(word))
                {
                    result.Append(word).Append(' ');
                }
            }

            return result.ToString().Trim();
        }

        /// <summary>
        /// Пишет строку с заглавной буквы
        /// </summary>
        public static string WriteFirstCharacterToUpperCase(string input)
        {
            var result = string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                var firstChar = char.ToUpper(input[0]);
                result = firstChar + input.Substring(1);
            }
            return result;
        }

        /// <summary>
        /// Убирает все пробелы в строке
        /// </summary>
        public static string RemoveSpaces(string input)
        {
            string[] words = input.Split(' ');
            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {

                if (!string.IsNullOrWhiteSpace(word))
                {
                    result.Append(word);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Проверяет ряд на пустые строки
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static bool IsRowEmpty(string[] row)
        {

            var isRowEmpty = true;

            foreach (var item in row)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    isRowEmpty = false;
                    break;
                }
            }

            return isRowEmpty;
        }
    }
}
