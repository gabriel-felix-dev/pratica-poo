using Biblioteca.Models;
using Biblioteca.Repositories;

Usuario usuario = new Usuario("Gabriel", "gabriel@example.com", "84995959595");

Livro livro = new Livro("O Senhor dos Anéis", "J.R.R. Tolkien", 1954);
Livro livro1 = new Livro("Harry Potter e a Pedra Filosofal", "J.K. Rowling", 1997);
Livro livro2 = new Livro("O Código Da Vinci", "Dan Brown", 2003);
Livro livro3 = new Livro("A Menina que Roubava Livros", "Markus Zusak", 2005);
Livro livro4 = new Livro("O Alquimista", "Paulo Coelho", 1988);

Emprestimo emprestimo = new Emprestimo(usuario, livro, 7);
Emprestimo emprestimo1 = new Emprestimo(usuario, livro1, 7);
Emprestimo emprestimo2 = new Emprestimo(usuario, livro2, 7);


EmprestimoRepository.AdicionarEmprestimo(emprestimo);
EmprestimoRepository.AdicionarEmprestimo(emprestimo1);
EmprestimoRepository.AdicionarEmprestimo(emprestimo2);

