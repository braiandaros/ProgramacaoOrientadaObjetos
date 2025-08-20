internal class Program
{
    private static void Main(string[] args)
    {
        String nome1, nome2, nome3, nome4, aux;
        Console.WriteLine("Digite seu nome#1");
        nome1 = Console.ReadLine();

        Console.WriteLine("Digite seu nome#2");
        nome2 = Console.ReadLine();

        Console.WriteLine("Digite seu nome#3");
        nome3 = Console.ReadLine();

        Console.WriteLine("Digite seu nome#4");
        nome4 = Console.ReadLine();

        //mecanismo troca de nomes
        aux = nome1;
        nome1 = nome4;

        nome4 = aux;
        aux = nome2;

        nome2 = nome3;
        nome3 = aux;

        Console.WriteLine("Os nomes ao contrario sao:");
        Console.WriteLine(nome1);
        Console.WriteLine(nome2);
        Console.WriteLine(nome3);
        Console.WriteLine(nome4);
    }
}