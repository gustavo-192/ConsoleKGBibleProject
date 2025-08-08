using ConsoleKGBlibliProjectApp.Entities;

namespace ConsoleKGBlibliProjectApp.MenuOpcoes;

public static class ExibirCidade
{
    public static void Exibir(City cidade, int opcaoSelecionada)
    {

        if (opcaoSelecionada == 1)
        {
            //To do implement ready all
        }
        if (opcaoSelecionada == 2)
        {
            Console.WriteLine($"Nome: {cidade.Nome}");
            Console.WriteLine($"Descrição: {cidade.Descricao}");
        }
        if (opcaoSelecionada == 3)
        {
            Console.WriteLine("Digite o nome do fiel:");
            cidade.Nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição do fiel:");
            cidade.Descricao = Console.ReadLine();
        }
        if (opcaoSelecionada == 4)
        {

        }

    }

}