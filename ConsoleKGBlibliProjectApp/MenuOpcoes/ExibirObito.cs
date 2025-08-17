using Repository.Json;
using ConsoleKGBlibliProjectApp.Entities;


namespace ConsoleKGBlibliProjectApp.MenuOpcoes;


public static class ExibirObito
{
    static IGenericRepository _repository = new GenericRepository();

    public static void ExibirTodos()
    {
        Console.WriteLine($"Opção selecionada 1.");
        List<Death> obitos = _repository.ReadAll<Death>().ToList();
        obitos.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Id Pessoa: {item.IdPessoa} - Anos de Vivência: {item.AnosVicencia} - Causa: {item.Causa}")
        );
    }
    public static void ExibirPorId()
    {
        Console.WriteLine($"Opção selecionada 2.");
        List<Death> obitos = _repository.ReadAll<Death>().ToList();
        Console.WriteLine("\n Escolha um Óbito pelo ID: \n");
        obitos.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Id Pessoa: {item.IdPessoa} - Anos de Vivência: {item.AnosVicencia} - Causa: {item.Causa}")
        );

        Console.WriteLine("Digite um ID: ");
        int idSelecionado = int.Parse(Console.ReadLine());

        var obito = _repository.GetById<Death>(idSelecionado);

        Console.WriteLine($"Nome: {obito.Id}");
        Console.WriteLine($"Id Pessoa: {obito.IdPessoa}");
        Console.WriteLine($"Anos Vivência: {obito.AnosVicencia}");
        Console.WriteLine($"Causa: {obito.Causa}");
    }
    public static void Atualizar()
    {
        Console.WriteLine($"Opção selecionada 3.");
        List<Death> obitos = _repository.ReadAll<Death>().ToList();

        Console.WriteLine("\n");
        obitos.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Id Pessoa: {item.IdPessoa} - Anos de Vivência: {item.AnosVicencia} - Causa: {item.Causa}")
        );

        Console.WriteLine("\n");
        Console.WriteLine("Digite um ID que você deseja alterar: ");
        int idSelecionado = int.Parse(Console.ReadLine());
        Console.WriteLine("\n");

        //Buscando Óbito de acordo com o Id selecionado
        var obito = _repository.GetById<Death>(idSelecionado);

        Console.WriteLine("Altere os Anos de Vicência:");
        obito.AnosVicencia = int.Parse(Console.ReadLine());
        Console.WriteLine("Altere a Causa da Morte:");
        obito.Causa = Console.ReadLine();
        Console.WriteLine("\n");


        //Atualizando no Json
        _repository.Update<Death>(obito);

        //Chamando lista mais recente
        obitos = _repository.ReadAll<Death>().ToList();
        obitos.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Id Pessoa: {item.IdPessoa} - Anos de Vivência: {item.AnosVicencia} - Causa: {item.Causa}")
        );

    }
    public static void Criar()
    {
        Death obito = new Death();
        Console.WriteLine("Opção 4 selecionada. \n");

        Console.WriteLine("Por favor, digite: IdPessoa, Anos de Vivência e a causa da Morte: ");

        obito.IdPessoa = int.Parse(Console.ReadLine());
        obito.AnosVicencia = int.Parse(Console.ReadLine());
        obito.Causa = Console.ReadLine();

        _repository.Create<Death>(obito);

        Console.WriteLine();
        Console.WriteLine("Lista atualizada\n");

        var obitos = _repository.ReadAll<Death>().ToList();
        obitos.ForEach
        (
            item =>
            Console.WriteLine($"Id: {item.Id} - Id Pessoa: {item.IdPessoa} - Anos de Vivência: {item.AnosVicencia} - Causa: {item.Causa}")
        );

    }

}