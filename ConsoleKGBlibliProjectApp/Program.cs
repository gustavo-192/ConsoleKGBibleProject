using ConsoleKGBlibliProjectApp.MenuOpcoes;
using ConsoleKGBlibliProjectApp.Enums;
MenuPrincipal();

void MenuPrincipal()
{
    Console.WriteLine("Executando KGBibleProjectApp");

    Console.WriteLine("Qual tabela você gostaria de acessar? \n 1 - Person \n 2 - City ");
    ETabelas tabelaSelecionada = (ETabelas)int.Parse(Console.ReadLine());

    Console.WriteLine("\nEscolha a operation:\n 1 - Ler todos.\n 2 - Buscar por id.\n 3 - Atualizar.\n 4 - Criar");
    EOperacao opcaoSelecionada = (EOperacao)int.Parse(Console.ReadLine());

    if (opcaoSelecionada == EOperacao.LerTodos)
    {
        if (tabelaSelecionada == ETabelas.Person)
        {
            ExibirPessoa.ExibirTodos();
        }

        if (tabelaSelecionada == ETabelas.City)
        {
            ExibirCidade.ExibirTodos();
        }
    }

    if (opcaoSelecionada == EOperacao.BuscarPorId)
    {
        if (tabelaSelecionada == ETabelas.Person)
        {
            ExibirPessoa.ExibirPorId();
        }

        if (tabelaSelecionada == ETabelas.City)
        {
            ExibirCidade.ExibirPorId();
        }
    }

    if (opcaoSelecionada == EOperacao.Atualizar)
    {
        if (tabelaSelecionada == ETabelas.Person)
        {
            ExibirPessoa.Atualizar();
        }

        if (tabelaSelecionada == ETabelas.City)
        {
            ExibirCidade.Atualizar();
        }
    }
    
    if (opcaoSelecionada == EOperacao.Criar)
    {
        if (tabelaSelecionada == ETabelas.Person)
        {
            ExibirPessoa.Criar();
        }

        if (tabelaSelecionada == ETabelas.City)
        {
            ExibirCidade.Criar();
        }

    }
}
    





