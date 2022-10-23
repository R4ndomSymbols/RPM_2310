using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;

namespace RPM_2310.Models
{
    public class StringGenerator
    {
        private static readonly string _alphabet = "1234567890asdfghjkl;'qwertyuiop[zxcvbnm,./";
        private static readonly string _colorAlphabet = "0123456789ABCDEF";
        public static string Generate(int length)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i< length; i++)
            {
                sb.Append(_alphabet[new Random().Next(length)]);
            }
            return sb.ToString();
        }

        public static Run GenerateTextLine()
        {
            var t = new Run(StringGenerator.Generate(new Random().Next(15)) + "\n");
            var col = GenerateColor();
            t.Foreground = new SolidColorBrush(
                Color.FromRgb(
                    Convert.ToByte(col[0..2], 16),
                    Convert.ToByte(col[2..4], 16),
                    Convert.ToByte(col[4..6], 16)
                    ));
            t.FontSize = new Random().Next(4, 25);
            return t;
        }

        private static string GenerateColor()
        {
            return string.Join("", Enumerable.Repeat(0, 6).Select(x => _colorAlphabet[new Random().Next(_colorAlphabet.Length)]));
        }




    }
}
