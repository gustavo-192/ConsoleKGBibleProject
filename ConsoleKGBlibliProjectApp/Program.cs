// See https://aka.ms/new-console-template for more information
using ConsoleKGBlibliProjectApp.Entities;
using ConsoleKGBlibliProjectApp.MenuOpcoes;
using Repository.Json;

/*
1 - Preciso exibir no consolewriteline as tabelas que o usuário irá acessar.
2 - Exibir as tabelas para o usuário.
3 - Colocar o consolereadline para que o usuário digite a tabela que deseja acessar. 
4 - Mostrar a tabela Escolhida.
*/
IGenericRepository _repository = new GenericRepository();

MenuPrincipal();

void MenuPrincipal()
{
    Console.WriteLine("Executando KGBibleProjectApp");

    Console.WriteLine("Qual tabela você gostaria de acessar? \n 1 - City \n 2 - Person ");
    int tabelaSelecionada = int.Parse(Console.ReadLine());

    Console.WriteLine("\nEscolha a operation:\n 1 - Ler todos.\n 2 - Buscar por id.\n 3 - Atualizar.\n 4 - Criar");
    int opcaoSelecionada = int.Parse(Console.ReadLine());

    if (opcaoSelecionada == 1)
    {
        if (tabelaSelecionada == 1)
        {
            List<City> cidades = _repository.ReadAll<City>().ToList();
            cidades.ForEach
            (
                item =>
                Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao}")
            );
        }
        if (tabelaSelecionada == 2)
        {
            List<Person> pessoas = _repository.ReadAll<Person>().ToList();
            pessoas.ForEach
            (
                item =>
                Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Sexo: {item.Sexo} - Descrição: {item.Descricao}")
            );
        }

    }
    if (opcaoSelecionada == 2)
    {
        Console.WriteLine($"Opção selecionada 2.");
        List<Person> pessoas = _repository.ReadAll<Person>().ToList();
        Console.WriteLine("\n Escolha uma pessoa pelo ID: \n");
        pessoas.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome}")
        );
        Console.WriteLine("Digite um ID: ");
        int idSelecionado = int.Parse(Console.ReadLine());
        var pessoa = _repository.GetById<Person>(idSelecionado);
        ExibirPessoa.Exibir(pessoa, opcaoSelecionada);
    }
    if (opcaoSelecionada == 3)
    {

    }
    if (opcaoSelecionada == 4)
    {

    }
}