internal class Program
{
    private static void Main(string[] args)
    {
        int opcao;
        var pedido = new List<(string Item, int Quantidade, double Preco)>();
        double valorTotal = 0.0;

        do
        {
            Console.WriteLine("\n--- Menu Completo da Lanchonete ---");
            Console.WriteLine("--- Bebidas ---");
            Console.WriteLine("1. Refrigerante (R$ 5.00)");
            Console.WriteLine("2. Suco (R$ 6.50)");
            Console.WriteLine("3. Agua (R$ 3.00)");
            Console.WriteLine("--- Comidas ---");
            Console.WriteLine("4. Hamburguer (R$ 25.00)");
            Console.WriteLine("5. Batata Frita (R$ 12.00)");
            Console.WriteLine("6. Salada (R$ 18.50)");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("7. Finalizar Pedido");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Valor total parcial: R$ {valorTotal:F2}");
            Console.Write("Escolha uma opcao: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                opcao = 0;
            }

            if (opcao >= 1 && opcao <= 6)
            {
                Console.Write("Digite a quantidade: ");
                if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
                {
                    double precoUnitario = 0;
                    string nomeItem = "";

                    switch (opcao)
                    {
                        case 1: precoUnitario = 5.00; nomeItem = "Refrigerante"; break;
                        case 2: precoUnitario = 6.50; nomeItem = "Suco"; break;
                        case 3: precoUnitario = 3.00; nomeItem = "Agua"; break;
                        case 4: precoUnitario = 25.00; nomeItem = "Hamburguer"; break;
                        case 5: precoUnitario = 12.00; nomeItem = "Batata Frita"; break;
                        case 6: precoUnitario = 18.50; nomeItem = "Salada"; break;
                    }

                    double precoTotalItem = quantidade * precoUnitario;
                    valorTotal += precoTotalItem;
                    pedido.Add((nomeItem, quantidade, precoTotalItem));
                    Console.WriteLine($"{quantidade} {nomeItem}(s) adicionado(s) ao pedido.");
                }
                else
                {
                    Console.WriteLine("Quantidade invalida. Tente novamente.");
                }
            }
            else if (opcao == 7)
            {
                Console.WriteLine("\nFinalizando o pedido...");
            }
            else
            {
                Console.WriteLine("Opcao invalida. Por favor, escolha um numero de 1 a 7.");
            }

        } while (opcao != 7);

        Console.WriteLine("\n--- Nota do Pedido ---");
        Console.WriteLine("-------------------------------------");
        if (pedido.Count == 0)
        {
            Console.WriteLine("Nenhum item adicionado ao pedido.");
        }
        else
        {
            foreach (var item in pedido)
            {
                Console.WriteLine($"{item.Item,-20} x {item.Quantidade,2} = R$ {item.Preco,6:F2}");
            }
        }
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Valor TOTAL a pagar: R$ {valorTotal,6:F2}");
        Console.WriteLine("-------------------------------------");
    }
}