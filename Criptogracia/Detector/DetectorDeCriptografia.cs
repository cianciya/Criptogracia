using System;
using System.Collections.Generic;
using System.Linq;

namespace Criptografia.DetectorDeCriptografia
{
    public class DetectorDeCriptografia
    {
        private static readonly HashSet<string> PalavrasValidas = new()
        {
            // Lista de palavras válidas
            "A", "AS", "EU", "ELA", "ELE", "ESTÁ", 
            
            "COUNTRY", "JOURNEY", "TRAVEL", "VACATION"
        };

        // Método para verificar se o texto é uma Cifra de César
        public static bool EhCifraDeCesar(string texto)
        {
            texto = NormalizarTexto(texto);

            for (int deslocamento = 1; deslocamento < 26; deslocamento++)
            {
                string tentativa = DescriptografarCesar(texto, deslocamento);
                if (ContemPalavraValida(tentativa))
                {
                    Console.WriteLine($"Texto decifrado com deslocamento {deslocamento}: {tentativa}");
                    return true;
                }
            }
            return false;
        }

        // Método para descriptografar com Cifra de César
        private static string DescriptografarCesar(string texto, int deslocamento)
        {
            return new string(texto.Select(c =>
            {
                if (!char.IsLetter(c)) return c;

                char baseLetra = char.IsUpper(c) ? 'A' : 'a';
                return (char)((c - baseLetra - deslocamento + 26) % 26 + baseLetra);
            }).ToArray());
        }

        // Método para verificar se o texto contém palavras válidas
        private static bool ContemPalavraValida(string texto)
        {
            return PalavrasValidas.Any(palavra => texto.Contains(palavra, StringComparison.OrdinalIgnoreCase));
        }

        // Método para detectar a Cifra de Vigenère
        public static void QuebrarVigenereForcaBruta(string texto)
        {
            texto = NormalizarTexto(texto);

            // Itera sobre as palavras cadastradas como chaves
            foreach (var chave in PalavrasValidas)
            {
                string tentativa = DescriptografarVigenere(texto, chave);
                Console.WriteLine($"Tentando com chave '{chave}': {tentativa} \n");

                // Verifica se a tentativa contém uma palavra válida
                foreach (var palavra in PalavrasValidas)
                {
                    if (tentativa.Contains(palavra, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"Texto decifrado com chave '{chave}': {tentativa}");
                        // Não retorna, apenas exibe a chave e o texto decifrado
                        break; // Sai do loop de palavras válidas, mas continua verificando outras chaves
                    }
                }
            }

            Console.WriteLine("Não foi possível decifrar o texto com força bruta.");
        }





        // Método para descriptografar a Cifra de Vigenère
        private static string DescriptografarVigenere(string texto, string chave)
        {
            var resultado = new List<char>();
            int chaveIndex = 0;

            foreach (char c in texto)
            {
                if (!char.IsLetter(c))
                {
                    resultado.Add(c);
                    continue;
                }

                char baseLetra = char.IsUpper(c) ? 'A' : 'a';
                char novaLetra = (char)((c - baseLetra - (chave[chaveIndex] - baseLetra) + 26) % 26 + baseLetra);
                resultado.Add(novaLetra);
                chaveIndex = (chaveIndex + 1) % chave.Length;
            }

            return new string(resultado.ToArray());
        }

        // Gerar todas as combinações possíveis de um alfabeto com tamanho fixo
        private static IEnumerable<string> GerarCombinacoes(string alfabeto, int tamanho)
        {
            if (tamanho == 1)
                return alfabeto.Select(c => c.ToString());

            var menores = GerarCombinacoes(alfabeto, tamanho - 1);
            return menores.SelectMany(menor => alfabeto.Select(c => menor + c));
        }

        // Método para normalizar o texto
        private static string NormalizarTexto(string texto)
        {
            return new string(texto.Where(c => char.IsLetter(c)).Select(c => char.ToUpper(c)).ToArray());
        }
    }
}
