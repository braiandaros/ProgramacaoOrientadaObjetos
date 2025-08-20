using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Bem-vindo ao Programa de Perguntas ===");

        // Pergunta 1
        Console.Write("Qual é o seu nome? ");
        string nome = Console.ReadLine();

        // Pergunta 2
        Console.Write("Qual é a sua cidade? ");
        string cidade = Console.ReadLine();

        // Pergunta 3 (número da sorte)
        Console.Write("Qual é o seu número da sorte? ");
        string entradaNumero = Console.ReadLine();
        int numeroSorte;

        // Verifica se o valor digitado é um número válido
        while (!int.TryParse(entradaNumero, out numeroSorte))
        {
            Console.Write("Por favor, digite um número válido: ");
            entradaNumero = Console.ReadLine();
        }

        // Faz uma conta simples com o número da sorte
        int resultado = (numeroSorte * 2) + 10;

        // Pergunta 4
        Console.Write("Qual é o seu hobby favorito? ");
        string hobby = Console.ReadLine();

        // Exibe as informações finais
        Console.WriteLine("\n=== Resumo ===");
        Console.WriteLine($"Nome: {nome}");
        Console.WriteLine($"Cidade: {cidade}");
        Console.WriteLine($"Número da sorte: {numeroSorte}");
        Console.WriteLine($"Seu número da sorte vezes 2 mais 10 é: {resultado}");
        Console.WriteLine($"Hobby: {hobby}");
    }
}
