using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptogracia.CriptografiaVigenere
{
    public class CifraDeVigenere
    {
        //Criptografar
        public static string Criptografar(string texto, string chave)
        {
            chave = chave.ToUpper();
            var indiceChave = 0;

            return new string(texto.Select(caractere =>
            {
                if (char.IsLetter(caractere))
                {
                    char baseLetra = char.IsUpper(caractere) ? 'A' : 'a';
                    char letraChave = chave[indiceChave % chave.Length];
                    indiceChave++;
                    return (char)((caractere - baseLetra + (letraChave - 'A')) % 26 + baseLetra);
                }
                return caractere;
            }).ToArray());
        }

        //Descriptografar
        public static string Descriptografar(string texto, string chave)
        {
            chave = chave.ToUpper();
            var indiceChave = 0;

            return new string(texto.Select(caractere =>
            {
                if (char.IsLetter(caractere))
                {
                    char baseLetra = char.IsUpper(caractere) ? 'A' : 'a';
                    char letraChave = chave[indiceChave % chave.Length];
                    indiceChave++;
                    return (char)((caractere - baseLetra - (letraChave - 'A') + 26) % 26 + baseLetra);
                }
                return caractere;
            }).ToArray());
        }
    }
}
