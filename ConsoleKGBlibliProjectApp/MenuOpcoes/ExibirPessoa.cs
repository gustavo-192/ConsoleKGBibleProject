using ConsoleKGBlibliProjectApp.Entities;
using Repository.Json;

namespace ConsoleKGBlibliProjectApp.MenuOpcoes;

public static class ExibirPessoa
{
    static IGenericRepository _repository = new GenericRepository();

    public static void ExibirTodos()
    {
        Console.WriteLine($"Opção selecionada 1.");
        List<Person> pessoas = _repository.ReadAll<Person>().ToList();
        pessoas.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Sexo: {item.Sexo} - Descrição: {item.Descricao}")
        );
    }

    public static void ExibirPorId()
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

        Console.WriteLine($"Nome: {pessoa.Nome}");
        Console.WriteLine($"Descrição: {pessoa.Descricao}");
        Console.WriteLine("Sexo:" + pessoa.Sexo);

    }

    public static void Atualizar()
    {
        Console.WriteLine($"Opção selecionada 3.");

        List<Person> pessoas = _repository.ReadAll<Person>().ToList();
        Console.WriteLine("\n");

        pessoas.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome}")
        );

        Console.WriteLine("\n");

        Console.WriteLine("Digite um ID que você deseja alterar: ");
        int idSelecionado = int.Parse(Console.ReadLine());

        //Buscando pessoa de acordo com o Id selecionado
        var pessoa = _repository.GetById<Person>(idSelecionado);

        Console.WriteLine("Altere o nome:");
        pessoa.Nome = Console.ReadLine();
        Console.WriteLine("Altere a descrição:");
        pessoa.Descricao = Console.ReadLine();
        Console.WriteLine("Altere o Sexo:");
        pessoa.Sexo = Console.ReadLine();
        Console.WriteLine("\n");

        //Atualizando no Json
        _repository.Update<Person>(pessoa);
        Console.WriteLine("\n");

        //Chamando lista mais recente
        pessoas = _repository.ReadAll<Person>().ToList();

        pessoas.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao} - Sexo: {item.Sexo}")
        );

    }
    public static void Criar()
    {
        Person pessoa = new Person();
        Console.WriteLine("Opção 4 selecionada. \n");

        Console.WriteLine("Por favor, digite: nome, descrição e sexo: ");

        pessoa.Nome = Console.ReadLine();
        pessoa.Descricao = Console.ReadLine();
        pessoa.Sexo = Console.ReadLine();

        _repository.Create<Person>(pessoa);

        Console.WriteLine();
        Console.WriteLine("Lista atualizada\n");

        var pessoas = _repository.ReadAll<Person>().ToList();
        pessoas.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao} - Sexo: {item.Sexo}")
        );

    }

}