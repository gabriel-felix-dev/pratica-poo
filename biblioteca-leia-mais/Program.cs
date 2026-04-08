using biblioteca_leia_mais.Models;

Livro livro1 = new("1984");
Livro livro2 = new("O Pequeno Principe");

Usuario usuario1 = new("João");

Emprestimo emprestimo1 = new(usuario1, livro1);
Emprestimo emprestimo2 = new(usuario1, livro2);

Console.WriteLine(livro1.ToString());
Console.WriteLine(livro2.ToString());
Console.WriteLine();
Console.WriteLine(usuario1.ToString());

List<Emprestimo> listaEmprestimos = [];

listaEmprestimos.Add(emprestimo1);
usuario1.AdicionaLivrosReservados();
livro1.AlteraStausLivro();

listaEmprestimos.Add(emprestimo2);
usuario1.AdicionaLivrosReservados();
livro2.AlteraStausLivro();

Console.WriteLine();

foreach (var item in listaEmprestimos)
    Console.WriteLine($"Empréstimo Id: {item.Id} | Data Empréstimo: {item.DataReserva} | {item.Usuario.ToString()} | {item.Livro.ToString()}");

Console.WriteLine();
Console.WriteLine(livro1.ToString());
Console.WriteLine(livro2.ToString());
Console.WriteLine();
Console.WriteLine(usuario1.ToString());

Console.WriteLine();
Console.WriteLine("Relatório emprestimo");


foreach (var item in listaEmprestimos)
    Console.WriteLine($"Empréstimo Id: {item.Id} | Data Empréstimo: {item.DataReserva} | {item.Usuario.ToString()} | {item.Livro.ToString()}");

Console.WriteLine();
Console.WriteLine(livro1.ToString());
Console.WriteLine(livro2.ToString());
Console.WriteLine();
Console.WriteLine(usuario1.ToString());

void DevolverLivro(int diasComLivro, Emprestimo emprestimo)
{
    //if(diasComLivro > 7)
    //aplicar multa
    //emprestimo.Livro.AlteraStausLivro();
    //emprestimo.status = false
}
