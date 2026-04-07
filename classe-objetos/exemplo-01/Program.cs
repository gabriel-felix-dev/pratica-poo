using Exemplo01.Models;

Pessoa pessoa1 = new Pessoa();

pessoa1.Nome = "Maria";
pessoa1.Idade = 25;
pessoa1.Email = "maria@email.com";

Pessoa pessoa2 = new Pessoa("João", 30, "joao@email.com");

pessoa1.ApresentarSe();

Console.WriteLine();

pessoa2.ApresentarSe();

Console.WriteLine();

pessoa1.FazerAniversario();

Console.WriteLine();

if (pessoa2.EMaiorDeIdade())
    Console.WriteLine($"{pessoa2.Nome} é maior de idade");

Console.WriteLine();

Console.WriteLine(pessoa1.ToString());
