using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 101); // Número aleatório entre 1 e 100
        int tentativa = 0;
        int palpite;

        Console.WriteLine("Bem-vindo ao jogo de adivinhação!");
        Console.WriteLine("Tente adivinhar o número entre 1 e 100.");

        while (true)
        {
            tentativa++;

            Console.Write("\nDigite seu palpite: ");
            string entrada = Console.ReadLine();

            // Verifica se é um número válido
            if (!int.TryParse(entrada, out palpite))
            {
                Console.WriteLine("Por favor, digite um número válido.");
                continue;
            }

            if (palpite < numeroSecreto)
            {
                Console.WriteLine("Muito baixo! Tente novamente.");
            }
            else if (palpite > numeroSecreto)
            {
                Console.WriteLine("Muito alto! Tente novamente.");
            }
            else
            {
                Console.WriteLine($"\nParabéns! Você acertou o número {numeroSecreto} em {tentativa} tentativas.");
                break;
            }
        }

        Console.WriteLine("\nObrigado por jogar!");
    }
}
