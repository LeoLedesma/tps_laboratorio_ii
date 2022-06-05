using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class StringExtendido
    {
        public static string TotUpperFirstLetter(this String text)
        {
            string retorno = "";
            char[] chars = text.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            retorno += chars[0];

            for (int i = 1; i < text.Length; i++)
            {
                if (chars[i - 1] == ' ')
                {
                    chars[i] = char.ToUpper(chars[i]);
                }
                retorno += chars[i];
            }            

            return retorno;
        }
    }
}
