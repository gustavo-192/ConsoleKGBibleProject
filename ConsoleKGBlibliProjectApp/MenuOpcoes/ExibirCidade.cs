using ConsoleKGBlibliProjectApp.Entities;
using Repository.Json;

namespace ConsoleKGBlibliProjectApp.MenuOpcoes;

public static class ExibirCidade
{
    static IGenericRepository _repository = new GenericRepository();

    public static void ExibirTodos()
    {
        Console.WriteLine($"Opção selecionada 1.");
        List<City> cidades = _repository.ReadAll<City>().ToList();
        cidades.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao}")
        );
    }

    public static void ExibirPorId()
    {
        Console.WriteLine($"Opção selecionada 2.");
        List<City> cidades = _repository.ReadAll<City>().ToList();
        Console.WriteLine("\n Escolha uma cidade pelo ID: \n");
        cidades.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome}")
        );

        Console.WriteLine("Digite um ID: ");
        int idSelecionado = int.Parse(Console.ReadLine());

        var cidade = _repository.GetById<City>(idSelecionado);

        Console.WriteLine($"Nome: {cidade.Nome}");
        Console.WriteLine($"Descrição: {cidade.Descricao}");

    }
    public static void Atualizar()
    {
        Console.WriteLine($"Opção selecionada 3.");
        List<City> cidades = _repository.ReadAll<City>().ToList();

        Console.WriteLine("\n");
        cidades.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao}")
        );

        Console.WriteLine("\n");
        Console.WriteLine("Digite um ID que você deseja alterar: ");
        int idSelecionado = int.Parse(Console.ReadLine());
        Console.WriteLine("\n");

        //Buscando Cidade de acordo com o Id selecionado
        var cidade = _repository.GetById<City>(idSelecionado);

        Console.WriteLine("Altere o nome:");
        cidade.Nome = Console.ReadLine();
        Console.WriteLine("Altere a descrição:");
        cidade.Descricao = Console.ReadLine();
        Console.WriteLine("\n");


        //Atualizando no Json
        _repository.Update<City>(cidade);

        //Chamando lista mais recente
        cidades = _repository.ReadAll<City>().ToList();
        cidades.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao}")
        );

    }
    public static void Criar()
    {
        City cidade = new City();
        Console.WriteLine("Opção 4 selecionada. \n");

        Console.WriteLine("Por favor, digite Id, nome, descrição: ");

        cidade.Id = int.Parse(Console.ReadLine());
        cidade.Nome = Console.ReadLine();
        cidade.Descricao = Console.ReadLine();

        _repository.Create<City>(cidade);

        Console.WriteLine();
        Console.WriteLine("Lista atualizada\n");

        var cidades = _repository.ReadAll<City>().ToList();
        cidades.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao}")
        );
    }

}