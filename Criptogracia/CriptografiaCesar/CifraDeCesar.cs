using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Criptogracia.CriptografiaCesar
{
    public class CifraDeCesar
    {
        //Criptografia
        public static string Criptografar (string texto, int deslocamento)
        {
            return new string(texto.Select(caractere =>
            {
                if (char.IsLetter(caractere))
                {
                    char baseLetra = char.IsUpper(caractere) ? 'A' : 'a';
                    return (char)((caractere - baseLetra + deslocamento) % 26 + baseLetra);
                }
                return caractere;
            }).ToArray());
        }

        //Descriptografia
        public static string Descriptografar(string texto, int descolcamento)
        {
            return Criptografar(texto, 26 - descolcamento);
        }
    }
}
