using Biblioteca.Models;

namespace Biblioteca.DTO;

public record EmprestimoDTO(Livro livro , Usuario usuario, DateTime dataEmprestimo);
