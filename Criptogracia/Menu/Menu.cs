using Criptogracia.AnaliseFrequencia;
using Criptogracia.CriptografiaCesar;
using Criptogracia.CriptografiaVigenere;
using Criptografia.DetectorDeCriptografia;

namespace Criptogracia.Menu
{
    public class Menu
    {
        public static void Exibir()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Criptografia com Cifra de César");
                Console.WriteLine("2 - Descriptografia com Cifra de César");
                Console.WriteLine("3 - Criptografia com Cifra de Vigenère");
                Console.WriteLine("4 - Descriptografia com Cifra de Vigenère");
                Console.WriteLine("5 - Análise de Frequência");
                Console.WriteLine("6 - Detectar e Decifrar Criptografia");
                Console.WriteLine("0 - Sair");

                Console.Write("\nDigite sua escolha: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Criptografia com Cifra de César!");
                        Console.Write("Digite o texto: ");
                        var texto = Console.ReadLine();
                        Console.Write("Insira o deslocamento (apenas números): ");
                        if (int.TryParse(Console.ReadLine(), out var deslocamento))
                        {
                            Console.WriteLine($"Texto Criptografado: {CifraDeCesar.Criptografar(texto, deslocamento)}");
                        }
                        else
                        {
                            Console.WriteLine("Deslocamento inválido! Tente novamente.");
                        }
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Descriptografia com Cifra de César!");
                        Console.Write("Digite o texto criptografado: ");
                        var textoCriptografado = Console.ReadLine();
                        Console.Write("Insira o deslocamento (apenas números): ");
                        if (int.TryParse(Console.ReadLine(), out var deslocamentoCesar))
                        {
                            Console.WriteLine($"Texto Descriptografado: {CifraDeCesar.Descriptografar(textoCriptografado, deslocamentoCesar)}");
                        }
                        else
                        {
                            Console.WriteLine("Deslocamento inválido! Tente novamente.");
                        }
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Criptografia com Cifra de Vigenère!");
                        Console.Write("Digite o texto: ");
                        texto = Console.ReadLine();
                        Console.Write("Insira a chave: ");
                        var chave = Console.ReadLine();
                        Console.WriteLine($"Texto Criptografado: {CifraDeVigenere.Criptografar(texto, chave)}");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Descriptografia com Cifra de Vigenère!");
                        Console.Write("Digite o texto criptografado: ");
                        textoCriptografado = Console.ReadLine();
                        Console.Write("Insira a chave: ");
                        chave = Console.ReadLine();
                        Console.WriteLine($"Texto Descriptografado: {CifraDeVigenere.Descriptografar(textoCriptografado, chave)}");
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Análise de Frequência!");
                        Console.Write("Digite o texto para análise: ");
                        texto = Console.ReadLine();
                        var frequencia = AnaliseDeFrequencia.Analisar(texto);
                        AnaliseDeFrequencia.ExibirFrequencia(frequencia);
                        Console.WriteLine("\nPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.Clear();
                        Console.WriteLine("Tentativa de Quebra de Criptografia!");
                        Console.Write("Digite o texto criptografado: ");
                        textoCriptografado = Console.ReadLine();
                        Console.WriteLine("\nTentando quebrar o texto como Cifra de César:");
                        for (int deslocamentoTentativa = 1; deslocamentoTentativa < 26; deslocamentoTentativa++)
                        {
                            string tentativa = CifraDeCesar.Descriptografar(textoCriptografado, deslocamentoTentativa);
                            Console.WriteLine($"Deslocamento {deslocamentoTentativa}: {tentativa}");
                        }
                        Console.WriteLine("\nTentando quebrar o texto como Cifra de Vigenère:");
                        DetectorDeCriptografia.QuebrarVigenereForcaBruta(textoCriptografado);
                        Console.ReadKey();
                        break;

                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do programa...");
                        return;

                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
