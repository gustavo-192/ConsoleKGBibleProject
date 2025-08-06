using ConsoleKGBlibliProjectApp.Entities;

namespace ConsoleKGBlibliProjectApp.MenuOpcoes;

public static class ExibirPessoa
{
    public static void Exibir(Person pessoa, int opcaoSelecionada)
    {


        if (opcaoSelecionada == 1)
        {
            //To do implement ready all
        }
        if (opcaoSelecionada == 2)
        {
            Console.WriteLine($"Nome: {pessoa.Nome}");
            Console.WriteLine($"Descrição: {pessoa.Descricao}");
            Console.WriteLine("Sexo:" + pessoa.Sexo);
        }
        if (opcaoSelecionada == 3)
        {
            Console.WriteLine("Digite o nome do fiel:");
            pessoa.Nome = Console.ReadLine();
            Console.WriteLine("Digite a descrição do fiel:");
            pessoa.Descricao = Console.ReadLine();
            Console.WriteLine("Digite e sexe do fiel:");
            pessoa.Sexo = Console.ReadLine();
        }
        if (opcaoSelecionada == 4)
        {

        }

    }

}