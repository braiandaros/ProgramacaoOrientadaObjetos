using System;
using System.Collections.Generic;
using System.Linq;

public enum OpcaoMenu
{
    Refrigerante = 1,
    Suco = 2,
    Agua = 3,
    Hamburguer = 4,
    BatataFrita = 5,
    Salada = 6,
    RemoverItem = 7,
    FinalizarPedido = 8
}

public class ItemMenu
{
    public string Nome { get; }
    public double Preco { get; }

    public ItemMenu(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }
}
public class ItemPedido
{
    public ItemMenu Item { get; }
    public int Quantidade { get; private set; }

    public ItemPedido(ItemMenu item, int quantidade)
    {
        Item = item;
        Quantidade = quantidade;
    }

    public double GetSubtotal()
    {
        return Item.Preco * Quantidade;
    }

    public void AdicionarQuantidade(int quantidade)
    {
        Quantidade += quantidade;
    }
}

class Lanchonete
{
    private static Dictionary<int, ItemMenu> menuItens = new Dictionary<int, ItemMenu>()
    {
        { (int)OpcaoMenu.Refrigerante, new ItemMenu("Refrigerante", 5.00) },
        { (int)OpcaoMenu.Suco, new ItemMenu("Suco", 6.50) },
        { (int)OpcaoMenu.Agua, new ItemMenu("Agua", 3.00) },
        { (int)OpcaoMenu.Hamburguer, new ItemMenu("Hamburguer", 25.00) },
        { (int)OpcaoMenu.BatataFrita, new ItemMenu("Batata Frita", 12.00) },
        { (int)OpcaoMenu.Salada, new ItemMenu("Salada", 18.50) }
    };

    static void Main(string[] args)
    {
        var pedido = new List<ItemPedido>();
        int opcao;

        do
        {
            ExibirMenu(pedido.Sum(p => p.GetSubtotal()));

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opcao invalida. Digite um numero.");
                continue;
            }

            if (menuItens.ContainsKey(opcao))
            {
                var itemMenu = menuItens[opcao];
                AdicionarItemAoPedido(pedido, itemMenu);
            }
            else if (opcao == (int)OpcaoMenu.RemoverItem)
            {
                RemoverItemDoPedido(pedido);
            }
            else if (opcao == (int)OpcaoMenu.FinalizarPedido)
            {
                Console.WriteLine("\nFinalizando o pedido...");
            }
            else
            {
                Console.WriteLine("Opcao invalida. Por favor, escolha uma das opcoes do menu.");
            }

        } while (opcao != (int)OpcaoMenu.FinalizarPedido);

        ImprimirNota(pedido);
    }

    private static void ExibirMenu(double valorParcial)
    {
        Console.WriteLine("\n--- Menu Completo da Lanchonete ---");
        foreach (var item in menuItens)
        {
            Console.WriteLine($"{item.Key}. {item.Value.Nome} (R$ {item.Value.Preco:F2})");
        }
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"{(int)OpcaoMenu.RemoverItem}. Remover Item do Pedido");
        Console.WriteLine($"{(int)OpcaoMenu.FinalizarPedido}. Finalizar Pedido");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine($"Valor total parcial: R$ {valorParcial:F2}");
        Console.Write("Escolha uma opcao: ");
    }

    private static void AdicionarItemAoPedido(List<ItemPedido> pedido, ItemMenu itemMenu)
    {
        Console.Write("Digite a quantidade: ");
        if (int.TryParse(Console.ReadLine(), out int quantidade) && quantidade > 0)
        {
            var itemExistente = pedido.FirstOrDefault(p => p.Item.Nome == itemMenu.Nome);

            if (itemExistente != null)
            {
                itemExistente.AdicionarQuantidade(quantidade);
                Console.WriteLine($"{quantidade} {itemMenu.Nome}(s) adicionado(s) ao item existente no pedido.");
            }
            else
            {
                pedido.Add(new ItemPedido(itemMenu, quantidade));
                Console.WriteLine($"{quantidade} {itemMenu.Nome}(s) adicionado(s) ao pedido.");
            }
        }
        else
        
        {
            Console.WriteLine("Quantidade invalida. Tente novamente.");
        }
    }

    private static void RemoverItemDoPedido(List<ItemPedido> pedido)
    {
        if (pedido.Count == 0)
        {
            Console.WriteLine("Nenhum item no pedido para remover.");
            return;
        }

        Console.WriteLine("\n--- Itens no Pedido ---");
        for (int i = 0; i < pedido.Count; i++)
        {
            var item = pedido[i];
            Console.WriteLine($"{i + 1}. {item.Item.Nome} x{item.Quantidade}");
        }
        Console.WriteLine("-----------------------");
        Console.Write("Digite o numero do item que deseja remover: ");

        if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex >= 1 && itemIndex <= pedido.Count)
        {
            var itemRemovido = pedido[itemIndex - 1];
            pedido.RemoveAt(itemIndex - 1);
            Console.WriteLine($"{itemRemovido.Item.Nome} removido do pedido.");
        }
        else
        {
            Console.WriteLine("Selecao invalida. Nenhum item foi removido.");
        }
    }

    private static void ImprimirNota(List<ItemPedido> pedido)
    {
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
                Console.WriteLine($"{item.Item.Nome,-20} x {item.Quantidade,2} = R$ {item.GetSubtotal(),6:F2}");
            }
        }
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Valor TOTAL a pagar: R$ {pedido.Sum(p => p.GetSubtotal()),6:F2}");
        Console.WriteLine("-------------------------------------");
    }
}