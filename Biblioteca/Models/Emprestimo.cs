using Biblioteca.Enums;

namespace Biblioteca.Models;

public class Emprestimo
{
    public Emprestimo(Usuario usuario, Livro livro, int prazoEmprestimo)
    {
        Id = ++ContadorId;
        Usuario = usuario;
        Livro = livro;
        PrazoEmprestimo = prazoEmprestimo;
        StatusEmprestimo = StatusEmprestimoEnum.NoPrazo;
    }

    public static int ContadorId = 0;
    public int Id { get; }
    public Usuario Usuario { get; private set; }
    public Livro Livro { get; private set; }
    public StatusEmprestimoEnum StatusEmprestimo { get; private set; }
    public DateTime DataEmprestimo { get; } = DateTime.Now;
    public DateTime DataDevolucaoPrevista => DataEmprestimo.AddDays(PrazoEmprestimo);
    public DateTime DataDevolucaoRealizada { get; private set; }
    private int PrazoEmprestimo { get; }

    public void AlteraStatus(StatusEmprestimoEnum novoStatus) => StatusEmprestimo = novoStatus;

    public override string ToString() => $"Id: {Id} | Usuario: {Usuario.Nome} | Livro: {Livro.Titulo} | Status Emprestimo: {StatusEmprestimo} | Data Emprestimo: {DataEmprestimo} | Data Devolução Prevista: {DataDevolucaoPrevista} | Data Devolução Realizada: {(DataDevolucaoRealizada == default ? "Não devolvido" : DataDevolucaoRealizada.ToString())}";
}
