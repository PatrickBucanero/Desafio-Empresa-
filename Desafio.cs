using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();  // Limpa a tela a cada nova execução de exercício
            Console.WriteLine("\nEscolha o exercício para executar (1-5) ou digite 0 para sair:");
            Console.WriteLine("1 - Soma (Laço com K e INDICE)");
            Console.WriteLine("2 - Verificar número na sequência de Fibonacci");
            Console.WriteLine("3 - Análise de faturamento diário");
            Console.WriteLine("4 - Percentual de faturamento por estado");
            Console.WriteLine("5 - Inverter uma string");
            Console.Write("Opção: ");

            string opcaoInput = Console.ReadLine();
            int opcao;

            // Verifica se a opção é válida
            if (!int.TryParse(opcaoInput, out opcao) || opcao < 0 || opcao > 5)
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                continue;
            }

            if (opcao == 0)
            {
                Console.WriteLine("Saindo do programa...");
                break;  // Encerra o ciclo, saindo do programa
            }

            switch (opcao)
            {
                case 1:
                    Exercicio1();
                    break;
                case 2:
                    Exercicio2();
                    break;
                case 3:
                    Exercicio3();
                    break;
                case 4:
                    Exercicio4();
                    break;
                case 5:
                    Exercicio5();
                    break;
            }

            // Espera o usuário pressionar uma tecla para voltar ao menu
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }

    static void Exercicio1()
    {
        int INDICE = 13, SOMA = 0, K = 0;

        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }

        Console.WriteLine("O valor de SOMA é: " + SOMA);
    }

    static void Exercicio2()
    {
        Console.Write("Informe um número para verificar na sequência de Fibonacci: ");
        string numeroInput = Console.ReadLine();
        int numero;

        if (string.IsNullOrEmpty(numeroInput) || !int.TryParse(numeroInput, out numero))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
            return;
        }

        if (PertenceFibonacci(numero))
        {
            Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"O número {numero} não pertence à sequência de Fibonacci.");
        }
    }

    static bool PertenceFibonacci(int num)
    {
        int a = 0, b = 1, temp;

        while (b <= num)
        {
            if (b == num) return true;
            temp = b;
            b = a + b;
            a = temp;
        }

        return false;
    }

    static void Exercicio3()
    {
        List<double> faturamento = new List<double> { 0, 100, 200, 300, 0, 400, 0, 500, 600, 0, 0, 700, 0 };

        var faturamentoValido = faturamento.Where(f => f > 0).ToList();

        double menorValor = faturamentoValido.Min();
        double maiorValor = faturamentoValido.Max();
        double mediaMensal = faturamentoValido.Average();
        int diasAcimaDaMedia = faturamentoValido.Count(f => f > mediaMensal);

        Console.WriteLine($"Menor valor de faturamento: R$ {menorValor}");
        Console.WriteLine($"Maior valor de faturamento: R$ {maiorValor}");
        Console.WriteLine($"Dias com faturamento acima da média: {diasAcimaDaMedia}");
    }

    static void Exercicio4()
    {
        double sp = 67836.43;
        double rj = 36678.66;
        double mg = 29229.88;
        double es = 27165.48;
        double outros = 19849.53;

        double total = sp + rj + mg + es + outros;

        Console.WriteLine($"SP: {CalcularPercentual(sp, total):F2}%");
        Console.WriteLine($"RJ: {CalcularPercentual(rj, total):F2}%");
        Console.WriteLine($"MG: {CalcularPercentual(mg, total):F2}%");
        Console.WriteLine($"ES: {CalcularPercentual(es, total):F2}%");
        Console.WriteLine($"Outros: {CalcularPercentual(outros, total):F2}%");
    }

    static double CalcularPercentual(double valor, double total)
    {
        return (valor / total) * 100;
    }

    static void Exercicio5()
    {
        Console.Write("Informe uma string para inverter: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira uma string.");
            return;
        }

        string invertida = InverterString(input);

        Console.WriteLine($"String invertida: {invertida}");
    }

    static string InverterString(string str)
    {
        char[] chars = new char[str.Length];
        int j = 0;

        for (int i = str.Length - 1; i >= 0; i--)
        {
            chars[j] = str[i];
            j++;
        }

        return new string(chars);
    }
}
