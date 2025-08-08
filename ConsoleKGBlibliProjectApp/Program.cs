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
IGenericRepository _repository = new GenericRepository();

MenuPrincipal();

void MenuPrincipal()
{
    Console.WriteLine("Executando KGBibleProjectApp");

    Console.WriteLine("Qual tabela você gostaria de acessar? \n 1 - Person \n 2 - City ");
    int tabelaSelecionada = int.Parse(Console.ReadLine());

    Console.WriteLine("\nEscolha a operation:\n 1 - Ler todos.\n 2 - Buscar por id.\n 3 - Atualizar.\n 4 - Criar");
    int opcaoSelecionada = int.Parse(Console.ReadLine());

    if (opcaoSelecionada == 1)
    {
        if (tabelaSelecionada == 1)
        {
            Console.WriteLine($"Opção selecionada 1.");
            List<Person> pessoas = _repository.ReadAll<Person>().ToList();
            pessoas.ForEach
            (
                item =>
                Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Sexo: {item.Sexo} - Descrição: {item.Descricao}")
            );
        }
        if (tabelaSelecionada == 2)
        {
            Console.WriteLine($"Opção selecionada 1.");
            List<City> cidades = _repository.ReadAll<City>().ToList();
            cidades.ForEach
            (
                item =>
                Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome} - Descrição: {item.Descricao}")
            );
        }

    }
    if (opcaoSelecionada == 2)
    {
        if (tabelaSelecionada == 1)
        {
                Console.WriteLine($"Opção selecionada 2.");
                List<Person> pessoas = _repository.ReadAll<Person>().ToList();
                Console.WriteLine("\n Escolha uma cidade pelo ID: \n");
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
        if (tabelaSelecionada == 2)
        {
                Console.WriteLine($"Opção selecionada 2.");
                List<City> cidades = _repository.ReadAll<City>().ToList();
                Console.WriteLine("\n Escolha uma pessoa pelo ID: \n");
                cidades.ForEach
                (
                    item =>
                    Console.WriteLine($"Id: {item.Id} - Nome: {item.Nome}")
                );
                Console.WriteLine("Digite um ID: ");
                int idSelecionado = int.Parse(Console.ReadLine());
                var cidade = _repository.GetById<City>(idSelecionado);
                ExibirCidade.Exibir(cidade, opcaoSelecionada);
        }

    }
    if (opcaoSelecionada == 3)
    {
        if (tabelaSelecionada == 1)
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
        if (tabelaSelecionada == 2)
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
    }
    if (opcaoSelecionada == 4)
    {

    }
}
    





