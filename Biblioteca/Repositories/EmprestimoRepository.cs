using Biblioteca.Enums;
using Biblioteca.Models;

namespace Biblioteca.Repositories;

public class EmprestimoRepository
{
    public Emprestimo emprestimo { get; private set; }

    public static readonly List<Emprestimo> _emprestimos = [];

    public static string AdicionarEmprestimo(Emprestimo emprestimo)
    {
        if (emprestimo.Livro.StatusLivro.Equals(StatusLivroEnum.Reservado))
            return "\nNão é possivel reservar livro já reservado";

        if (emprestimo.Usuario.LivrosReservados == 3)
            return "\nO usuario não pode ter mais de 3 livros reservados";


        emprestimo.Usuario.AdicinaQuantidadeLivroReservado();
        emprestimo.Livro.AlteraStatus(StatusLivroEnum.Reservado);
        _emprestimos.Add(emprestimo);

        return "\nO emprestimo foi registrado com sucesso";

    }

    public static List<Emprestimo> RetornaLista() => _emprestimos;

    public static string DevolverLivro(int idEmprestimo, int diasComLivro)
    {
        var emprestimo = _emprestimos.FirstOrDefault(e => e.Id == idEmprestimo);

        if (emprestimo == null)
            return "\nO emprestimo não existe";

        emprestimo.Livro.AlteraStatus(StatusLivroEnum.Disponivel);
        emprestimo.AlteraStatus(StatusEmprestimoEnum.Finalizado);
        emprestimo.DefineDataDevolucao(diasComLivro);
        emprestimo.Usuario.RemoveLivroDeAluno();

        return $"\nLivro {emprestimo.Livro.Titulo} devolvido! Dia da devolução: {emprestimo.DataDevolucaoRealizada} - {emprestimo.CalculaMultaPorAtraso(diasComLivro)}";
    }
}
