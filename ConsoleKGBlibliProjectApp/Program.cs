// See https://aka.ms/new-console-template for more information
using ConsoleKGBlibliProjectApp.Entities;
using Repository.Json;

Console.WriteLine("KGbibleprojetc");

Person person = new();

Console.WriteLine("Digite o nome do fiel:");
person.Nome = Console.ReadLine();
Console.WriteLine("Digite a descrição do fiel:");
person.Descricao = Console.ReadLine();
Console.WriteLine("Digite e sexe do fiel:");
person.Sexo = Console.ReadLine();



Console.WriteLine("nome:" + person.Nome);

IGenericRepository _repository = new GenericRepository();

_repository.Create(person);