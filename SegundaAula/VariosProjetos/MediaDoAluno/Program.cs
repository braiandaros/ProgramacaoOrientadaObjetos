internal class Program
{
    private static void Main(string[] args)
    {
        string nome;
        Console.Write("Digite o nome do aluno: ");
        nome = Console.ReadLine();

        double nota1, nota2, nota3, media;
        Console.Write("Digite a primeira nota entre 0 e 10: ");
        nota1 = double.Parse(Console.ReadLine());

        Console.Write("Digite a segunda nota entre 0 e 10:");
        nota2 = double.Parse(Console.ReadLine());

        Console.Write("Digite a terceira nota entre 0 e 10:");
        nota3 = double.Parse(Console.ReadLine());

        media = (nota1 +  nota2 + nota3)/3;
        Console.WriteLine($"A media das tres notas do aluno {nome} é {media}");

        if (media > 7) {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"O aluno {nome} esta aprovado");
            Console.WriteLine("-------------------------------");
        }
        else {
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"O aluno {nome} esta reprovado");
            Console.WriteLine("-------------------------------");
        }

    }
}