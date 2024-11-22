using System;
using System.Collections.Generic;
using System.Linq;

namespace Criptogracia.AnaliseFrequencia
{
    public class AnaliseDeFrequencia
    {
        // Analisar sequências de caracteres (tuplas, triplas, etc.)
        public static Dictionary<string, int> Analisar(string texto, int tamanhoSequencia = 2)
        {
            return texto.Where(char.IsLetter) // Considera apenas letras
                        .Select(char.ToLower)  // Converte para minúsculas para uniformizar
                        .Select((c, i) => texto.Substring(i, tamanhoSequencia)) // Cria as sequências
                        .Where(seq => seq.Length == tamanhoSequencia) // Filtra para garantir que a sequência tenha o tamanho desejado
                        .GroupBy(seq => seq) // Agrupa por sequência
                        .ToDictionary(grupo => grupo.Key, grupo => grupo.Count()); // Cria o dicionário com a contagem
        }

        // Exibir frequência das sequências
        public static void ExibirFrequencia(Dictionary<string, int> frequencia)
        {
            foreach (var par in frequencia.OrderBy(par => par.Key))
            {
                Console.WriteLine($"{par.Key}: {par.Value}");
            }
        }
    }
}
