// See https://aka.ms/new-console-template for more information
using ConsoleKGBlibliProjectApp.Entities;
using Repository.Json;

Console.WriteLine("KGBibleProject");

Person person = new();
City city = new();

Console.WriteLine("Digite o nome do fiel:");
person.Nome = Console.ReadLine();
Console.WriteLine("Digite a descrição do fiel:");
person.Descricao = Console.ReadLine();
Console.WriteLine("Digite e sexe do fiel:");
person.Sexo = Console.ReadLine();



// Console.WriteLine("nome:" + person.Nome);

IGenericRepository _repository = new GenericRepository();
// _repository.Create(city);
// _repository.Create(person);

var cidade = _repository.GetById<City>(1);
Console.WriteLine($"Exibindo o que veio do banco.");
Console.WriteLine($"Nome: {cidade.Nome}");

var pessoa = _repository.GetById<Person>(2);
Console.WriteLine($"Exibindo o que veio do banco.");
Console.WriteLine($"Nome: {pessoa.Nome}");
Console.WriteLine($"Descrição: {pessoa.Descricao}");
Console.WriteLine("Sexo:" + pessoa.Sexo);
