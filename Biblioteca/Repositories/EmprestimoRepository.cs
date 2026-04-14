using Biblioteca.Enums;
using Biblioteca.Models;

namespace Biblioteca.Repositories;

public class EmprestimoRepository
{
    public Emprestimo emprestimo { get; private set; }

    public static readonly List<Emprestimo> _emprestimos = [];

    public static void AdicionarEmprestimo(Emprestimo emprestimo)
    {
        if (emprestimo.Livro.StatusLivro.Equals(StatusLivroEnum.Reservado))
            throw new ArgumentException("Não é possivel reservar livro já reservado");

        if (emprestimo.Usuario.LivrosReservados == 3)
            throw new ArgumentException("O usuario não pode ter mais de 3 livros reservados");

        if (emprestimo.Livro.StatusLivro.Equals(StatusLivroEnum.Disponivel) && emprestimo.Usuario.LivrosReservados < 3)
        {
            emprestimo.Usuario.AdicinaQuantidadeLivroReservado();
            emprestimo.Livro.AlteraStatus(StatusLivroEnum.Reservado);
            _emprestimos.Add(emprestimo);
        }
    }

    public static void DevolverLivro(int idEmprestimo)
    {
        var emprestimo = _emprestimos.FirstOrDefault(e => e.Id == idEmprestimo);

        if (emprestimo == null)
            throw new ArgumentException("O emprestimo não existe");

        emprestimo.Livro.AlteraStatus(StatusLivroEnum.Disponivel);
        emprestimo.AlteraStatus(StatusEmprestimoEnum.Finalizado);
        emprestimo.Usuario.RemoveLivroDeAluno();
    }
}
