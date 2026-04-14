using Biblioteca.Models;
using Biblioteca.Repositories;

Usuario usuario = new Usuario("Gabriel", "gabriel@example.com", "84995959595");

UsuarioRepository.AdicioanrUsuario(usuario);

Livro livro = new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954);
Livro livro1 = new Livro("Harry Potter e a Pedra Filosofal", "J.K. Rowling", 1997);
Livro livro2 = new Livro("O Código Da Vinci", "Dan Brown", 2003);
Livro livro3 = new Livro("O Pequeno Príncipe", "Antoine de Saint-Exupéry", 1943);

LivroRepository.AdicionarLivro(livro);
LivroRepository.AdicionarLivro(livro1);
LivroRepository.AdicionarLivro(livro2);
LivroRepository.AdicionarLivro(livro3);

Emprestimo emprestimo = new Emprestimo(usuario, livro, 7);
Emprestimo emprestimo1 = new Emprestimo(usuario, livro1, 7);
Emprestimo emprestimo2 = new Emprestimo(usuario, livro2, 7);
Emprestimo emprestimo3 = new Emprestimo(usuario, livro3, 7);
Emprestimo emprestimo4 = new Emprestimo(usuario, livro1, 7);

Console.WriteLine("\nStatus usuarios: ");
foreach (var item in UsuarioRepository.RetornaLista())
    Console.WriteLine(item);

Console.WriteLine("\nStatus livros: ");
foreach (var item in LivroRepository.RetornaLista())
    Console.WriteLine(item);

Console.WriteLine(EmprestimoRepository.AdicionarEmprestimo(emprestimo));
Console.WriteLine(EmprestimoRepository.AdicionarEmprestimo(emprestimo1));
Console.WriteLine(EmprestimoRepository.AdicionarEmprestimo(emprestimo4));
Console.WriteLine(EmprestimoRepository.AdicionarEmprestimo(emprestimo2));
Console.WriteLine(EmprestimoRepository.AdicionarEmprestimo(emprestimo3));

Console.WriteLine("\nStatus usuarios: ");
foreach (var item in UsuarioRepository.RetornaLista())
    Console.WriteLine(item);

Console.WriteLine("\nStatus livros: ");
foreach (var item in LivroRepository.RetornaLista())
    Console.WriteLine(item);

Console.WriteLine($"\nEmprestimos do sitema: ");
foreach (var item in EmprestimoRepository.RetornaLista())
    Console.WriteLine(item);

Console.WriteLine(EmprestimoRepository.DevolverLivro(1, 7));
Console.WriteLine(EmprestimoRepository.DevolverLivro(2, 7));
Console.WriteLine(EmprestimoRepository.DevolverLivro(3, 9));
Console.WriteLine(EmprestimoRepository.DevolverLivro(4, 9));

Console.WriteLine(livro.DeletaLivro());
Console.WriteLine(livro1.DeletaLivro());
Console.WriteLine(livro2.DeletaLivro());

Console.WriteLine(usuario.DeletaAluno());

Console.WriteLine("\nStatus usuarios: ");
foreach (var item in UsuarioRepository.RetornaLista())
    Console.WriteLine(item);

Console.WriteLine("\nStatus livros: ");
foreach (var item in LivroRepository.RetornaLista())
    Console.WriteLine(item);

Console.WriteLine($"\nEmprestimos do sitema: ");
foreach (var item in EmprestimoRepository.RetornaLista())
    Console.WriteLine(item);
