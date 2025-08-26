internal class Program
{
    private static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("\n--- Menu de Opcoes ---");
            Console.WriteLine("1. Cadastrar usuario");
            Console.WriteLine("2. Editar usuario");
            Console.WriteLine("3. Excluir usuario");
            Console.WriteLine("4. Listar usuarios");
            Console.WriteLine("5. Sair");
            Console.WriteLine("----------------------");
            Console.Write("Escolha uma opcao: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                opcao = 0;
            }
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Voce escolheu a opcao 1: Cadastrar usuario.");
                    break;
                case 2:
                    Console.WriteLine("Voce escolheu a opcao 2: Editar usuario.");
                    break;
                case 3:
                    Console.WriteLine("Voce escolheu a opcao 3: Excluir usuario.");
                    break;
                case 4:
                    Console.WriteLine("Voce escolheu a opcao 4: Listar usuarios.");
                    break;
                case 5:
                    Console.WriteLine("Saindo do programa. Ate mais!");
                    break;
                default:
                    Console.WriteLine("Opcao invalida. Por favor, escolha um numero de 1 a 5.");
                    break;
            }
        } while (opcao != 5);

    }
}