// See https://aka.ms/new-console-template for more information
using ConsoleKGBlibliProjectApp.Entities;
using ConsoleKGBlibliProjectApp.MenuOpcoes;
using Repository.Json;

/*
f9 colocar o break point.
f10 passa para a próxima linha.
f11 entra no método.
f5 ele para no próximo break point se não tiver, roda a aplication todex.
shift + f10 sai do método que entrou no f11.

1 - Preciso exibir no consolewriteline as tabelas que o usuário irá acessar.
2 - Exibir as tabelas para o usuário.
3 - Colocar o consolereadline para que o usuário digite a tabela que deseja acessar. 
4 - Mostrar a tabela Escolhida.
*/

MenuPrincipal();

void MenuPrincipal()
{
    Console.WriteLine("Executando KGBibleProjectApp");

    Console.WriteLine("Qual tabela você gostaria de acessar? \n 1 - Person \n 2 - City ");
    TabelasEnum tabelaSelecionada = (TabelasEnum)int.Parse(Console.ReadLine());

    Console.WriteLine("\nEscolha a operation:\n 1 - Ler todos.\n 2 - Buscar por id.\n 3 - Atualizar.\n 4 - Criar");
    OperacaoEnum opcaoSelecionada = (OperacaoEnum)int.Parse(Console.ReadLine());

    if (opcaoSelecionada == OperacaoEnum.LerTodos)
    {
        if (tabelaSelecionada == TabelasEnum.Person)
        {
            ExibirPessoa.ExibirTodos();
        }

        if (tabelaSelecionada == TabelasEnum.City)
        {
            ExibirCidade.ExibirTodos();
        }
    }

    if (opcaoSelecionada == OperacaoEnum.BuscarPorId)
    {
        if (tabelaSelecionada == TabelasEnum.Person)
        {
            ExibirPessoa.ExibirPorId();
        }

        if (tabelaSelecionada == TabelasEnum.City)
        {
            ExibirCidade.ExibirPorId();
        }
    }

    if (opcaoSelecionada == OperacaoEnum.Atualizar)
    {
        if (tabelaSelecionada == TabelasEnum.Person)
        {
            ExibirPessoa.Atualizar();
        }

        if (tabelaSelecionada == TabelasEnum.City)
        {
            ExibirCidade.Atualizar();
        }
    }
    
    if (opcaoSelecionada == OperacaoEnum.Criar)
    {
        if (tabelaSelecionada == TabelasEnum.Person)
        {
            ExibirPessoa.Criar();
        }

        if (tabelaSelecionada == TabelasEnum.City)
        {
            ExibirCidade.Criar();
        }

    }
}
    





